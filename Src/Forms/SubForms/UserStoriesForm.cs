using Sprintra.Src.Data;
using Sprintra.Src.Data.Models;
using Sprintra.Src.Forms;
using Sprintra.Src.Services;
using System.Data;

namespace Sprintra.Forms;

public partial class UserStoriesForm : BaseForm {
  private bool isExpanded = false;

  private readonly int expandedPanelWidth = 0;
  private int selectedStoryId = 0;

  private readonly BaseForm parent;
  private readonly UserStoriesService userStoriesService;
  private readonly SprintsService sprintsService;

  private const string searchPlaceholder = "Pretraga korisničkih priča...";

  public UserStoriesForm(BaseForm parent) {
    InitializeComponent();

    userStoriesService = new UserStoriesService();
    sprintsService = new SprintsService();

    expandedPanelWidth = PanelEdit.Width;
    PanelEdit.Hide();
    this.parent = parent;
  }

  private void UserStoriesForm_Load(object sender, EventArgs e) {
    SetPlaceholder(TBoxSearch, searchPlaceholder);
    LoadProjectsToFilter();
    ComboBoxProjects_SelectedIndexChanged(sender, e);
  }

  private void LoadProjectsToFilter() {
    using var db = new AppDbContext();
    var projects = db.Projects.OrderBy(p => p.Name).ToList();

    ComboBoxProjects.DataSource = projects;
    ComboBoxProjects.DisplayMember = "Name";
    ComboBoxProjects.ValueMember = "Id";
    ComboBoxProjects.SelectedIndex = projects.Count > 0 ? 0 : -1;
  }

  private async void ComboBoxProjects_SelectedIndexChanged(object sender, EventArgs e) {
    if (ComboBoxProjects.SelectedValue is int projectId) {
      await LoadSprintsToFilters(projectId);
      await LoadUserStoriesToDataGrid();
    }
  }

  private async Task LoadSprintsToFilters(int projectId) {
    using var db = new AppDbContext();
    var sprints = await sprintsService.GetSprintsForProject(projectId);

    sprints.Insert(0, new Sprint { Id = 0, Name = "-- Bez sprinta --" });

    ComboBoxSprints.DataSource = sprints;
    ComboBoxSprintsForAdding.DataSource = sprints.ToList();
    ComboBoxSprints.DisplayMember = ComboBoxSprintsForAdding.DisplayMember = "Name";
    ComboBoxSprints.ValueMember = ComboBoxSprintsForAdding.ValueMember = "Id";
    ComboBoxSprints.SelectedIndex = ComboBoxSprints.SelectedIndex = 0;
  }

  private async Task LoadUserStoriesToDataGrid(string term = "") {
    if (ComboBoxProjects.SelectedValue is not int projectId) return;

    var stories = await userStoriesService.GetByProjectAsync(projectId, term);

    DGVSprints.DataSource = stories.Select(us => new {
      us.Id,
      Naslov = us.Title,
      Opis = us.Description,
      Prioritet = us.Priority,
      Sprint = us.Sprint != null ? us.Sprint.Name : "Backlog"
    }).ToList();

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

  private async void ButtonSave_Click(object sender, EventArgs e) {
    string name = TBoxName.Text.Trim();
    string desc = TBoxDescription.Text.Trim();

    if (string.IsNullOrEmpty(name)) {
      MessageBox.Show("Ime korisničke priče je obavezno.", "Validacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      return;
    }

    try {
      UserStory story = selectedStoryId == 0
          ? new UserStory { ProjectId = (int)ComboBoxProjects.SelectedValue }
          : await userStoriesService.GetByIdAsync(selectedStoryId) ?? new UserStory();

      story.Title = name;
      story.Description = desc;
      story.Priority = (int)NumericPriority.Value;

      if (ComboBoxSprintsForAdding.SelectedValue is int sprintId) {
        story.SprintId = sprintId > 0 ? sprintId : null;
      }

      await userStoriesService.SaveUserStoryAsync(story);

      ClearInputs();
      await LoadUserStoriesToDataGrid();
    }
    catch (Exception ex) {
      MessageBox.Show($"Došlo je do greške: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }
  private async void DGVSprints_CellClick(object sender, DataGridViewCellEventArgs e) {
    if (e.RowIndex >= 0 && DGVSprints.Rows[e.RowIndex].Cells["Id"].Value != null) {
      selectedStoryId = Convert.ToInt32(DGVSprints.Rows[e.RowIndex].Cells["Id"].Value);
      await LoadUserStoryToInputs(selectedStoryId);
      ExpandParent();
    }
  }

  private async Task LoadUserStoryToInputs(int id) {
    var story = await userStoriesService.GetByIdAsync(id);
    if (story != null) {
      TBoxName.Text = story.Title;
      TBoxDescription.Text = story.Description;
      NumericPriority.Value = story.Priority;
      ComboBoxSprints.SelectedValue = story.SprintId ?? 0;
      bigLabel2.Text = "Izmena korisničke priče";
    }
  }

  private void ClearInputs() {
    selectedStoryId = 0;
    TBoxName.Text = "";
    TBoxDescription.Text = "";
    NumericPriority.Value = 1;
    ComboBoxSprints.SelectedIndex = 0;
    bigLabel2.Text = "Nova korisnička priča";
  }

  private void ExpandParent() {
    if (!isExpanded) {
      parent.Width += expandedPanelWidth;
      PanelEdit.Show();
      isExpanded = true;
    }
    parent.CenterOnScreen();
  }

  private async void TBoxSearch_TextChanged(object sender, EventArgs e) {
    string term = TBoxSearch.Text.Trim();
    if (term == searchPlaceholder || string.IsNullOrEmpty(term)) {
      await LoadUserStoriesToDataGrid("");
      return;
    }
    await LoadUserStoriesToDataGrid(term);
  }

  private async void ComboBoxSprints_SelectedIndexChanged(object sender, EventArgs e) {
    if (ComboBoxSprints.SelectedValue is not int sprintId) return;
    if (ComboBoxProjects.SelectedValue is not int projectId) return;

    var stories = await userStoriesService.GetByProjectAsync(
      projectId, TBoxName.Text, sprintId > 0 ? sprintId : null
    );

    DGVSprints.DataSource = stories.Select(us => new {
      us.Id,
      Naslov = us.Title,
      Opis = us.Description,
      Prioritet = us.Priority,
      Sprint = us.Sprint?.Name ?? "Backlog"
    }).ToList();

    DGVSprints.Columns["Id"]?.Visible = false;
  }

  private void ButtonAddToSprint_Click(object sender, EventArgs e) {

  }
}