using Sprintra.Forms;
using Sprintra.Src.Services;

namespace Sprintra;

internal static class Program {
  public static MainForm MainForm = null!;

  [STAThread]
  static void Main() {
    ApplicationConfiguration.Initialize();

    // SeedService.FullSeed();

    var isLoginSaved = AuthService.TryAutoLogin();
    if (!isLoginSaved) {
      var loginForm = new LoginForm();
      Application.Run(loginForm);

      if (!loginForm.IsLoginSuccessful) {
        Application.Exit();
        return;
      }
    }

    MainForm = new MainForm();
    Application.Run(MainForm);

    //using var db = new AppDbContext();
    //db.Projects
    //  .Where(p => p.EndDate < DateTime.Now)
    //  .ExecuteUpdate(c => c.SetProperty(p => p.Status, ProjectStatus.Completed));
  }
}