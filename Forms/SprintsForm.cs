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
    expandedPanelWidth = PanelProjectData.Width;
    PanelProjectData.Hide();
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
    ComboBoxProjects.SelectedIndex = -1; // Ništa nije selektovano na početku
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
    if (DGVSprints.Columns["Id"] != null) DGVSprints.Columns["Id"].Visible = false;
  }

  private void ButonAdd_Click(object sender, EventArgs e) {
    if (ComboBoxProjects.SelectedIndex == -1) {
      MessageBox.Show("Molimo vas da prvo odaberete projekat na vrhu.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
      return;
    }
    ClearInputs();
    ExpandParent();
  }

  private void ButtonSave_Click(object sender, EventArgs e) {
    string name = TBoxProjectName.Text.Trim(); // Tvoje ime iz dizajnera za ime sprinta
    string goal = TBoxDescription.Text.Trim(); // Tvoje ime iz dizajnera za cilj sprinta

    if (string.IsNullOrEmpty(name)) {
      MessageBox.Show("Ime sprinta je obavezno.", "Validacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      return;
    }

    try {
      using var db = new AppDbContext();
      Sprint sprint;

      if (selectedSprintId == 0) {
        sprint = new Sprint {
          ProjectId = (int)ComboBoxProjects.SelectedValue,
          Status = SprintStatus.Planned // Default
        };
        db.Sprints.Add(sprint);
      }
      else {
        sprint = db.Sprints.FirstOrDefault(s => s.Id == selectedSprintId);
        if (sprint == null) return;
      }

      sprint.Name = name;
      sprint.Goal = goal;
      sprint.StartDate = DateTimePicker.Value;
      // Ako u modelu imaš EndDate, dodaj logiku za trajanje (npr. +14 dana)
      sprint.EndDate = DateTimePicker.Value.AddDays(14);

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
      DateTimePicker.Value = s.StartDate;

      bigLabel2.Text = "Izmena: " + s.Name;
    }
  }

  private void ClearInputs() {
    selectedSprintId = 0;
    TBoxProjectName.Text = "";
    TBoxDescription.Text = "";
    ComboBoxStatus.SelectedIndex = -1;
    DateTimePicker.Value = DateTime.Now;
    bigLabel2.Text = "Novi Sprint";
  }

  private void ExpandParent() {
    if (!isExpanded) {
      parent.Width += expandedPanelWidth;
      PanelProjectData.Show();
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
        .Select(s => new { s.Id, Naziv = s.Name, s.Status, Početak = s.StartDate })
        .ToList();
  }
}