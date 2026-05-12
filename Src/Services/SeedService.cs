using Microsoft.EntityFrameworkCore;
using Sprintra.Src.Data;
using Sprintra.Src.Data.Models;

namespace Sprintra.Src.Services;

internal class SeedService {
  public static void FullSeed() {
    using var db = new AppDbContext();

    try {
      // 1. Čišćenje baze (Paziti na redosled zbog stranih ključeva)
      db.Projects.RemoveRange(db.Projects);
      db.Employees.RemoveRange(db.Employees);
      db.SaveChanges();

      // 2. Resetovanje brojača (Opciono)
      try {
        db.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Employees', RESEED, 0)");
        db.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Projects', RESEED, 0)");
      }
      catch { /* Ignorisati ako nije SQL Server */ }

      // 3. Kreiranje Zaposlenih
      var employees = GetSeedEmployees();
      db.Employees.AddRange(employees);
      db.SaveChanges();

      // 4. Kreiranje Projekata
      var projects = GetSeedProjects();
      db.Projects.AddRange(projects);
      db.SaveChanges();

      // 5. Povezivanje preko Members kolekcije
      AssignMembersToProjects(db);

      db.SaveChanges();
    }
    catch (Exception ex) {
      throw new Exception($"Greška prilikom seedovanja: {ex.Message}");
    }
  }

  private static List<Employee> GetSeedEmployees() {
    return new List<Employee>
    {
            new Employee
            {
                FirstName = "Strahinja",
                LastName = "Prezime",
                Email = "strahinja@sprintra.com",
                Username = "strahinja",
                PasswordHash = AuthService.HashPassword("sifra123"),
                HireDate = DateTime.Now,
                Status = "Active",
                Type = EmployeeType.Developer,
                SeniorityLevel = SeniorityLevel.Senior,
                Field = Field.Fullstack
            },
            new Employee
            {
                FirstName = "Admin",
                LastName = "System",
                Email = "admin@sprintra.com",
                Username = "admin",
                PasswordHash = AuthService.HashPassword("admin123"),
                HireDate = DateTime.Now.AddYears(-1),
                Status = "Active",
                Type = EmployeeType.Admin
            },
            new Employee
            {
                FirstName = "Nikola",
                LastName = "Nikolic",
                Email = "nikola@sprintra.com",
                Username = "nikola.dev",
                PasswordHash = AuthService.HashPassword("nikola123"),
                HireDate = DateTime.Now.AddDays(-10),
                Status = "Active",
                Type = EmployeeType.Developer,
                SeniorityLevel = SeniorityLevel.Junior,
                Field = Field.Backend
            }
        };
  }

  private static List<Project> GetSeedProjects() {
    return [
      new() {
        Name = "Sprintra Management System",
        Description = "Interna aplikacija za vođenje Scrum timova i projekata.",
        Status = ProjectStatus.Active,
        StartDate = DateTime.Now.AddMonths(-1)
      },
      new() {
        Name = "E-Commerce Integration",
        Description = "Razvoj modula za plaćanje i integracija sa API servisima.",
        Status = ProjectStatus.Planned,
        StartDate = DateTime.Now.AddDays(14)
      }
    ];
  }

  private static void AssignMembersToProjects(AppDbContext db) {
    var strahinja = db.Employees.FirstOrDefault(e => e.Username == "strahinja");
    var nikola = db.Employees.FirstOrDefault(e => e.Username == "nikola.dev");
    var project = db.Projects.FirstOrDefault(p => p.Name == "Sprintra Management System");

    if (project != null) {
      if (strahinja != null) project.Members.Add(strahinja);
      if (nikola != null) project.Members.Add(nikola);
    }
  }
}