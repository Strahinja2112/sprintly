using Microsoft.EntityFrameworkCore;
using Sprintra.Src.Data;
using Sprintra.Src.Data.Models;

namespace Sprintra.Src.Services;

internal class SeedService {
  public static void FullSeed() {
    using var db = new AppDbContext();

    try {
      db.WorkTaskEntries.RemoveRange(db.WorkTaskEntries);
      db.WorkTasks.RemoveRange(db.WorkTasks);
      db.Sprints.RemoveRange(db.Sprints);
      db.UserStories.RemoveRange(db.UserStories);
      db.Projects.RemoveRange(db.Projects);
      db.Employees.RemoveRange(db.Employees);
      db.SaveChanges();

      var tables = new[] { "Employees", "Projects", "UserStories", "Sprints", "WorkTasks" };
      foreach (var table in tables) {
        try {
          db.Database.ExecuteSql($"DBCC CHECKIDENT ('{table}', RESEED, 0)");
        }
        catch { }
      }

      var employees = new List<Employee>() {
                new() { FirstName = "Admin", LastName = "System", Email = "admin@sprintra.com", Username = "admin",
                    PasswordHash = AuthService.HashPassword("123"), HireDate = DateTime.Now.AddYears(-2), Status = "Active", Type = EmployeeType.Admin },

                new() { FirstName = "Marko", LastName = "Menadžer", Email = "marko@pm.com", Username = "markopm",
                    PasswordHash = AuthService.HashPassword("123"), HireDate = DateTime.Now.AddMonths(-10), Status = "Active", Type = EmployeeType.ProductOwner },

                new() { FirstName = "Jelena", LastName = "Scrum", Email = "jelena@sm.com", Username = "jelenasm",
                    PasswordHash = AuthService.HashPassword("123"), HireDate = DateTime.Now.AddMonths(-8), Status = "Active", Type = EmployeeType.ScrumMaster },

                new() { FirstName = "Strahinja", LastName = "Dev", Email = "s@s.com", Username = "strahinja",
                    PasswordHash = AuthService.HashPassword("123"), HireDate = DateTime.Now, Status = "Active", Type = EmployeeType.Developer, SeniorityLevel = SeniorityLevel.Senior, Field = Field.Fullstack },

                new() { FirstName = "Nikola", LastName = "Junior", Email = "n@n.com", Username = "nikoladev",
                    PasswordHash = AuthService.HashPassword("123"), HireDate = DateTime.Now.AddDays(-30), Status = "Active", Type = EmployeeType.Developer, SeniorityLevel = SeniorityLevel.Junior, Field = Field.Backend }
            };

      db.Employees.AddRange(employees);
      db.SaveChanges();

      var sm = db.Employees.First(e => e.Username == "jelenasm");
      var project = new Project {
        Name = "Sprintra Management System",
        Description = "Interna aplikacija za Scrum timove i praćenje radnih sati.",
        Status = ProjectStatus.Active,
        StartDate = DateTime.Now.AddMonths(-2),
        Members = employees
      };
      db.Projects.Add(project);
      db.SaveChanges();

      var stories = new List<UserStory> {
                new() { Title = "Autentifikacija", Description = "Korisnik može da se uloguje i izloguje", Priority = 1, ProjectId = project.Id },
                new() { Title = "Upravljanje projektima", Description = "Admin može da kreira i menja projekte", Priority = 2, ProjectId = project.Id },
                new() { Title = "Logovanje rada", Description = "Developer može da upiše sate na taskove", Priority = 3, ProjectId = project.Id },
                new() { Title = "Statistika i Izveštaji", Description = "PM može da vidi utrošeno vreme", Priority = 4, ProjectId = project.Id }
            };
      db.UserStories.AddRange(stories);
      db.SaveChanges();

      var sprint1 = new Sprint {
        Name = "Sprint 1: Inicijalna faza",
        Goal = "Postavka baze i Auth",
        Status = SprintStatus.Completed,
        StartDate = DateTime.Now.AddDays(-40),
        EndDate = DateTime.Now.AddDays(-26),
        ProjectId = project.Id,
        ScrumMasterId = sm.Id,
        WorkTasks = new List<WorkTask> {
                    new() { Name = "Dizajn šeme baze", Description = "Definisanje svih tabela, relacija i stranih ključeva u SQL Serveru.", Status = WorkTaskStatus.Done, EstimatedHours = 8, UserStoryId = stories[0].Id },
                    new() { Name = "Login logika", Description = "Implementacija serverske validacije kredencijala i generisanje sesije.", Status = WorkTaskStatus.Done, EstimatedHours = 12, UserStoryId = stories[0].Id }
                }
      };

      var sprint2 = new Sprint {
        Name = "Sprint 2: Core funkcionalnosti",
        Goal = "Projekti i Priče",
        Status = SprintStatus.Active,
        StartDate = DateTime.Now.AddDays(-10),
        EndDate = DateTime.Now.AddDays(4),
        ProjectId = project.Id,
        ScrumMasterId = sm.Id,
        WorkTasks = new List<WorkTask> {
                    new() { Name = "CRUD Projekata", Description = "Kreiranje formi za unos, izmenu i pregled svih aktivnih projekata.", Status = WorkTaskStatus.InProgress, EstimatedHours = 15, UserStoryId = stories[1].Id },
                    new() { Name = "Dizajn User Stories forme", Description = "Kreiranje korisničkog interfejsa za upravljanje korisničkim pričama.", Status = WorkTaskStatus.Done, EstimatedHours = 6, UserStoryId = stories[1].Id },
                    new() { Name = "Validacija unosa", Description = "Implementacija klijentske validacije za sva polja unutar formi.", Status = WorkTaskStatus.ToDo, EstimatedHours = 4, UserStoryId = stories[1].Id }
                }
      };

      var sprint3 = new Sprint {
        Name = "Sprint 3: Tracking i Logovi",
        Goal = "Radni sati",
        Status = SprintStatus.Planned,
        StartDate = DateTime.Now.AddDays(7),
        EndDate = DateTime.Now.AddDays(21),
        ProjectId = project.Id,
        ScrumMasterId = sm.Id,
        WorkTasks = [
          new() { Name = "Implementacija tajmera", Description = "Implementacija tajmera za praćenje vremena rada na zadacima u realnom vremenu.", Status = WorkTaskStatus.ToDo, EstimatedHours = 10, UserStoryId = stories[2].Id },
          new() { Name = "Export logova u PDF", Description = "Generisanje PDF dokumenata na osnovu unetih radnih sati za odabrani period.", Status = WorkTaskStatus.ToDo, EstimatedHours = 16, UserStoryId = stories[3].Id },
          new() {
            Name = "Refaktorisanje koda",
            Description = "Pregled i refaktorisanje postojećih servisa radi optimizacije performansi i čitljivosti.",
            Status = WorkTaskStatus.ToDo,
            EstimatedHours = 20,
            UserStoryId = stories[3].Id
          }
        ]
      };

      db.Sprints.AddRange(sprint1, sprint2, sprint3);
      db.SaveChanges();
    }
    catch (Exception ex) {
      MessageBox.Show($"Seed propao: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }
}