using Sprintra.Services;

namespace Sprintra.Forms;

public partial class MainForm : Form {
  public MainForm() {
    InitializeComponent();
  }

  private void MainForm_Load(object sender, EventArgs e) {
    if (AuthService.CurrentUser == null) {
      Close();
      return;
    }

    LabelSprints.Click += PanelSprints_Click;
    LabelWorkLog.Click += PanelWorkLog_Click;
    LabelProjects.Click += PanelProjects_Click;
    LabelEmployees.Click += PanelEmployees_Click;

    if (!PermissionsService.CanLogWork()) {
      PanelWorkLog.Hide();
    }
    if (!PermissionsService.CanManageProjects()) {
      PanelProjects.Hide();
    }
    if (!PermissionsService.CanManageUsers()) {
      PanelEmployees.Hide();
    }
    if (!PermissionsService.CanManageSprints()) {
      PanelSprints.Hide();
    }
    else {
      PanelSprints_Click(sender, e);
    }

    LabelUserName.Text = "@" + AuthService.CurrentUser.Username;
    LabelUserType.Text = AuthService.CurrentUser.Type.ToString();
  }


  private void ButtonLogout_Click(object sender, EventArgs e) {
    AuthService.Logout(this);
  }

  private void OpenChildForm(Form childForm) {
    if (PanelMainContent.Controls.Count > 0) {
      PanelMainContent.Controls.Clear();
    }

    childForm.TopLevel = false;
    childForm.FormBorderStyle = FormBorderStyle.None;
    childForm.Dock = DockStyle.Fill;

    PanelMainContent.Controls.Add(childForm);
    PanelMainContent.Tag = childForm;
    childForm.BringToFront();
    childForm.Show();
  }

  private void PanelEmployees_Click(object sender, EventArgs e) {
    OpenChildForm(new DashboardForm());
  }

  private void PanelSprints_Click(object sender, EventArgs e) {
    OpenChildForm(new DashboardForm());
  }

  private void PanelProjects_Click(object sender, EventArgs e) {
    OpenChildForm(new DashboardForm());
  }

  private void PanelWorkLog_Click(object sender, EventArgs e) {
    OpenChildForm(new DashboardForm());
  }
}
