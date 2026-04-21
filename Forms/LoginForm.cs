using Sprintra.Services;

namespace Sprintra.Forms;

public partial class LoginForm : Form {
  public bool IsLoginSuccessful { get; private set; } = false;

  public LoginForm() {
    InitializeComponent();
  }

  private void ButtonSubmit_Click(object sender, EventArgs e) {
    string username = TBoxUsername.Text.Trim();
    string password = TBoxPassword.Text.Trim();

    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) {
      MessageBox.Show("Molimo unesite korisničko ime i lozinku.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      return;
    }

    try {
      if (AuthService.Login(username, password)) {
        IsLoginSuccessful = true;
        DialogResult = DialogResult.OK;
        Close();
      }
      else {
        MessageBox.Show("Neispravni podaci.", "Pristup odbijen", MessageBoxButtons.OK, MessageBoxIcon.Error);
        TBoxPassword.Clear();
        TBoxPassword.Focus();
      }
    }
    catch (Exception ex) {
      MessageBox.Show(ex.Message, "Sistemska greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }
}
