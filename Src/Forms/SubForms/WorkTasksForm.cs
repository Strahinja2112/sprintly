using Sprintra.Src;
using Sprintra.Src.Data;
using Sprintra.Src.Data.Models;
using Sprintra.Src.Forms;
using Sprintra.Src.Services;
using Sprintra.Src.Services.Forms;
using System.Data;

namespace Sprintra.Forms;

public partial class WorkTasksForm : BaseForm {
  private readonly WorkTasksService workTasksService;
  private readonly SprintsService sprintsService;
  private readonly UserStoriesService userStoriesService;

  private AssignTasksToUsersForm assignTasksToUsersForm;

  public WorkTasksForm(BaseForm parent) {
    InitializeComponent();
    this.parent = parent;

    assignTasksToUsersForm = new(this);
    assignTasksToUsersForm.FormClosed += async (s, args) => {
      Helpers.ShowToast("Zatvoreno dodeljivanje korisnika!", NotificationType.Info);
      CollapseParent();
    };

    workTasksService = new WorkTasksService();
    sprintsService = new SprintsService();
    userStoriesService = new UserStoriesService();

    RightSidePanel = PanelRightContent;
    if (!PermissionsService.CanCurrentUserManageForm(GetType())) {
      DisableRightPanelAndControls(ButtonDelete, ButtonAdd);
    }
  }

  private void WorkTasksForm_Load(object sender, EventArgs e) {
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
    if (ComboBoxProjects.SelectedValue is int projectId) {
      await LoadSprintsToFilters(projectId);
      await LoadUserStoriesToFilters(projectId);
      await LoadWorkTasksToDataGrid();
    }
  }

  private async Task LoadUserStoriesToFilters(int projectId) {
    var userStories = await userStoriesService.GetByProjectAsync(projectId);

    ComboBoxUserStories.DataSource = userStories;

    ComboBoxUserStories.DisplayMember = "Title";
    ComboBoxUserStories.ValueMember = "Id";

    // TODO: OVO BACA GRESKU POPRAVI TO NE BUDI GLUP
    //ComboBoxUserStories.SelectedIndex = userStories.Count > 0 ? 0 : -1;
  }

  private async Task LoadSprintsToFilters(int projectId) {
    var sprints = await sprintsService.GetSprintsForProject(projectId);

    sprints.Insert(0, new() {
      Id = 0,
      Name = "-- Svi sprintovi --"
    });

    ComboBoxSprints.DataSource = sprints;

    ComboBoxSprints.DisplayMember = "Name";
    ComboBoxSprints.ValueMember = "Id";

    ComboBoxSprints.SelectedIndex = 0;
  }

  private async Task LoadWorkTasksToDataGrid(string term = "") {
    if (ComboBoxProjects.SelectedValue is not int projectId) return;

    int? sprintIdFilter = null;
    if (ComboBoxSprints.SelectedValue is int sId && sId > 0) {
      sprintIdFilter = sId;
    }

    var tasks = await workTasksService.GetTasksAsync(projectId, sprintIdFilter, term);

    DGV.DataSource = tasks.Select(t => new {
      t.Id,
      Zadatak = t.Name,
      Priča = t.UserStory?.Title,
      Status = t.Status.ToString(),
      Sati = t.EstimatedHours,
      PreostaliSati = t.EstimatedHours - 12
    }).ToList();

    DGV.Columns["Id"]?.Visible = false;
    DGV.Columns["Zadatak"]?.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
  }

  private void ButtonAdd_Click(object sender, EventArgs e) {
    if (ComboBoxProjects.SelectedIndex == -1) {
      Helpers.ShowToast("Molimo vas da prvo odaberete projekat na vrhu.", NotificationType.Warning);
      return;
    }

    ClearInputs();
    ExpandParent();
  }

  private async void ButtonSave_Click(object sender, EventArgs e) {
    string name = TBoxName.Text.Trim();
    string desc = TBoxDescription.Text.Trim();

    if (string.IsNullOrEmpty(name)) {
      Helpers.ShowToast("Ime zadatka je obavezno.", NotificationType.Warning);
      return;
    }

    if (ComboBoxUserStories.SelectedValue is not int storyId) {
      Helpers.ShowToast("Zadatak mora pripadati korisničkoj priči.", NotificationType.Warning);
      return;
    }

    if (ComboBoxSprints.SelectedValue is not int sprintId || sprintId <= 0) {
      Helpers.ShowToast("Zadatak mora pripadati sprintu.", NotificationType.Warning);
      return;
    }

    var sprint = await sprintsService.GetByIdAsync(sprintId);
    if (sprint?.Status == SprintStatus.Completed) {
      Helpers.ShowToast("Ne možete dodati zadatak u sprint koji je završen.", NotificationType.Error);
      return;
    }

    try {
      WorkTask task = selectedDataGridViewItemId == 0
          ? new WorkTask()
          : await workTasksService.GetByIdAsync(selectedDataGridViewItemId) ?? new WorkTask();

      task.Name = name;
      task.Description = desc;
      task.EstimatedHours = NumericHours.Value;
      task.UserStoryId = storyId;
      task.Status = WorkTaskStatus.ToDo;
      task.SprintId = sprintId > 0 ? sprintId : null;

      await workTasksService.SaveTaskAsync(task);

      Helpers.ShowToast("Zadatak uspešno sačuvan.", NotificationType.Success);
      ClearInputs();
      await LoadWorkTasksToDataGrid();
    }
    catch (Exception ex) {
      Helpers.ShowToast($"Greška: {ex.Message}", NotificationType.Error);
    }
  }

  private async Task LoadWorkTaskToInputs(int id) {
    var task = await workTasksService.GetByIdAsync(id);
    if (task != null) {
      TBoxName.Text = task.Name;
      TBoxDescription.Text = task.Description;
      NumericHours.Value = (long)task.EstimatedHours;

      bigLabel2.Text = "Izmena radnog zadatka";
    }
  }

  private void ClearInputs() {
    selectedDataGridViewItemId = 0;
    TBoxName.Text = "";
    TBoxDescription.Text = "";
    NumericHours.Value = 0;
    bigLabel2.Text = "Novi radni zadatak";
  }

  private async void TBoxSearch_TextChanged(object sender, EventArgs e) {
    string term = TBoxSearch.Text.Trim();
    await LoadWorkTasksToDataGrid(term == searchPlaceholder || string.IsNullOrEmpty(term) ? "" : term);
  }

  private async void ComboBoxSprints_SelectedIndexChanged(object sender, EventArgs e) {
    await LoadWorkTasksToDataGrid();
  }

  private async void DGV_CellClick(object sender, DataGridViewCellEventArgs e) {
    if (e.RowIndex >= 0 && DGV.Rows[e.RowIndex].Cells["Id"].Value != null) {
      selectedDataGridViewItemId = Convert.ToInt32(DGV.Rows[e.RowIndex].Cells["Id"].Value);
      await LoadWorkTaskToInputs(selectedDataGridViewItemId);
      ExpandParent();
    }
  }

  private void ButonAdd_Click(object sender, EventArgs e) {
    ClearInputs();
    ExpandParent();
  }

  private void ButtonAddUsersToWorkTask_Click(object sender, EventArgs e) {
    if (RightSidePanel == null) {
      return;
    }

    OpenSubform(RightSidePanel, assignTasksToUsersForm);
  }
}