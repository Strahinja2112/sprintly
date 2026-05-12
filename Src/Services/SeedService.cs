using Microsoft.EntityFrameworkCore;
using Sprintra.Src.Data;
using Sprintra.Src.Data.Models;

namespace Sprintra.Src.Services;

internal class SeedService {
  public static void FullSeed() {
    using var db = new AppDbContext();

    try {
      // 1. Čišćenje - obrnuti redosled od zavisnosti
      db.WorkTaskEntries.RemoveRange(db.WorkTaskEntries);
      db.WorkTasks.RemoveRange(db.WorkTasks);
      db.Sprints.RemoveRange(db.Sprints);
      db.UserStories.RemoveRange(db.UserStories);
      db.Projects.RemoveRange(db.Projects);
      db.Employees.RemoveRange(db.Employees);
      db.SaveChanges();

      try {
        db.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Employees', RESEED, 0)");
        db.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Projects', RESEED, 0)");
        db.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('UserStories', RESEED, 0)");
        db.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Sprints', RESEED, 0)");
        db.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('WorkTasks', RESEED, 0)");
      }
      catch { }

      // 2. Zaposleni
      var employees = GetSeedEmployees();
      db.Employees.AddRange(employees);
      db.SaveChanges();

      var strahinja = db.Employees.First(e => e.Username == "strahinja");
      var admin = db.Employees.First(e => e.Username == "admin");

      // 3. PRVO PROJEKAT (UserStory zavisi od ProjectId)
      var project = new Project {
        Name = "Sprintra Management System",
        Description = "Interna aplikacija za Scrum timove.",
        Status = ProjectStatus.Active,
        StartDate = DateTime.Now.AddMonths(-1),
        Members = new List<Employee> { strahinja, admin }
      };
      db.Projects.Add(project);
      db.SaveChanges(); // Ovde projekat dobija ID

      // 4. DRUGO USER STORY (WorkTask zavisi od UserStoryId)
      var story = new UserStory {
        Title = "Inicijalna faza",
        Description = "Zadaci podešavanja",
        Priority = 1,
        ProjectId = project.Id // Povezujemo sa projektom
      };
      db.UserStories.Add(story);
      db.SaveChanges(); // Ovde story dobija ID

      // 5. TREĆE SPRINT I TASKOVI
      var sprint = new Sprint {
        Name = "Sprint 1",
        Goal = "Core features",
        Status = SprintStatus.Active,
        StartDate = DateTime.Now.AddDays(-7),
        EndDate = DateTime.Now.AddDays(7),
        ProjectId = project.Id,
        ScrumMasterId = admin.Id,
        WorkTasks = new List<WorkTask> {
                    new() {
                        Name = "Database Setup",
                        Description = "Tables and relations",
                        Status = WorkTaskStatus.Done,
                        EstimatedHours = 5,
                        UserStoryId = story.Id,
                        SprintId = 0 // Biće dodeljeno automatski jer je deo kolekcije sprinta
                    },
                    new() {
                        Name = "Auth Implementation",
                        Description = "Bcrypt login",
                        Status = WorkTaskStatus.InProgress,
                        EstimatedHours = 10,
                        UserStoryId = story.Id
                    }
                }
      };

      db.Sprints.Add(sprint);
      db.SaveChanges();
    }
    catch (Exception ex) {
      throw new Exception($"Seed propao: {ex.Message}");
    }
  }

  private static List<Employee> GetSeedEmployees() {
    return [
        new Employee {
                FirstName = "Strahinja", LastName = "Prezime", Email = "s@s.com", Username = "strahinja",
                PasswordHash = AuthService.HashPassword("sifra123"), HireDate = DateTime.Now, Status = "Active",
                Type = EmployeeType.Developer, SeniorityLevel = SeniorityLevel.Senior, Field = Field.Fullstack
            },
            new Employee {
                FirstName = "Admin", LastName = "System", Email = "a@a.com", Username = "admin",
                PasswordHash = AuthService.HashPassword("admin123"), HireDate = DateTime.Now.AddYears(-1),
                Status = "Active", Type = EmployeeType.Admin
            }
    ];
  }
}