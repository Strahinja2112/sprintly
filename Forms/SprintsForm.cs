using Sprintra.Data;
using Sprintra.Data.Models;
using System.Data;

namespace Sprintra.Forms;

public partial class SprintsForm : BaseForm {
  private bool isExpanded = false;
  private readonly int expandedPanelWidth = 0;
  private readonly BaseForm parent;
  private int selectedSprintId = 0;
  private const string searchPlaceholder = "Pretraga sprintova...";

  public SprintsForm(BaseForm parent) {
    InitializeComponent();
    expandedPanelWidth = PanelProjectEdit.Width;
    PanelProjectEdit.Hide();
    this.parent = parent;
  }

  private void SprintsForm_Load(object sender, EventArgs e) {
    ComboBoxStatus.Items.AddRange(Enum.GetNames<SprintStatus>());

    LoadProjectsToFilter();

    SetPlaceholder(TBoxSearch, searchPlaceholder);
  }

  private void LoadProjectsToFilter() {
    using var db = new AppDbContext();
    var projects = db.Projects.OrderBy(p => p.Name).ToList();

    ComboBoxProjects.DataSource = projects;
    ComboBoxProjects.DisplayMember = "Name";
    ComboBoxProjects.ValueMember = "Id";
    ComboBoxProjects.SelectedIndex = projects.Count > 0 ? 0 : -1;
  }

  private void ComboBoxProjects_SelectedIndexChanged(object sender, EventArgs e) {
    if (ComboBoxProjects.SelectedIndex != -1) {
      LoadSprints();
    }
  }

  private void LoadSprints() {
    if (ComboBoxProjects.SelectedValue == null) return;
    Project? project = (Project?)ComboBoxProjects.SelectedItem;

    var projectId = project?.Id ?? 0;

    if (projectId < 1) {
      return;
    }

    using var db = new AppDbContext();
    var sprints = db.Sprints
        .Where(s => s.ProjectId == projectId)
        .Select(s => new {
          s.Id,
          Naziv = s.Name,
          Status = s.Status.ToString(),
          Početak = s.StartDate,
          Kraj = s.EndDate
        })
        .OrderByDescending(s => s.Početak)
        .ToList();

    DGVSprints.DataSource = sprints;
    DGVSprints.Columns["Id"]?.Visible = false;
  }

  private void ButonAdd_Click(object sender, EventArgs e) {
    if (ComboBoxProjects.SelectedIndex == -1) {
      MessageBox.Show("Molimo vas da prvo odaberete projekat na vrhu.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
      return;
    }

    if (ComboBoxProjects.SelectedValue == null) return;
    int projectId = (int)ComboBoxProjects.SelectedValue;

    NumericSprintLength.Enabled = DateTimePicker.Enabled = true;

    using (var db = new AppDbContext()) {
      var sprints = db.Sprints.Where(s => s.ProjectId == projectId).OrderByDescending(s => s.EndDate);
      DateTimePicker.MinDate = DateTimePicker.Value =
        sprints.Any()
          ? sprints.First().EndDate?.AddDays(1) ?? DateTime.Now
          : DateTime.Now;
    }

    ClearInputs();
    ExpandParent();
  }

  private void ButtonSave_Click(object sender, EventArgs e) {
    if (ComboBoxStatus.SelectedItem == null) {
      return;
    }

    var value = ComboBoxStatus.SelectedItem?.ToString();
    var sprintStatus = Enum.Parse<SprintStatus>(value);

    if (sprintStatus == SprintStatus.Active && DateTimePicker.Value.Date > DateTime.Now.Date) {
      MessageBox.Show("Sprint ne može biti aktivan pre datuma početka.", "Logička greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      ComboBoxStatus.SelectedItem = SprintStatus.Planned.ToString();
      return;
    }

    if (sprintStatus == SprintStatus.Completed) {
      if (DateTimePicker.Value.Date > DateTime.Now.Date) {
        MessageBox.Show("Ne možete završiti sprint koji još nije ni počeo.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        ComboBoxStatus.SelectedItem = SprintStatus.Planned.ToString();
        return;
      }

      var result = MessageBox.Show("Da li ste sigurni da želite da zatvorite ovaj sprint?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (result == DialogResult.No) {
        ComboBoxStatus.SelectedItem = SprintStatus.Active.ToString();
      }
    }

    if (sprintStatus == SprintStatus.Canceled && selectedSprintId != 0) {
      var result = MessageBox.Show("Otkazivanje sprinta će ga ukloniti iz aktivnog planiranja. Nastaviti?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
      if (result == DialogResult.No) {
        ComboBoxStatus.SelectedItem = SprintStatus.Planned.ToString();
      }
    }

    string name = TBoxProjectName.Text.Trim();
    string goal = TBoxDescription.Text.Trim();

    if (string.IsNullOrEmpty(name)) {
      MessageBox.Show("Ime sprinta je obavezno.", "Validacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      return;
    }

    try {
      using var db = new AppDbContext();
      Sprint? sprint;

      if (selectedSprintId == 0) {
        sprint = new Sprint {
          ProjectId = (int)ComboBoxProjects.SelectedValue,
          Status = SprintStatus.Planned
        };
        db.Sprints.Add(sprint);
      }
      else {
        sprint = db.Sprints.FirstOrDefault(s => s.Id == selectedSprintId);
        if (sprint == null) {
          return;
        }
      }

      sprint.Name = name;
      sprint.Goal = goal;
      sprint.StartDate = DateTimePicker.Value;
      sprint.EndDate = DateTimePicker.Value.AddDays(NumericSprintLength.Value * 7);

      if (ComboBoxStatus.SelectedIndex != -1) {
        sprint.Status = Enum.Parse<SprintStatus>(ComboBoxStatus.SelectedItem.ToString());
      }

      db.SaveChanges();
      MessageBox.Show("Sprint sačuvan!", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

      ClearInputs();
      LoadSprints();
    }
    catch (Exception ex) {
      MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }

  private void DGVSprints_CellClick(object sender, DataGridViewCellEventArgs e) {
    if (e.RowIndex >= 0 && DGVSprints.Rows[e.RowIndex].Cells["Id"].Value != null) {
      selectedSprintId = Convert.ToInt32(DGVSprints.Rows[e.RowIndex].Cells["Id"].Value);
      LoadSprintToInputs(selectedSprintId);
      ExpandParent();
    }
  }

  private void LoadSprintToInputs(int id) {
    using var db = new AppDbContext();
    var s = db.Sprints.FirstOrDefault(sprint => sprint.Id == id);

    if (s != null) {
      TBoxProjectName.Text = s.Name;
      TBoxDescription.Text = s.Goal;
      ComboBoxStatus.SelectedItem = s.Status.ToString();

      DateTimePicker.Value = DateTimePicker.MinDate = s.StartDate;
      NumericSprintLength.Value = (int)((s.EndDate - s.StartDate)?.TotalDays / 7);

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
    if (term == searchPlaceholder || string.IsNullOrEmpty(term)) {
      LoadSprints();
      return;
    }

    if (ComboBoxProjects.SelectedValue == null) return;
    int projectId = (int)ComboBoxProjects.SelectedValue;

    using var db = new AppDbContext();
    DGVSprints.DataSource = db.Sprints
        .Where(s => s.ProjectId == projectId && s.Name.Contains(term))
        .Select(s => new { s.Id, Naziv = s.Name, s.Status, Početak = s.StartDate, Kraj = s.EndDate })
        .OrderByDescending(s => s.Početak)
        .ToList();
  }

  private void DateTimePicker_ValueChanged(object sender, EventArgs e) {
    if (DateTimePicker.Value.Date <= DateTime.Now.Date) {
      ComboBoxStatus.SelectedItem = SprintStatus.Active.ToString();
    }
    else {
      ComboBoxStatus.SelectedItem = SprintStatus.Planned.ToString();
    }
  }

  private void ComboBoxStatus_SelectedIndexChanged(object sender, EventArgs e) {

  }
}