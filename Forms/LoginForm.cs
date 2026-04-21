namespace Sprintra.Forms;

public partial class LoginForm : Form {
  public bool IsLoginSuccessful { get; private set; } = false;

  public LoginForm() {
    InitializeComponent();
  }
}
