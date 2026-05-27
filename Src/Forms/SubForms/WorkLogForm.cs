using Microsoft.EntityFrameworkCore;
using Sprintly.Src;
using Sprintly.Src.Data;
using Sprintly.Src.Data.Models;
using Sprintly.Src.Forms;
using Sprintly.Src.Services;
using Sprintly.Src.Services.Forms;
using System.ComponentModel;
using System.Data;

namespace Sprintly.Forms;

public partial class WorkLogForm : BaseForm {
  private readonly WorkTasksService workTasksService;
  private readonly SprintsService sprintsService;
  private readonly UserStoriesService userStoriesService;

  const int hoursStep = 1;
  const int minutesStep = 5;

  private int hours;
  private int minutes;

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public int Hours {
    get {
      return hours;
    }
    set {
      if (value < 0) {
        value = 0;
      }
      hours = value;
      LabelHours.Text = hours.ToString();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public int Minutes {
    get {
      return minutes;
    }
    set {
      if (value < 0) {
        value = 0;
      }
      if (value >= 60) {
        value -= 60;
        Hours += hoursStep;
      }

      minutes = value;
      LabelMinutes.Text = $"{(minutes.ToString().Length == 1 ? "0" : "")}{minutes}";
    }
  }


  public WorkLogForm(BaseForm parent) {
    InitializeComponent();
    this.parent = parent;

    workTasksService = new WorkTasksService();
    sprintsService = new SprintsService();
    userStoriesService = new UserStoriesService();

    RightSidePanel = PanelRightContent;
    if (!PermissionsService.CanCurrentUserManageForm(GetType())) {
      DisableRightPanelAndControls();
    }
  }

  private void WorkTasksForm_Load(object sender, EventArgs e) {
    TBoxSearch.SetPlaceholder(searchPlaceholder);
    LoadProjectsToFilter();
    ComboBoxProjects_SelectedIndexChanged(sender, e);
  }

  private void LoadProjectsToFilter() {
    using var db = new AppDbContext();
    var username = SessionManager.GetSavedUsername();
    var projects = db.Projects
        .Where(p => p.Sprints
            .SelectMany(s => s.WorkTasks)
            .Any(wt => wt.AssignedEmployees.Any(e => e.Username == username)))
        .OrderBy(p => p.Name)
        .ToList();

    ComboBoxProjects.DataSource = projects;
    ComboBoxProjects.DisplayMember = "Name";
    ComboBoxProjects.ValueMember = "Id";
    ComboBoxProjects.SelectedIndex = projects.Count > 0 ? 0 : -1;
  }

  private async void ComboBoxProjects_SelectedIndexChanged(object sender, EventArgs e) {
    if (ComboBoxProjects.SelectedValue is int projectId) {
      await LoadSprintsToComboBox(projectId);
      await LoadUserStoriesToFilters(projectId);
      await LoadWorkTasksToDataGrid();
    }
  }

  private async Task LoadSprintsToComboBox(int projectId) {
    using var db = new AppDbContext();
    var username = SessionManager.GetSavedUsername();
    var sprints = await db.Sprints
        .Where(s => s.ProjectId == projectId && s.WorkTasks.Any(wt => wt.AssignedEmployees.Any(e => e.Username == username)))
        .OrderBy(s => s.Name)
        .ToListAsync();

    sprints.Insert(0, new Sprint { Id = 0, Name = "-- Svi sprintovi --" });

    ComboBoxSprints.DataSource = sprints;
    ComboBoxSprints.DisplayMember = "Name";
    ComboBoxSprints.ValueMember = "Id";
    ComboBoxSprints.SelectedIndex = 0;
  }

  private async Task LoadUserStoriesToFilters(int projectId) {
    var userStories = await userStoriesService.GetByProjectAsync(projectId);
  }

  private async Task LoadWorkTasksToDataGrid(string term = "") {
    if (ComboBoxProjects.SelectedValue is not int projectId) return;

    int? sprintIdFilter = null;
    if (ComboBoxSprints.SelectedValue is int sId && sId > 0) {
      sprintIdFilter = sId;
    }

    using var db = new AppDbContext();
    var username = SessionManager.GetSavedUsername();
    var employee = await db.Employees.FirstOrDefaultAsync(e => e.Username == username);
    var tasks = await workTasksService.GetTasksAsync(projectId, sprintIdFilter, term, employee?.Id);

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
    try {
      if (SelectedDataGridViewItemId == -1) {
        throw new Exception("Nije odabran nijedan radni zadatak.");
      }

      if (AuthService.CurrentUser == null) {
        throw new Exception("Nije pronađen trenutno prijavljeni korisnik.");
      }

      decimal hoursWorked = 0m;
      if (Hours < 0 || Minutes < 0) {
        throw new Exception("Sati i minuti ne mogu biti negativni.");
      }
      hoursWorked = Hours + (Minutes / 60m);

      var workLogEntry = new WorkTaskEntry {
        WorkTaskId = SelectedDataGridViewItemId,
        EmployeeId = AuthService.CurrentUser.Id,
        HoursWorked = hoursWorked
      };

      using var db = new AppDbContext();
      db.SaveChanges();

      Helpers.ShowToast("Rad uspešno unesen.", NotificationType.Success);
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
      bigLabel2.Text = "Izmena radnog zadatka";
    }
  }

  private void ClearInputs() {
    SelectedDataGridViewItemId = 0;
    bigLabel2.Text = "Novi radni zadatak";
  }

  private async void TBoxSearch_TextChanged(object sender, EventArgs e) {
    string term = TBoxSearch.Text.Trim();
    if (term == searchPlaceholder || string.IsNullOrEmpty(term)) {
      await LoadWorkTasksToDataGrid("");
      return;
    }
    await LoadWorkTasksToDataGrid(term);
  }

  private async void ComboBoxSprints_SelectedIndexChanged(object sender, EventArgs e) {
    await LoadWorkTasksToDataGrid();
  }

  private async void DGV_CellClick(object sender, DataGridViewCellEventArgs e) {
    if (e.RowIndex >= 0 && DGV.Rows[e.RowIndex].Cells["Id"].Value != null) {
      SelectedDataGridViewItemId = Convert.ToInt32(DGV.Rows[e.RowIndex].Cells["Id"].Value);
      await LoadWorkTaskToInputs(SelectedDataGridViewItemId);
      ExpandParent();
    }
  }

  private void ButtonHoursUp_Click(object sender, EventArgs e) {
    Hours += hoursStep;
  }

  private void ButtonMinutesUp_Click(object sender, EventArgs e) {
    Minutes += minutesStep;
  }

  private void ButtonHoursDown_Click(object sender, EventArgs e) {
    Hours -= hoursStep;
  }

  private void ButtonMinutesDown_Click(object sender, EventArgs e) {
    Minutes -= minutesStep;
  }
}