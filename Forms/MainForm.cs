using Sprintra.Models;
using Sprintra.Services;

namespace Sprintra.Forms;

public partial class MainForm : Form {
  public MainForm() {
    InitializeComponent();
  }

  private void MainForm_Load(object sender, EventArgs e) {
    if (AuthService.CurrentUser == null) {
      Close();
    }

    if (AuthService.CurrentUser.Type == EmployeeType.Developer) {
      PanelDashboard.Hide();
    }
    else {
      PanelDashboard_Click(sender, e);
      LabelDashboard.Click += PanelDashboard_Click;
    }

    LabelUserName.Text = "@" + AuthService.CurrentUser.Username;
    LabelUserType.Text = AuthService.CurrentUser.Type.ToString();
  }


  private void ButtonLogout_Click(object sender, EventArgs e) {
    AuthService.Logout(this);
  }

  private void PanelDashboard_Click(object sender, EventArgs e) {
    OpenChildForm(new DashboardForm());
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
}
