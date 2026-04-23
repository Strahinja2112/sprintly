using Sprintra.Data;
using Sprintra.Data.Models;
using System.Data;

namespace Sprintra.Forms;

public partial class ProjectsForm : BaseForm {
  private bool isExpanded = false;
  private readonly int expandedPanelWidth = 0;
  private readonly BaseForm parent;
  private int selectedProjectId = 0;
  private string searchPlaceholder = "Pretraga projekata...";

  public ProjectsForm(BaseForm parent) {
    InitializeComponent();
    expandedPanelWidth = PanelProjectData.Width;
    PanelProjectData.Hide();
    this.parent = parent;
  }

  private void ProjectsForm_Load(object sender, EventArgs e) {
    ComboBoxStatus.Items.AddRange(new string[] { "Active", "Completed", "On Hold", "Planned" });

    LoadProjects();
    SetPlaceholder(TBoxSearch, searchPlaceholder);
  }

  private void ButtonProjectAdd_Click(object sender, EventArgs e) {
    ClearInputs();
    ExpandParent();
  }

  private void ButtonProjectDelete_Click(object sender, EventArgs e) {
    if (selectedProjectId == 0) {
      MessageBox.Show("Molimo vas da prvo odaberete projekat iz tabele.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      return;
    }

    var result = MessageBox.Show($"Da li ste sigurni da želite da obrišete projekat '{TBoxProjectName.Text}'?",
                                 "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

    if (result == DialogResult.Yes) {
      try {
        using var db = new AppDbContext();
        var project = db.Projects.FirstOrDefault(p => p.Id == selectedProjectId);

        if (project != null) {
          db.Projects.Remove(project);
          db.SaveChanges();

          MessageBox.Show("Projekat je uspešno obrisan.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

          ClearInputs();
          LoadProjects();

          if (isExpanded) {
            parent.Width -= expandedPanelWidth;
            PanelProjectData.Hide();
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
      Project project;

      if (selectedProjectId == 0) {
        project = new Project { StartDate = DateTimePickerStart.Value };
        db.Projects.Add(project);
      }
      else {
        project = db.Projects.FirstOrDefault(p => p.Id == selectedProjectId);
        if (project == null) return;
      }

      project.Name = name;
      project.Description = description;
      project.Status = status;
      project.StartDate = DateTimePickerStart.Value;
      //project.EndDate = DateTimePickerEnd.Value; // Ako imaš EndDate

      db.SaveChanges();

      MessageBox.Show(selectedProjectId == 0 ? "Projekat kreiran!" : "Projekat ažuriran!", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

      ClearInputs();
      LoadProjects();
    }
    catch (Exception ex) {
      MessageBox.Show($"Greška: {ex.Message}", "Sistemska greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }

  private void DGVProjects_CellClick(object sender, DataGridViewCellEventArgs e) {
    if (e.RowIndex >= 0 && DGVProjects.Rows[e.RowIndex].Cells["Id"].Value != null) {
      selectedProjectId = Convert.ToInt32(DGVProjects.Rows[e.RowIndex].Cells["Id"].Value);
      LoadProjectToInputs(selectedProjectId);
      ExpandParent();
    }
  }

  private void LoadProjects() {
    using var db = new AppDbContext();
    var projects = db.Projects
        .Select(p => new {
          p.Id,
          Naziv = p.Name,
          Status = p.Status,
          Početak = p.StartDate
        })
        .OrderBy(p => p.Naziv)
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
      DateTimePickerStart.Value = p.StartDate;

      bigLabel2.Text = "Izmena Projekta: " + p.Name;
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
    selectedProjectId = 0;
    TBoxProjectName.Text = "";
    TBoxDescription.Text = "";
    ComboBoxStatus.SelectedIndex = -1;
    DateTimePickerStart.Value = DateTime.Now;
    bigLabel2.Text = "Novi Projekat";
  }

  private void ExpandParent() {
    if (!isExpanded) {
      parent.Width += expandedPanelWidth;
      PanelProjectData.Show();
      isExpanded = true;
    }
    parent.CenterOnScreen();
  }
}