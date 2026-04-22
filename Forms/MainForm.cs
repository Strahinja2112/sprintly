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

    LabelUserName.Text = "@" + AuthService.CurrentUser.Username;
    LabelUserRole.Text = AuthService.CurrentUser.TeamRole?.ToString() ?? "N/A";
  }


  private void ButtonLogout_Click(object sender, EventArgs e) {
    AuthService.Logout(this);
  }

  private void PanelDashboard_Paint(object sender, PaintEventArgs e) {

  }
}
