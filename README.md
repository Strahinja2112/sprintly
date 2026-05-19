# Sprintly

A Windows desktop application for Scrum teams to manage sprints, track tasks, log work, and handle projects.

## Features

- **Authentication** — Login with username/password, "Remember Me" + auto-login
- **Role-Based Access** — Admin, ScrumMaster, ProductOwner, Developer
- **Project Management** — Create, edit, track project status
- **Sprint Management** — Manage sprints (Admin only)
- **Employee Directory** — View team members with roles and seniority
- **User Stories** — Manage user stories with priority (Admin/ScrumMaster/ProductOwner)
- **Work Tasks** — Track tasks within user stories (Admin/ScrumMaster)
- **Work Logging** — Log hours on tasks

## Tech Stack

| Component | Technology |
|-----------|------------|
| Framework | .NET 10.0-windows |
| UI | WinForms |
| UI Library | ReaLTaiizor 3.8.1.8 |
| Icons | FontAwesome.Sharp 6.6.0 |
| ORM | Entity Framework Core 10.0.6 |
| Database | SQL Server |
| Auth | BCrypt.Net-Next 4.1.0 |

## Getting Started

```bash
# Run the app
dotnet run
```

### Database Setup

```bash
# Apply migrations
dotnet ef database update
```

Or run SQL scripts in `Src/Data/Scripts/`
###
To seed: uncomment `SeedService.FullSeed()` in `Program.cs`

## Database

- **Server:** `.\SQLEXPRESS`
- **Database:** `Sprintra`
- **Auth:** Windows Trusted Connection

## Project Structure

```
Sprintra/
├── Program.cs                          # Entry point
├── Src/
│   ├── Data/
│   │   ├── AppDbContext.cs             # EF Core context
│   │   ├── Models/                     # Entity classes
│   │   ├── Persistance/Migrations/     # EF migrations
│   │   └── Scripts/                    # SQL (ddl.sql, script.sql)
│   ├── Services/
│   │   ├── AuthService.cs              # Login/logout/session
│   │   ├── PermissionsService.cs       # Role permissions
│   │   ├── SeedService.cs              # Test data
│   │   └── Forms/                      # Form-specific services
│   └── Forms/
│       ├── MainForm.cs                 # Dashboard
│       ├── LoginForm.cs                # Login screen
│       └── SubForms/                   # Feature forms
│           ├── ProjectsForm.cs
│           ├── SprintsForm.cs
│           ├── EmployeesForm.cs
│           ├── UserStoriesForm.cs
│           └── WorkTasksForm.cs
```

## Entity Models

- **Employee** — Users with Type, SeniorityLevel, Field
- **Project** — Name, Description, Status, Start/End dates
- **Sprint** — Name, Goal, Status, estimated hours
- **UserStory** — Title, Description, Priority, linked to Project
- **WorkTask** — Name, Description, Status, EstimatedHours, linked to UserStory
- **WorkTaskEntry** — Hours logged per employee/task/date
- **Meeting** — Sprint meetings with type, attendees
- **Distribution** — Version, Environment (Web/Mobile/Desktop/API)
- **Increment** — Release versions linked to Distribution
- **Feature** — Features linked to Sprint + Increment

## EF Core Commands

```bash
# Create migration
dotnet ef migrations add MigrationName

# Apply migrations
dotnet ef database update

# Drop database
dotnet ef database drop

# Generate SQL script
dotnet ef migrations script
```

---

*Built with .NET WinForms + Entity Framework Core*