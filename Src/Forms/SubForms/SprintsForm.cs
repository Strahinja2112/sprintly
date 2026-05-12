using Microsoft.EntityFrameworkCore;
using Sprintra.Src.Core;
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
  private readonly SprintService sprintService;

  private const string searchPlaceholder = "Pretraga sprintova...";


  public SprintsForm(BaseForm parent) {
    InitializeComponent();

    sprintService = new SprintService();
    expandedPanelWidth = PanelProjectEdit.Width;
    PanelProjectEdit.Hide();
    this.parent = parent;
  }

  private async void SprintsForm_Load(object sender, EventArgs e) {
    ComboBoxStatus.Items.AddRange(Enum.GetNames<SprintStatus>());

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

    var sprints = await sprintService.GetSprintsByProjectAsync(projectId, term);

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
    if (ComboBoxProjects.SelectedValue == null || ComboBoxStatus.SelectedItem == null) return;

    try {
      var sprintStatus = Enum.Parse<SprintStatus>(ComboBoxStatus.SelectedItem.ToString()!);

      if (sprintStatus == SprintStatus.Completed) {
        var result = MessageBox.Show("Da li ste sigurni da želite da zatvorite ovaj sprint?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.No) return;
      }

      Sprint? sprint;
      if (selectedSprintId == 0) {
        sprint = new Sprint { ProjectId = (int)ComboBoxProjects.SelectedValue };
      }
      else {
        sprint = await sprintService.GetByIdAsync(selectedSprintId);
        if (sprint == null) return;
      }

      sprint.Name = TBoxProjectName.Text.Trim();
      sprint.Goal = TBoxDescription.Text.Trim();
      sprint.StartDate = DateTimePicker.Value;
      sprint.EndDate = DateTimePicker.Value.AddDays((double)NumericSprintLength.Value * 7);
      sprint.Status = sprintStatus;

      await sprintService.SaveSprintAsync(sprint);

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
    var s = await sprintService.GetByIdAsync(id);

    if (s != null) {
      TBoxProjectName.Text = s.Name;
      TBoxDescription.Text = s.Goal;
      ComboBoxStatus.SelectedItem = s.Status.ToString();
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
    ComboBoxStatus.SelectedIndex = -1;
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

  private void DateTimePicker_ValueChanged(object sender, EventArgs e) {
    if (DateTimePicker.Value.Date <= DateTime.Now.Date) ComboBoxStatus.SelectedItem = SprintStatus.Active.ToString();
    else ComboBoxStatus.SelectedItem = SprintStatus.Planned.ToString();
  }

  private void ComboBoxStatus_SelectedIndexChanged(object sender, EventArgs e) { }
}