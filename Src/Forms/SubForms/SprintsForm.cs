using Microsoft.EntityFrameworkCore;
using Sprintra.Src;
using Sprintra.Src.Data;
using Sprintra.Src.Data.Models;
using Sprintra.Src.Forms;
using Sprintra.Src.Services;
using System.Data;

namespace Sprintra.Forms;

public partial class SprintsForm : BaseForm {
  private bool isExpanded = false;

  private readonly int expandedPanelWidth = 0;
  private int selectedSprintId = 0;

  private readonly BaseForm parent;
  private readonly SprintsService sprintsService;

  private const string searchPlaceholder = "Pretraga sprintova...";


  public SprintsForm(BaseForm parent) {
    InitializeComponent();

    sprintsService = new SprintsService();
    expandedPanelWidth = PanelProjectEdit.Width;
    PanelProjectEdit.Hide();
    this.parent = parent;
  }

  private async void SprintsForm_Load(object sender, EventArgs e) {
    await LoadProjectsToFilter();
    SetPlaceholder(TBoxSearch, searchPlaceholder);
  }

  private async Task LoadProjectsToFilter() {
    using var db = new AppDbContext();
    var projects = await db.Projects.OrderBy(p => p.Name).ToListAsync();

    ComboBoxProjects.DataSource = projects;
    ComboBoxProjects.DisplayMember = "Name";
    ComboBoxProjects.ValueMember = "Id";
    ComboBoxProjects.SelectedIndex = projects.Count > 0 ? 0 : -1;
  }

  private void ComboBoxProjects_SelectedIndexChanged(object sender, EventArgs e) {
    if (ComboBoxProjects.SelectedIndex != -1) {
      LoadSprints();
      SetRulesInUI();
    }
  }

  private void SetRulesInUI() {
    if (ComboBoxProjects.SelectedItem == null) return;

    var project = (Project)ComboBoxProjects.SelectedItem;
    DateTimePicker.MinDate = project.StartDate;
  }

  private async void LoadSprints(string term = "") {
    if (ComboBoxProjects.SelectedValue is not int projectId || projectId < 1) return;

    var sprints = await sprintsService.GetSprintsByProjectAsync(projectId, term);

    DGVSprints.DataSource = sprints.Select(s => new {
      s.Id,
      Naziv = s.Name,
      Status = s.Status.ToString(),
      Početak = s.StartDate,
      Kraj = s.EndDate
    }).ToList();

    DGVSprints.Columns["Id"]?.Visible = false;
  }

  private async void ButonAdd_Click(object sender, EventArgs e) {
    if (ComboBoxProjects.SelectedIndex == -1 || ComboBoxProjects.SelectedValue == null) {
      MessageBox.Show("Molimo vas da prvo odaberete projekat na vrhu.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
      return;
    }

    int projectId = (int)ComboBoxProjects.SelectedValue;
    NumericSprintLength.Enabled = DateTimePicker.Enabled = true;

    using (var db = new AppDbContext()) {
      var lastSprint = await db.Sprints
          .Where(s => s.ProjectId == projectId)
          .OrderByDescending(s => s.EndDate)
          .FirstOrDefaultAsync();

      if (lastSprint == null) {
        var project = await db.Projects.FindAsync(projectId);
        if (project != null) {
          DateTimePicker.MinDate = DateTimePicker.Value = project.StartDate;
        }
      }
      else if (lastSprint.EndDate.HasValue) {
        DateTimePicker.MinDate = DateTimePicker.Value = lastSprint.EndDate.Value.AddDays(1);
      }
    }

    ClearInputs();
    ExpandParent();
  }

  private async void ButtonSave_Click(object sender, EventArgs e) {
    try {
      Sprint? sprint;
      if (selectedSprintId == 0) {
        sprint = new Sprint { ProjectId = (int)ComboBoxProjects.SelectedValue };
      }
      else {
        sprint = await sprintsService.GetByIdAsync(selectedSprintId);
        if (sprint == null) return;
      }

      sprint.Name = TBoxProjectName.Text.Trim();
      sprint.Goal = TBoxDescription.Text.Trim();
      sprint.StartDate = DateTimePicker.Value;
      sprint.EndDate = DateTimePicker.Value.AddDays((double)NumericSprintLength.Value * 7);
      sprint.Status = SprintStatus.Planned;

      await sprintsService.SaveSprintAsync(sprint);

      ClearInputs();
      LoadSprints();
    }
    catch (Exception ex) {
      MessageBox.Show(ex.Message, "Validacija / Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
  }

  private async void DGVSprints_CellClick(object sender, DataGridViewCellEventArgs e) {
    if (e.RowIndex >= 0 && DGVSprints.Rows[e.RowIndex].Cells["Id"].Value != null) {
      selectedSprintId = Convert.ToInt32(DGVSprints.Rows[e.RowIndex].Cells["Id"].Value);
      await LoadSprintToInputs(selectedSprintId);
      ExpandParent();
    }
  }

  private async Task LoadSprintToInputs(int id) {
    var s = await sprintsService.GetByIdAsync(id);

    if (s != null) {
      TBoxProjectName.Text = s.Name;
      TBoxDescription.Text = s.Goal;
      DateTimePicker.Value = DateTimePicker.MinDate = s.StartDate;

      if (s.EndDate.HasValue) {
        NumericSprintLength.Value = Helpers.CalculateTimeBetween(s.StartDate, s.EndDate, TimeUnit.Weeks);
      }

      NumericSprintLength.Enabled = DateTimePicker.Enabled = false;
      bigLabel2.Text = "Izmena";
    }
  }

  private void ClearInputs() {
    selectedSprintId = 0;
    TBoxProjectName.Text = "";
    TBoxDescription.Text = "";
    DateTimePicker.Value = DateTimePicker.MinDate;
    bigLabel2.Text = "Novi Sprint";
  }

  private void ExpandParent() {
    if (!isExpanded) {
      parent.Width += expandedPanelWidth;
      PanelProjectEdit.Show();
      isExpanded = true;
    }
    parent.CenterOnScreen();
  }

  private void TBoxSearch_TextChanged(object sender, EventArgs e) {
    string term = TBoxSearch.Text.Trim();
    LoadSprints(term == searchPlaceholder ? "" : term);
  }

  private void TBoxDescription_TextChanged(object sender, EventArgs e) {
    LabelDescriptionLength.Text = $"({TBoxDescription.Text.Length}/{TBoxDescription.MaxLength})";
  }

  private async void ButtonFinishSprint_Click(object sender, EventArgs e) {
    if (selectedSprintId == 0) {
      return;
    }

    try {
      var sprint = await sprintsService.GetByIdAsync(selectedSprintId);
      if (sprint == null) {
        return;
      }

      if (await sprintsService.HasUnfinishedTasksAsync(selectedSprintId)) {
        var resultTasks = MessageBox.Show(
          "Postoje nezavršeni zadaci u ovom sprintu. Želite li da ih prebacite nazad u Backlog pre završetka sprinta?",
          "Nezavršeni zadaci",
          MessageBoxButtons.YesNoCancel,
          MessageBoxIcon.Question
        );

        if (resultTasks == DialogResult.Cancel) return;

        if (resultTasks == DialogResult.Yes) {
          await sprintsService.MoveUnfinishedTasksToBacklogAsync(selectedSprintId);
        }
      }
      else {
        var confirm = MessageBox.Show("Da li ste sigurni da želite da završite ovaj sprint?", "Potvrda", MessageBoxButtons.YesNo);
        if (confirm == DialogResult.No) return;
      }

      sprint.Status = SprintStatus.Completed;
      sprint.EndDate = DateTime.Now;

      await sprintsService.SaveSprintAsync(sprint);

      MessageBox.Show("Sprint uspešno završen!", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

      ClearInputs();
      LoadSprints();
    }
    catch (Exception ex) {
      MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }

  private async void ButtonDelete_Click(object sender, EventArgs e) {
    if (selectedSprintId == 0) return;

    var confirm = MessageBox.Show(
        "Da li ste sigurni da želite trajno da obrišete ovaj sprint?",
        "Potvrda brisanja",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning
    );

    if (confirm == DialogResult.No) return;

    try {
      await sprintsService.DeleteSprintAsync(selectedSprintId);

      ClearInputs();
      LoadSprints();

      if (isExpanded) {
        parent.Width -= expandedPanelWidth;
        PanelProjectEdit.Hide();
        isExpanded = false;
        parent.CenterOnScreen();
      }
    }
    catch (Exception ex) {
      MessageBox.Show(ex.Message, "Brisanje nije dozvoljeno", MessageBoxButtons.OK, MessageBoxIcon.Stop);
    }
  }
}