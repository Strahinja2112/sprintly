using Sprintra.Src.Data;
using Sprintra.Src.Forms;
using Sprintra.Src.Services;

namespace Sprintra.Forms;

public partial class MainForm : BaseForm {
  public MainForm() {
    InitializeComponent();
  }

  private void MainForm_Load(object sender, EventArgs e) {
    if (AuthService.CurrentUser == null) {
      Close();
      return;
    }

    using (var db = new AppDbContext()) {
      var sprintsCount = db.Sprints.Count();
      var projectsCount = db.Projects.Count();
      var employeesCount = db.Employees.Count();

      LabelSprintsCount.Text = sprintsCount.ToString();
      LabelProjectsCount.Text = projectsCount.ToString();
      LabelEmployeesCount.Text = employeesCount.ToString();
    }

    LabelSprints.Click += PanelSprints_Click;
    LabelWorkLog.Click += PanelWorkLog_Click;
    LabelProjects.Click += PanelProjects_Click;
    LabelEmployees.Click += PanelEmployees_Click;
    LabelUserStories.Click += PanelUserStories_Click;
    LabelWorkTasks.Click += PanelWorkTasks_Click;

    //if (!PermissionsService.CanLogWork()) {
    //  PanelWorkLog.Hide();
    //}
    //if (!PermissionsService.CanManageProjects()) {
    //  PanelProjects.Hide();
    //}
    //if (!PermissionsService.CanManageUsers()) {
    //  PanelEmployees.Hide();
    //}
    //if (!PermissionsService.CanManageSprints()) {
    //  PanelSprints.Hide();
    //}
    //if (!PermissionsService.CanManageUserStories()) {
    //  PanelUserStories.Hide();
    //}
    //if (!PermissionsService.CanManageWorkTasks()) {
    //  PanelWorkTasks.Hide();
    //}

    LabelUserName.Text = "@" + AuthService.CurrentUser.Username;
    LabelUserType.Text = AuthService.CurrentUser.Type.ToString();
  }

  private void ButtonLogout_Click(object sender, EventArgs e) {
    AuthService.Logout();
    Program.HasUserLoggedOut = true;
    Close();
  }

  private void PanelEmployees_Click(object sender, EventArgs e) {
    OpenChildForm(PanelMainContent, new EmployeesForm(this));
  }

  private void PanelSprints_Click(object sender, EventArgs e) {
    OpenChildForm(PanelMainContent, new SprintsForm(this));
  }

  private void PanelProjects_Click(object sender, EventArgs e) {
    OpenChildForm(PanelMainContent, new ProjectsForm(this));
  }

  private void PanelWorkLog_Click(object sender, EventArgs e) {
    OpenChildForm(PanelMainContent, new WorkLogForm(this));
  }

  private void PanelUserStories_Click(object sender, EventArgs e) {
    OpenChildForm(PanelMainContent, new UserStoriesForm(this));
  }

  private void PanelWorkTasks_Click(object sender, EventArgs e) {
    OpenChildForm(PanelMainContent, new WorkTasksForm(this));
  }

  private void PanelUserData_Paint(object sender, PaintEventArgs e) {

  }
}
