using Sprintra.Services;

namespace Sprintra;

internal static class Program {
  [STAThread]
  static void Main() {

    ApplicationConfiguration.Initialize();

    var isLoginSaved = AuthService.TryAutoLogin();
    if (!isLoginSaved) {
      var loginForm = new Forms.LoginForm();
      Application.Run(loginForm);

      if (!loginForm.IsLoginSuccessful) {
        Application.Exit();
        return;
      }
    }

    Application.Run(new Forms.MainForm());
  }
}