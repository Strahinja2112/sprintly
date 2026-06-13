using Microsoft.EntityFrameworkCore;
using Sprintly.Src.Data;
using Sprintly.Src.Data.Models;

namespace Sprintly.Src.Services;

internal class SeedService {
  public static void FullSeed() {
    using var db = new AppDbContext();

    try {
      db.WorkTaskEntries.RemoveRange(db.WorkTaskEntries);
      db.WorkTasks.RemoveRange(db.WorkTasks); db.Sprints.RemoveRange(db.Sprints);
      db.UserStories.RemoveRange(db.UserStories);
      db.Projects.RemoveRange(db.Projects);
      db.Employees.RemoveRange(db.Employees);
      db.SaveChanges();

      var tables = new[] {
        "WorkTaskEntries",
        "WorkTasks",
        "Features",
        "Sprints",
        "UserStories",
        "Projects",
        "Increments",
        "Distributions",
        "Employees"
      };

      foreach (var table in tables) {
        try {
          db.Database.ExecuteSqlRaw($"DBCC CHECKIDENT ('{table}', RESEED, 0)");
        }
        catch { }
      }

      var password = AuthService.HashPassword("123");
      var employees = new List<Employee> {
        new() { FirstName = "Admin", LastName = "System", Email = "admin@sprintly.local", Username = "admin", PasswordHash = password, HireDate = DateTime.Now.AddYears(-3), Status = "Active", Type = EmployeeType.Admin },
        new() { FirstName = "Milica", LastName = "Kostic", Email = "milica.kostic@sprintly.local", Username = "milica.po", PasswordHash = password, HireDate = DateTime.Now.AddYears(-2), Status = "Active", Type = EmployeeType.ProductOwner },
        new() { FirstName = "Marko", LastName = "Petrovic", Email = "marko.petrovic@sprintly.local", Username = "marko.po", PasswordHash = password, HireDate = DateTime.Now.AddMonths(-18), Status = "Active", Type = EmployeeType.ProductOwner },
        new() { FirstName = "Jelena", LastName = "Ilic", Email = "jelena.ilic@sprintly.local", Username = "jelena.sm", PasswordHash = password, HireDate = DateTime.Now.AddYears(-2), Status = "Active", Type = EmployeeType.ScrumMaster },
        new() { FirstName = "Stefan", LastName = "Nikolic", Email = "stefan.nikolic@sprintly.local", Username = "stefan.sm", PasswordHash = password, HireDate = DateTime.Now.AddMonths(-14), Status = "Active", Type = EmployeeType.ScrumMaster },
        new() { FirstName = "Strahinja", LastName = "Jovanovic", Email = "strahinja.jovanovic@sprintly.local", Username = "strahinja", PasswordHash = password, HireDate = DateTime.Now.AddYears(-4), Status = "Active", Type = EmployeeType.Developer, SeniorityLevel = SeniorityLevel.Senior, Field = Field.Fullstack },
        new() { FirstName = "Nikola", LastName = "Savic", Email = "nikola.savic@sprintly.local", Username = "nikola", PasswordHash = password, HireDate = DateTime.Now.AddMonths(-8), Status = "Active", Type = EmployeeType.Developer, SeniorityLevel = SeniorityLevel.Junior, Field = Field.Backend },
        new() { FirstName = "Ana", LastName = "Matic", Email = "ana.matic@sprintly.local", Username = "ana", PasswordHash = password, HireDate = DateTime.Now.AddYears(-1), Status = "Active", Type = EmployeeType.Developer, SeniorityLevel = SeniorityLevel.Medior, Field = Field.Frontend },
        new() { FirstName = "Luka", LastName = "Radic", Email = "luka.radic@sprintly.local", Username = "luka", PasswordHash = password, HireDate = DateTime.Now.AddMonths(-11), Status = "Active", Type = EmployeeType.Developer, SeniorityLevel = SeniorityLevel.Medior, Field = Field.QA },
        new() { FirstName = "Tamara", LastName = "Vukovic", Email = "tamara.vukovic@sprintly.local", Username = "tamara", PasswordHash = password, HireDate = DateTime.Now.AddMonths(-16), Status = "Active", Type = EmployeeType.Developer, SeniorityLevel = SeniorityLevel.Senior, Field = Field.DevOps },
        new() { FirstName = "Pavle", LastName = "Stanic", Email = "pavle.stanic@sprintly.local", Username = "pavle", PasswordHash = password, HireDate = DateTime.Now.AddMonths(-5), Status = "Active", Type = EmployeeType.Developer, SeniorityLevel = SeniorityLevel.Junior, Field = Field.Frontend },
        new() { FirstName = "Sara", LastName = "Popovic", Email = "sara.popovic@sprintly.local", Username = "sara", PasswordHash = password, HireDate = DateTime.Now.AddMonths(-9), Status = "Active", Type = EmployeeType.Developer, SeniorityLevel = SeniorityLevel.Medior, Field = Field.Fullstack }
      };

      db.Employees.AddRange(employees);
      db.SaveChanges();

      var admin = employees[0];
      var milica = employees[1];
      var marko = employees[2];
      var jelena = employees[3];
      var stefan = employees[4];
      var strahinja = employees[5];
      var nikola = employees[6];
      var ana = employees[7];
      var luka = employees[8];
      var tamara = employees[9];
      var pavle = employees[10];
      var sara = employees[11];

      db.SaveChanges();

      db.SaveChanges();

      var sprintly = new Project {
        Name = "Sprintly Desktop",
        Description = "Interna WinForms aplikacija za Scrum timove, sprintove, zadatke i evidenciju rada.",
        Status = ProjectStatus.Active,
        StartDate = DateTime.Now.AddMonths(-4),
        Members = [admin, milica, jelena, strahinja, nikola, ana, luka, tamara, pavle, sara]
      };

      var portal = new Project {
        Name = "Client Portal",
        Description = "Web portal za pregled statusa projekta, isporuka i osnovnih izveštaja.",
        Status = ProjectStatus.Active,
        StartDate = DateTime.Now.AddMonths(-2),
        Members = [marko, stefan, strahinja, ana, luka, sara]
      };

      var api = new Project {
        Name = "Reporting API",
        Description = "Servis za agregaciju radnih sati, statusa zadataka i sprint metrika.",
        Status = ProjectStatus.Planned,
        StartDate = DateTime.Now.AddDays(14),
        Members = [marko, stefan, nikola, tamara, sara]
      };

      var mobile = new Project {
        Name = "Mobile Companion",
        Description = "Mobilna aplikacija za brzi unos rada i pregled ličnih zaduženja.",
        Status = ProjectStatus.OnHold,
        StartDate = DateTime.Now.AddMonths(-1),
        Members = [milica, jelena, ana, pavle, luka]
      };

      db.Projects.AddRange(sprintly, portal, api, mobile);
      db.SaveChanges();

      var stories = new List<UserStory> {
        new() { ProjectId = sprintly.Id, Title = "Prijava i sesija", Description = "Korisnik može da se prijavi, zapamti sesiju i bezbedno odjavi.", Priority = 1 },
        new() { ProjectId = sprintly.Id, Title = "Upravljanje zaposlenima", Description = "Admin održava zaposlene, role, senioritet i razvojnu oblast.", Priority = 2 },
        new() { ProjectId = sprintly.Id, Title = "Planiranje sprintova", Description = "Scrum Master planira sprintove unutar odabranog projekta.", Priority = 3 },
        new() { ProjectId = sprintly.Id, Title = "Radni zadaci", Description = "Tim kreira, procenjuje, dodeljuje i prati zadatke.", Priority = 4 },
        new() { ProjectId = sprintly.Id, Title = "Evidencija rada", Description = "Developer evidentira sate rada na dodeljenim zadacima.", Priority = 5 },
        new() { ProjectId = sprintly.Id, Title = "Bezbedno brisanje", Description = "Aplikacija sprečava brisanje zapisa koji imaju istoriju rada.", Priority = 6 },

        new() { ProjectId = portal.Id, Title = "Dashboard za klijenta", Description = "Klijent vidi projekte, sprintove i status isporuke.", Priority = 1 },
        new() { ProjectId = portal.Id, Title = "Pregled funkcionalnosti", Description = "Klijent vidi listu funkcionalnosti po isporuci.", Priority = 2 },
        new() { ProjectId = portal.Id, Title = "Komentari na isporuku", Description = "Klijent ostavlja komentar na predlog isporuke.", Priority = 3 },
        new() { ProjectId = portal.Id, Title = "Export statusa", Description = "Product Owner izvozi pregled statusa u CSV.", Priority = 4 },

        new() { ProjectId = api.Id, Title = "Agregacija sati", Description = "API računa ukupan rad po zadatku, sprintu i zaposlenom.", Priority = 1 },
        new() { ProjectId = api.Id, Title = "Sprint metrike", Description = "API vraća osnovne metrike sprinta i preostali rad.", Priority = 2 },
        new() { ProjectId = api.Id, Title = "Token autentifikacija", Description = "Integracije koriste token za pristup izveštajima.", Priority = 3 },

        new() { ProjectId = mobile.Id, Title = "Moji zadaci", Description = "Korisnik vidi svoje aktivne zadatke na telefonu.", Priority = 1 },
        new() { ProjectId = mobile.Id, Title = "Brzi unos vremena", Description = "Korisnik evidentira vreme iz mobilne aplikacije.", Priority = 2 }
      };
      db.UserStories.AddRange(stories);
      db.SaveChanges();

      UserStory Story(string title) => stories.First(s => s.Title == title);

      var sprints = new List<Sprint> {
        new() { ProjectId = sprintly.Id, ScrumMasterId = jelena.Id, Name = "Sprintly 1 - Temelj", Goal = "Postaviti autentifikaciju, bazu i osnovni dashboard.", StartDate = DateTime.Now.AddDays(-56), EndDate = DateTime.Now.AddDays(-42), Status = SprintStatus.Completed, EstimatedWorkHours = 120 },
        new() { ProjectId = sprintly.Id, ScrumMasterId = jelena.Id, Name = "Sprintly 2 - Core CRUD", Goal = "Urediti projekte, zaposlene, priče i zadatke.", StartDate = DateTime.Now.AddDays(-35), EndDate = DateTime.Now.AddDays(-21), Status = SprintStatus.Completed, EstimatedWorkHours = 150 },
        new() { ProjectId = sprintly.Id, ScrumMasterId = jelena.Id, Name = "Sprintly 3 - Work Tracking", Goal = "Omogućiti dodelu zadataka i unos rada.", StartDate = DateTime.Now.AddDays(-14), EndDate = DateTime.Now.AddDays(0), Status = SprintStatus.Active, EstimatedWorkHours = 140 },
        new() { ProjectId = sprintly.Id, ScrumMasterId = jelena.Id, Name = "Sprintly 4 - Stabilizacija", Goal = "Validacije, seed podaci, brisanja i priprema release-a.", StartDate = DateTime.Now.AddDays(7), EndDate = DateTime.Now.AddDays(21), Status = SprintStatus.Planned, EstimatedWorkHours = 110 },

        new() { ProjectId = portal.Id, ScrumMasterId = stefan.Id, Name = "Portal 1 - Dashboard", Goal = "Prikaz osnovnih podataka klijentu.", StartDate = DateTime.Now.AddDays(-21), EndDate = DateTime.Now.AddDays(-7), Status = SprintStatus.Completed, EstimatedWorkHours = 100 },
        new() { ProjectId = portal.Id, ScrumMasterId = stefan.Id, Name = "Portal 2 - Feedback", Goal = "Komentari, export i pregled isporuka.", StartDate = DateTime.Now.AddDays(1), EndDate = DateTime.Now.AddDays(15), Status = SprintStatus.Planned, EstimatedWorkHours = 120 },

        new() { ProjectId = api.Id, ScrumMasterId = stefan.Id, Name = "API 1 - Reporting Foundations", Goal = "Postaviti izveštajne endpoint-e i agregacije.", StartDate = DateTime.Now.AddDays(14), EndDate = DateTime.Now.AddDays(28), Status = SprintStatus.Planned, EstimatedWorkHours = 130 },

        new() { ProjectId = mobile.Id, ScrumMasterId = jelena.Id, Name = "Mobile 1 - Prototype", Goal = "Validirati osnovni tok za moje zadatke.", StartDate = DateTime.Now.AddDays(-28), EndDate = DateTime.Now.AddDays(-14), Status = SprintStatus.Canceled, EstimatedWorkHours = 80 }
      };
      db.Sprints.AddRange(sprints);
      db.SaveChanges();

      Sprint Sprint(string name) => sprints.First(s => s.Name == name);

      var tasks = new List<WorkTask> {
        NewTask("Login forma", "Kreirati WinForms login ekran i osnovnu validaciju.", WorkTaskStatus.Done, 10, Story("Prijava i sesija"), Sprint("Sprintly 1 - Temelj"), [strahinja, ana]),
        NewTask("Remember me sesija", "Sačuvati korisničko ime i automatski prijaviti korisnika.", WorkTaskStatus.Done, 6, Story("Prijava i sesija"), Sprint("Sprintly 1 - Temelj"), [nikola]),
        NewTask("Permission service", "Centralizovati pravila pristupa po tipu zaposlenog.", WorkTaskStatus.Done, 12, Story("Prijava i sesija"), Sprint("Sprintly 1 - Temelj"), [strahinja]),
        NewTask("Model zaposlenih", "Dodati tip zaposlenog, senioritet i oblast rada.", WorkTaskStatus.Done, 8, Story("Upravljanje zaposlenima"), Sprint("Sprintly 1 - Temelj"), [nikola]),

        NewTask("Forma projekata", "Kreiranje, izmena, pretraga i validacija projekata.", WorkTaskStatus.Done, 18, Story("Planiranje sprintova"), Sprint("Sprintly 2 - Core CRUD"), [ana, strahinja]),
        NewTask("Forma zaposlenih", "Admin pregled i izmena zaposlenih.", WorkTaskStatus.Done, 16, Story("Upravljanje zaposlenima"), Sprint("Sprintly 2 - Core CRUD"), [ana, pavle]),
        NewTask("Forma korisničkih priča", "Pregled priča po projektu i unos prioriteta.", WorkTaskStatus.Done, 14, Story("Radni zadaci"), Sprint("Sprintly 2 - Core CRUD"), [sara]),
        NewTask("Forma zadataka", "Kreiranje i izmena zadataka vezanih za priče.", WorkTaskStatus.InProgress, 20, Story("Radni zadaci"), Sprint("Sprintly 2 - Core CRUD"), [strahinja, sara]),
        NewTask("Pretraga kroz tabele", "Dodati pretragu na ključne subforme.", WorkTaskStatus.Done, 7, Story("Radni zadaci"), Sprint("Sprintly 2 - Core CRUD"), [pavle]),

        NewTask("Dodela zaposlenih zadatku", "Omogućiti izbor više zaposlenih po zadatku.", WorkTaskStatus.Done, 12, Story("Radni zadaci"), Sprint("Sprintly 3 - Work Tracking"), [strahinja, nikola]),
        NewTask("Unos radnih sati", "Developer evidentira sate i minute na aktivnim zadacima.", WorkTaskStatus.InProgress, 15, Story("Evidencija rada"), Sprint("Sprintly 3 - Work Tracking"), [nikola, luka]),
        NewTask("Pregled preostalog rada", "Izračunati preostale sate iz procene i logovanog rada.", WorkTaskStatus.InProgress, 10, Story("Evidencija rada"), Sprint("Sprintly 3 - Work Tracking"), [luka]),
        NewTask("Bezbedno brisanje zadataka", "Ne brisati zadatke koji imaju radne unose.", WorkTaskStatus.ToDo, 9, Story("Bezbedno brisanje"), Sprint("Sprintly 3 - Work Tracking"), [sara]),
        NewTask("Refresh gridova posle akcija", "Očistiti forme i osvežiti tabele posle snimanja i brisanja.", WorkTaskStatus.ToDo, 6, Story("Bezbedno brisanje"), Sprint("Sprintly 3 - Work Tracking"), [pavle]),

        NewTask("Seed podaci", "Napraviti veći skup realnih test podataka.", WorkTaskStatus.ToDo, 8, Story("Bezbedno brisanje"), Sprint("Sprintly 4 - Stabilizacija"), [nikola]),
        NewTask("Regresiono testiranje brisanja", "Proveriti blokade za projekte, sprintove, priče i zadatke.", WorkTaskStatus.ToDo, 12, Story("Bezbedno brisanje"), Sprint("Sprintly 4 - Stabilizacija"), [luka]),
        NewTask("Poliranje poruka", "Usaglasiti tekstove validacija i obaveštenja.", WorkTaskStatus.ToDo, 7, Story("Bezbedno brisanje"), Sprint("Sprintly 4 - Stabilizacija"), [ana, pavle]),

        NewTask("Portal overview", "Prikaz ukupnog statusa projekta i trenutnog sprinta.", WorkTaskStatus.Done, 14, Story("Dashboard za klijenta"), Sprint("Portal 1 - Dashboard"), [ana, sara]),
        NewTask("Kartice isporuke", "Lista funkcionalnosti grupisana po verziji.", WorkTaskStatus.Done, 11, Story("Pregled funkcionalnosti"), Sprint("Portal 1 - Dashboard"), [sara]),
        NewTask("Klijentski filteri", "Filter po projektu, statusu i periodu.", WorkTaskStatus.InProgress, 10, Story("Dashboard za klijenta"), Sprint("Portal 1 - Dashboard"), [pavle]),
        NewTask("Komentari na release", "Unos komentara za predloženu isporuku.", WorkTaskStatus.ToDo, 13, Story("Komentari na isporuku"), Sprint("Portal 2 - Feedback"), [ana]),
        NewTask("CSV export statusa", "Generisanje CSV pregleda za Product Owner-a.", WorkTaskStatus.ToDo, 9, Story("Export statusa"), Sprint("Portal 2 - Feedback"), [sara, luka]),

        NewTask("Endpoint za sate", "Vratiti sumu sati po zadatku i zaposlenom.", WorkTaskStatus.ToDo, 16, Story("Agregacija sati"), Sprint("API 1 - Reporting Foundations"), [nikola, tamara]),
        NewTask("Endpoint za sprint metrike", "Vratiti procenu, logovano vreme i preostali rad po sprintu.", WorkTaskStatus.ToDo, 18, Story("Sprint metrike"), Sprint("API 1 - Reporting Foundations"), [tamara, strahinja]),
        NewTask("API token middleware", "Dodati proveru tokena za reporting integracije.", WorkTaskStatus.ToDo, 12, Story("Token autentifikacija"), Sprint("API 1 - Reporting Foundations"), [tamara]),

        NewTask("Mobilni ekran zadataka", "Prototype liste mojih zadataka na telefonu.", WorkTaskStatus.Cancelled, 10, Story("Moji zadaci"), Sprint("Mobile 1 - Prototype"), [pavle]),
        NewTask("Offline unos vremena", "Ispitati lokalno čuvanje radnih unosa bez mreže.", WorkTaskStatus.Cancelled, 14, Story("Brzi unos vremena"), Sprint("Mobile 1 - Prototype"), [ana, luka]),

        NewTask("Backlog: import iz CSV-a", "Import korisničkih priča iz CSV dokumenta.", WorkTaskStatus.ToDo, 12, Story("Radni zadaci"), null, [sara]),
        NewTask("Backlog: tema aplikacije", "Dodati svetlu/tamnu temu za desktop aplikaciju.", WorkTaskStatus.ToDo, 16, Story("Radni zadaci"), null, [ana, pavle])
      };

      db.WorkTasks.AddRange(tasks);
      db.SaveChanges();

      WorkTask TaskByName(string name) => tasks.First(t => t.Name == name);

      var entries = new List<WorkTaskEntry> {
        Entry(strahinja, "Login forma", -54, 5.5m),
        Entry(ana, "Login forma", -53, 4m),
        Entry(nikola, "Remember me sesija", -52, 6m),
        Entry(strahinja, "Permission service", -50, 7m),
        Entry(strahinja, "Permission service", -49, 4.5m),
        Entry(nikola, "Model zaposlenih", -48, 8m),

        Entry(ana, "Forma projekata", -34, 7m),
        Entry(strahinja, "Forma projekata", -33, 8.5m),
        Entry(ana, "Forma zaposlenih", -31, 9m),
        Entry(pavle, "Forma zaposlenih", -30, 5m),
        Entry(sara, "Forma korisničkih priča", -29, 11m),
        Entry(strahinja, "Forma zadataka", -27, 6.5m),
        Entry(sara, "Forma zadataka", -26, 4m),
        Entry(pavle, "Pretraga kroz tabele", -25, 7m),

        Entry(strahinja, "Dodela zaposlenih zadatku", -13, 6m),
        Entry(nikola, "Dodela zaposlenih zadatku", -12, 5m),
        Entry(nikola, "Unos radnih sati", -10, 4.5m),
        Entry(luka, "Unos radnih sati", -9, 3m),
        Entry(luka, "Pregled preostalog rada", -8, 6m),
        Entry(sara, "Bezbedno brisanje zadataka", -7, 2.5m),

        Entry(ana, "Portal overview", -20, 7m),
        Entry(sara, "Portal overview", -19, 5m),
        Entry(sara, "Kartice isporuke", -18, 8m),
        Entry(pavle, "Klijentski filteri", -16, 4m)
      };
      db.WorkTaskEntries.AddRange(entries);

      db.SaveChanges();

      WorkTask NewTask(string name, string description, WorkTaskStatus status, decimal estimatedHours, UserStory story, Sprint? sprint, List<Employee> assignees) {
        return new WorkTask {
          Name = name,
          Description = description,
          Status = status,
          EstimatedHours = estimatedHours,
          UserStoryId = story.Id,
          SprintId = sprint?.Id,
          AssignedEmployees = assignees
        };
      }

      WorkTaskEntry Entry(Employee employee, string taskName, int daysFromNow, decimal hours) {
        return new WorkTaskEntry {
          EmployeeId = employee.Id,
          WorkTaskId = TaskByName(taskName).Id,
          WorkDate = DateTime.Now.Date.AddDays(daysFromNow),
          HoursWorked = hours
        };
      }
    }
    catch (Exception ex) {
      MessageBox.Show($"Seed propao: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }
}
