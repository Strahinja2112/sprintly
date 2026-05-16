using Sprintra.Forms;
using Sprintra.Src.Services;

namespace Sprintra;

internal static class Program {
  public static bool HasUserLoggedOut = false;

  private static MainForm? mainForm = null;

  [STAThread]
  static void Main() {
    ApplicationConfiguration.Initialize();

    //if (MessageBox.Show("Do you want to seed the database? This will erase all existing data.", "Database Seeding", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
    //  SeedService.FullSeed();
    //  AuthService.Logout();
    //}

    while (true) {
      HasUserLoggedOut = false;

      if (!AuthService.TryAutoLogin()) {
        var loginForm = new LoginForm();
        Application.Run(loginForm);
        loginForm.Close();
        if (!loginForm.IsLoginSuccessful) {
          break;
        }
      }

      mainForm = new MainForm();
      Application.Run(mainForm);

      if (!HasUserLoggedOut) {
        break;
      }

      mainForm = null;
    }
  }
}