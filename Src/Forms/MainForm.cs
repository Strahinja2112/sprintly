using Sprintly.Src.Data;
using Sprintly.Src.Data.Models;
using Sprintly.Src.Forms;
using Sprintly.Src.Services;

namespace Sprintly.Forms;

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

    LabelSprints.Click += PanelSprints_Click!;
    LabelWorkLog.Click += PanelWorkLog_Click!;
    LabelProjects.Click += PanelProjects_Click!;
    LabelEmployees.Click += PanelEmployees_Click!;
    LabelUserStories.Click += PanelUserStories_Click!;
    LabelWorkTasks.Click += PanelWorkTasks_Click!;

    if (AuthService.CurrentUser.Type != EmployeeType.Developer && AuthService.CurrentUser.Type != EmployeeType.Admin) {
      PanelWorkLog.Hide();
    }

    LabelUserName.Text = "@" + AuthService.CurrentUser.Username;
    LabelUserType.Text = AuthService.CurrentUser.Type.ToString();
  }

  private void ButtonLogout_Click(object sender, EventArgs e) {
    AuthService.Logout();
    Program.HasUserLoggedOut = true;
    Close();
  }

  private void PanelEmployees_Click(object sender, EventArgs e) {
    OpenSubform(PanelMainContent, new EmployeesForm(this));
  }

  private void PanelSprints_Click(object sender, EventArgs e) {
    OpenSubform(PanelMainContent, new SprintsForm(this));
  }

  private void PanelProjects_Click(object sender, EventArgs e) {
    OpenSubform(PanelMainContent, new ProjectsForm(this));
  }

  private void PanelWorkLog_Click(object sender, EventArgs e) {
    OpenSubform(PanelMainContent, new WorkLogForm(this));
  }

  private void PanelUserStories_Click(object sender, EventArgs e) {
    OpenSubform(PanelMainContent, new UserStoriesForm(this));
  }

  private void PanelWorkTasks_Click(object sender, EventArgs e) {
    OpenSubform(PanelMainContent, new WorkTasksForm(this));
  }

  private void PanelUserData_Paint(object sender, PaintEventArgs e) {

  }
}
