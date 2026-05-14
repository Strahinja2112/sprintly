using Sprintra.Src.Services;

namespace Sprintra.Forms;

public partial class LoginForm : Form {
  public bool IsLoginSuccessful { get; private set; } = false;

  public LoginForm() {
    InitializeComponent();
  }

  private void ButtonSubmit_Click(object sender, EventArgs e) {
    string username = TBoxUsername.Text.Trim();
    string password = TBoxPassword.Text.Trim();
    bool rememberMe = ChBoxRememberMe.Checked;

    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) {
      MessageBox.Show("Molimo unesite korisničko ime i lozinku.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      return;
    }

    ButtonSubmit.Text = "Prijavljivanje...";
    ButtonSubmit.Refresh();

    try {
      IsLoginSuccessful = AuthService.Login(username, password, rememberMe);

      if (!IsLoginSuccessful) {
        MessageBox.Show("Neispravni podaci.", "Pristup odbijen", MessageBoxButtons.OK, MessageBoxIcon.Error);
        TBoxPassword.Clear();
        TBoxPassword.Focus();

        return;
      }

      DialogResult = DialogResult.OK;
      Close();
    }
    catch (Exception ex) {
      MessageBox.Show(ex.Message, "Sistemska greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    ButtonSubmit.Text = "Prijava";
  }

  private void TBoxPassword_KeyUp(object sender, KeyEventArgs e) {
    if (e.KeyCode == Keys.Enter) {
      ButtonSubmit_Click(sender, e);
    }
  }
}
