using Sprintly.Src;
using Sprintly.Src.Data;
using Sprintly.Src.Data.Models;
using Sprintly.Src.Forms;
using Sprintly.Src.Services;
using Sprintly.Src.Services.Forms;
using System.Data;

namespace Sprintly.Forms;

public partial class UserStoriesForm : BaseForm {
  private readonly UserStoriesService userStoriesService;

  public UserStoriesForm(BaseForm parent) {
    InitializeComponent();
    this.parent = parent;

    userStoriesService = new UserStoriesService();

    SidePanel = PanelRightContent;
    if (!PermissionsService.CanCurrentUserManageForm(GetType())) {
      DisableRightPanelAndControls(ButtonDelete, ButtonAdd);
    }
  }

  private void UserStoriesForm_Load(object sender, EventArgs e) {
    TBoxSearch.SetPlaceholder(searchPlaceholder);
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
    if (ComboBoxProjects.SelectedValue is int) {
      await LoadUserStoriesToDataGrid();
    }
  }

  private async Task LoadUserStoriesToDataGrid(string term = "") {
    if (ComboBoxProjects.SelectedValue is not int projectId) return;

    var stories = await userStoriesService.GetByProjectAsync(projectId, term);

    DGVSprints.DataSource = stories.Select(us => new {
      us.Id,
      Naslov = us.Title,
      Opis = us.Description,
      Prioritet = us.Priority,
    }).ToList();

    DGVSprints.Columns["Id"]?.Visible = false;

    var lastColumn = DGVSprints.Columns["Prioritet"];
    if (lastColumn != null) {
      lastColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
      lastColumn.Width = 50;
      lastColumn.Resizable = DataGridViewTriState.False;
    }
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
      UserStory story = SelectedDataGridViewItemId == 0
          ? new UserStory { ProjectId = (int)ComboBoxProjects.SelectedValue }
          : await userStoriesService.GetByIdAsync(SelectedDataGridViewItemId) ?? new UserStory();

      story.Title = name;
      story.Description = desc;
      story.Priority = (int)NumericPriority.Value;

      await userStoriesService.SaveUserStoryAsync(story);

      ClearInputs();
      await LoadUserStoriesToDataGrid();
    }
    catch (Exception ex) {
      MessageBox.Show($"Došlo je do greške: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }

  private async void ButtonDelete_Click(object sender, EventArgs e) {
    if (SelectedDataGridViewItemId == 0) {
      MessageBox.Show("Molimo vas da prvo odaberete korisničku priču iz tabele.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      return;
    }

    var result = MessageBox.Show($"Da li ste sigurni da želite da obrišete korisničku priču '{TBoxName.Text}'?",
                                 "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

    if (result == DialogResult.No) return;

    try {
      await userStoriesService.DeleteUserStoryAsync(SelectedDataGridViewItemId);

      ClearInputs();
      await LoadUserStoriesToDataGrid();

      if (isExpanded) {
        parent.Width -= expandedPanelWidth;
        PanelRightContent.Hide();
        isExpanded = false;
      }

      Helpers.ShowToast("Korisnička priča je uspešno obrisana.", NotificationType.Info, "Uspeh!");
    }
    catch (Exception ex) {
      MessageBox.Show(ex.Message, "Brisanje nije dozvoljeno", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
  }

  private async void DGVSprints_CellClick(object sender, DataGridViewCellEventArgs e) {
    if (e.RowIndex >= 0 && DGVSprints.Rows[e.RowIndex].Cells["Id"].Value != null) {
      SelectedDataGridViewItemId = Convert.ToInt32(DGVSprints.Rows[e.RowIndex].Cells["Id"].Value);
      await LoadUserStoryToInputs(SelectedDataGridViewItemId);
      ExpandParent();
    }
  }

  private async Task LoadUserStoryToInputs(int id) {
    var story = await userStoriesService.GetByIdAsync(id);
    if (story != null) {
      TBoxName.Text = story.Title;
      TBoxDescription.Text = story.Description;
      NumericPriority.Value = story.Priority;
      bigLabel2.Text = "Izmena korisničke priče";
    }
  }

  private void ClearInputs() {
    SelectedDataGridViewItemId = 0;
    TBoxName.Text = "";
    TBoxDescription.Text = "";
    NumericPriority.Value = 1;
    bigLabel2.Text = "Nova korisnička priča";
  }
  private async void TBoxSearch_TextChanged(object sender, EventArgs e) {
    string term = TBoxSearch.Text.Trim();
    if (term == searchPlaceholder || string.IsNullOrEmpty(term)) {
      await LoadUserStoriesToDataGrid("");
      return;
    }
    await LoadUserStoriesToDataGrid(term);
  }
}
