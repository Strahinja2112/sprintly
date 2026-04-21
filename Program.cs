using Sprintra.Services;

namespace Sprintra;

internal static class Program {
  [STAThread]
  static void Main() {

    if (File.Exists("user.dat")) {
      string encryptedData = File.ReadAllText("user.dat");
      string username = SecurityService.Unprotect(encryptedData);

      if (!string.IsNullOrEmpty(username)) {
        //// Moraš napraviti instancu context-a
        //using var db = new AppDbContext();
        //var user = db.Employees.FirstOrDefault(u => u.Username == username);

        //if (user != null) {
        //  CurrentUser.Initialize(user);
        //}
      }
    }

    ApplicationConfiguration.Initialize();

    if (CurrentUser.IsLoggedIn) {
      Application.Run(new Forms.MainForm());
    }
    else {
      // Application.Run(new Forms.LoginForm()); // Ovo otkomentariši kad napraviš Login prozor
      Application.Run(new Forms.MainForm());
    }
  }
}