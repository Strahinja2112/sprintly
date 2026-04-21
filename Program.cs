namespace Sprintra;

internal static class Program {
  [STAThread]
  static void Main() {
    //if (File.Exists("user.dat")) {
    //  string encryptedData = File.ReadAllText("user.dat");
    //  string username = SecurityService.Unprotect(encryptedData);

    //  if (!string.IsNullOrEmpty(username)) {
    //    using var db = new AppDbContext();
    //    var user = db.Employees.FirstOrDefault(u => u.Username == username);

    //    if (user != null) {
    //      CurrentUser.Initialize(user);
    //    }
    //  }
    //}

    ApplicationConfiguration.Initialize();

    var loginForm = new Forms.LoginForm();
    Application.Run(loginForm);

    if (!loginForm.IsLoginSuccessful) {
      Application.Exit();
      return;
    }

    Application.Run(new Forms.MainForm());

    //if (CurrentUser.IsLoggedIn) {
    //  Application.Run(new Forms.MainForm());
    //}
    //else {
    //  var loginForm = new Forms.LoginForm();
    //  Application.Run(loginForm);

    //  if (!loginForm.IsLoginSuccessful) {
    //    Application.Exit();
    //    return;
    //  }

    //  Application.Run(new Forms.MainForm());
    //}
  }
}