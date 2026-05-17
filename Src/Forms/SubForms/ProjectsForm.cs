using Sprintra.Src;
using Sprintra.Src.Data;
using Sprintra.Src.Data.Models;
using Sprintra.Src.Forms;
using Sprintra.Src.Services;
using System.Data;

namespace Sprintra.Forms;

public partial class ProjectsForm : BaseForm {
  private bool dateChanged = false;

  public ProjectsForm(BaseForm parent) {
    InitializeComponent();
    this.parent = parent;

    RightSidePanel = PanelRightContent;
    if (!PermissionsService.CanCurrentUserManageForm(GetType())) {
      DisableRightPanelAndControls(ButtonDelete, ButtonAdd);
    }
  }

  private void ProjectsForm_Load(object sender, EventArgs e) {
    ComboBoxStatus.Items.AddRange(Enum.GetNames<ProjectStatus>());

    LoadProjects();
    TBoxSearch.SetPlaceholder(searchPlaceholder);
  }

  private void ButtonProjectAdd_Click(object sender, EventArgs e) {
    ClearInputs();
    ExpandParent();
  }

  private void ButtonProjectDelete_Click(object sender, EventArgs e) {
    if (SelectedDataGridViewItemId == 0) {
      MessageBox.Show("Molimo vas da prvo odaberete projekat iz tabele.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      return;
    }

    using var db = new AppDbContext();
    var count = db.Sprints.Count(s => s.ProjectId == SelectedDataGridViewItemId);

    if (count > 0) {
      MessageBox.Show($"Projekat koji sadrži sprintove ({count}) ne može biti obrisan.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      return;
    }

    var result = MessageBox.Show($"Da li ste sigurni da želite da obrišete projekat '{TBoxProjectName.Text}'?",
                                 "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

    if (result == DialogResult.Yes) {
      try {
        var project = db.Projects.FirstOrDefault(p => p.Id == SelectedDataGridViewItemId);

        if (project != null) {
          db.Projects.Remove(project);
          db.SaveChanges();

          ClearInputs();
          LoadProjects();

          if (isExpanded) {
            parent.Width -= expandedPanelWidth;
            PanelRightContent.Hide();
            isExpanded = false;
          }
        }
      }
      catch (Exception ex) {
        MessageBox.Show($"Greška pri brisanju: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
  }

  private void ButtonSave_Click(object sender, EventArgs e) {
    string name = TBoxProjectName.Text.Trim();
    string description = TBoxDescription.Text.Trim();
    string status = ComboBoxStatus.SelectedItem?.ToString() ?? "Active";

    if (string.IsNullOrEmpty(name)) {
      MessageBox.Show("Naziv projekta je obavezan.", "Validacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      return;
    }

    try {
      using var db = new AppDbContext();
      Project? project = null;

      if (SelectedDataGridViewItemId == 0) {
        project = new Project {
          StartDate = DateTimePicker.Value
        };
        db.Projects.Add(project);
      }
      else {
        project = db.Projects.FirstOrDefault(p => p.Id == SelectedDataGridViewItemId);
        if (project == null) {
          return;
        }
        if (dateChanged) {
          project.EndDate = DateTimePicker.Value;
        }
      }

      project.Name = name;
      project.Description = description;
      project.Status = Enum.Parse<ProjectStatus>(status);

      db.SaveChanges();

      ClearInputs();
      LoadProjects();
    }
    catch (Exception ex) {
      MessageBox.Show($"Greška: {ex.Message}", "Sistemska greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }

  private void DGVProjects_CellClick(object sender, DataGridViewCellEventArgs e) {
    var isValid = e.RowIndex >= 0 && DGVProjects.Rows[e.RowIndex].Cells["Id"].Value != null;
    if (isValid) {
      SelectedDataGridViewItemId = Convert.ToInt32(DGVProjects.Rows[e.RowIndex].Cells["Id"].Value);
      LoadProjectToInputs(SelectedDataGridViewItemId);
      ExpandParent();
      LabelDate.Text = "Datum završetka";
    }
  }

  private void LoadProjects() {
    using var db = new AppDbContext();
    var projects = db.Projects
        .Select(p => new {
          p.Id,
          Naziv = p.Name,
          p.Status,
          Početak = p.StartDate,
          Kraj = p.EndDate
        })
        .OrderByDescending(p => p.Kraj).ThenByDescending(p => p.Početak)
        .ToList();

    DGVProjects.DataSource = projects;
    DGVProjects.Columns["Id"]?.Visible = false;
  }

  private void LoadProjectToInputs(int id) {
    using var db = new AppDbContext();
    var p = db.Projects.FirstOrDefault(project => project.Id == id);

    if (p != null) {
      TBoxProjectName.Text = p.Name;
      TBoxDescription.Text = p.Description;
      ComboBoxStatus.SelectedItem = p.Status;

      DateTime targetDate = p.EndDate ?? (p.StartDate > DateTime.Now ? p.StartDate : DateTime.Now);

      if (targetDate < DateTimePicker.MinDate) targetDate = DateTimePicker.MinDate;
      if (targetDate > DateTimePicker.MaxDate) targetDate = DateTimePicker.MaxDate;

      DateTimePicker.Value = targetDate;

      DateTimePicker.MinDate = DateTimePicker.Value;
      dateChanged = false;

      bigLabel2.Text = "Izmena projekta";
    }
  }

  private void TBoxSearch_TextChanged(object sender, EventArgs e) {
    string term = TBoxSearch.Text.Trim();
    if (term == searchPlaceholder || string.IsNullOrEmpty(term)) {
      LoadProjects();
      return;
    }

    using var db = new AppDbContext();
    DGVProjects.DataSource = db.Projects
        .Where(p => p.Name.Contains(term))
        .Select(p => new { p.Id, Naziv = p.Name, p.Status, Početak = p.StartDate })
        .ToList();
  }

  private void ClearInputs() {
    SelectedDataGridViewItemId = 0;
    TBoxProjectName.Text = "";
    TBoxDescription.Text = "";
    ComboBoxStatus.SelectedIndex = -1;
    DateTimePicker.Value = DateTimePicker.MinDate = DateTime.Now;
    dateChanged = false;
    bigLabel2.Text = "Novi Projekat";
    LabelDate.Text = "Datum početka";
  }

  private void DateTimePicker_ValueChanged(object sender, EventArgs e) {
    dateChanged = true;
    if (DateTimePicker.Value.Date <= DateTime.Now.Date) {
      ComboBoxStatus.SelectedItem = ProjectStatus.Active.ToString();
    }
    else {
      ComboBoxStatus.SelectedItem = ProjectStatus.Planned.ToString();
    }
  }

  private void ComboBoxStatus_SelectedIndexChanged(object sender, EventArgs e) {
    var value = ComboBoxStatus.SelectedItem?.ToString();
    if (value == null) {
      return;
    }

    var projectStatus = Enum.Parse<ProjectStatus>(value);

    if (projectStatus == ProjectStatus.Active && DateTimePicker.Value.Date > DateTime.Now.Date) {
      MessageBox.Show("Projekat ne može biti aktivan ako je datum početka u budućnosti.",
                      "Nevalidan status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      ComboBoxStatus.SelectedItem = ProjectStatus.Planned.ToString();
      return;
    }

    if (projectStatus == ProjectStatus.Completed) {
      if (SelectedDataGridViewItemId == 0) {
        MessageBox.Show("Projekat ne može biti completed ako nije ni kreiran.",
                      "Nevalidan status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        ComboBoxStatus.SelectedItem = ProjectStatus.Planned.ToString();
        return;
      }

      var result = MessageBox.Show("Da li ste sigurni da želite da označite projekat kao završen?",
                                     "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (result == DialogResult.Yes) {
        DateTimePicker.Value = DateTime.Now;
        LabelDate.Text = "Datum završetka";
      }
      else {
        ComboBoxStatus.SelectedItem = ProjectStatus.Active.ToString();
      }

      return;
    }

    if (projectStatus == ProjectStatus.Active && LabelDate.Text == "Datum završetka") {
      LabelDate.Text = "Datum početka";
    }
  }
}