using Sprintra.Services;

namespace Sprintra;

internal static class Program {
  [STAThread]
  static void Main() {
    ApplicationConfiguration.Initialize();

    //using var db = new AppDbContext();

    //var employee = new Employee() {
    //  FirstName = "Strahinja",
    //  LastName = "Prezime", // Dodaj pravo prezime
    //  Email = "strahinja@sprintra.com",
    //  Username = "strahinja",
    //  PasswordHash = AuthService.HashPassword("123"),
    //  HireDate = DateTime.Now,
    //  Status = "Active",
    //  Type = EmployeeType.Developer
    //};

    //db.Employees.Add(employee);
    //db.SaveChanges();

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