using Sprintra.Services;

namespace Sprintra;

internal static class Program {
  [STAThread]
  static void Main() {
    ApplicationConfiguration.Initialize();

    //using var db = new AppDbContext();

    //try {
    //  // 1. Provera da li je baza prazna (da ne dupliramo podatke svaki put)
    //  if (db.Employees.Any()) {
    //    // Opciono: db.Employees.RemoveRange(db.Employees); db.SaveChanges();
    //  }

    //  var testEmployees = new List<Employee>
    //  {
    //        // ADMIN - On nema SeniorityLevel ni Field (biće NULL)
    //        new Employee
    //        {
    //            FirstName = "Admin",
    //            LastName = "System",
    //            Email = "admin@sprintra.com",
    //            Username = "admin",
    //            PasswordHash = AuthService.HashPassword("admin123"),
    //            HireDate = DateTime.Now,
    //            Status = "Active",
    //            Type = EmployeeType.Admin
    //        },

    //        // SENIOR DEVELOPER - Popunjena sva polja
    //        new Employee
    //        {
    //            FirstName = "Strahinja",
    //            LastName = "Prezime",
    //            Email = "strahinja@sprintra.com",
    //            Phone = "065123456",
    //            Username = "strahinja",
    //            PasswordHash = AuthService.HashPassword("sifra123"),
    //            HireDate = DateTime.Now.AddMonths(-12),
    //            Status = "Active",
    //            Type = EmployeeType.Developer,
    //            SeniorityLevel = SeniorityLevel.Senior,
    //            Field = Field.Fullstack
    //        },

    //        // JUNIOR DEVELOPER - Backend fokus
    //        new Employee
    //        {
    //            FirstName = "Marko",
    //            LastName = "Markovic",
    //            Email = "marko@sprintra.com",
    //            Username = "marko.dev",
    //            PasswordHash = AuthService.HashPassword("marko123"),
    //            HireDate = DateTime.Now.AddDays(-30),
    //            Status = "Active",
    //            Type = EmployeeType.Developer,
    //            SeniorityLevel = SeniorityLevel.Junior,
    //            Field = Field.Backend
    //        }
    //    };

    //  db.Employees.AddRange(testEmployees);
    //  db.SaveChanges();

    //  MessageBox.Show("Uspešno ubačeno 3 testna zaposlena!", "Seed Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    //}
    //catch (Exception ex) {
    //  MessageBox.Show($"Greška pri insertovanju: {ex.Message}");
    //}

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