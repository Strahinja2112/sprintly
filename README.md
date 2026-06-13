# Sprintly

Sprintly is a Windows desktop application for Scrum teams to manage projects, sprints, user stories, work tasks, assigned employees, and logged work time.

## Features

- Authentication with username/password, remembered sessions, and logout.
- Role-based access for `Admin`, `ScrumMaster`, `ProductOwner`, and `Developer`.
- Project management with status and start/end dates.
- Sprint management by project, including planned, active, completed, and canceled sprints.
- Employee directory with role, seniority, and field information.
- User story management with project filtering and priority.
- Work task management with sprint filtering, user-story linkage, employee assignment, status, and estimated hours.
- Work logging for assigned tasks, including remaining-hours calculation.
- Guarded delete behavior to avoid removing records that still have dependent work history.

## Tech Stack

| Component | Technology |
| --- | --- |
| Framework | .NET 10.0 Windows |
| UI | WinForms |
| UI Library | ReaLTaiizor 3.8.1.8 |
| Icons | FontAwesome.Sharp 6.6.0 |
| ORM | Entity Framework Core 10.0.6 |
| Database | SQL Server Express |
| Auth | BCrypt.Net-Next 4.1.0 |
| Notifications | Microsoft.Toolkit.Uwp.Notifications 7.1.3 |

## Getting Started

Requirements:

- Windows
- .NET 10 SDK
- SQL Server Express available as `.\SQLEXPRESS`

Run the app:

```bash
dotnet run
```

Apply migrations:

```bash
dotnet ef database update
```

Generate a fresh SQL script from the current EF model:

```bash
dotnet ef dbcontext script -o Src/Data/Scripts/script.sql
```

Optional seed flow:

- Open `Program.cs`.
- Uncomment the `SeedService.FullSeed()` block inside `Main()`.
- Run the app once.
- Comment the seed block again before normal use.

## Database

The EF connection string is configured in `Src/Data/AppDbContext.cs`:

- Server: `.\SQLEXPRESS`
- Database: `Sprintra`
- Auth: Windows trusted connection
- Trust server certificate: enabled

## Current Entity Model

- `Employee`: application user with login credentials, type, status, seniority, field, project memberships, and assigned tasks.
- `Project`: named work container with description, status, dates, members, and sprints.
- `Sprint`: project sprint with name, goal, Scrum Master, dates, estimated work hours, status, and work tasks.
- `UserStory`: project-scoped requirement with title, description, priority, and work tasks.
- `WorkTask`: user-story task with optional sprint, status, estimate, assigned employees, and work log entries.
- `WorkTaskEntry`: logged work for an employee on a work task at a specific date.

Removed legacy model areas:

- Meetings are no longer part of the current app model.
- Distribution, increment, and feature entities are no longer part of the current `AppDbContext`.

## Role Access

- `Admin`: manages employees, projects, sprints, user stories, work tasks, and work logs.
- `ProductOwner`: manages user stories and work tasks, and can log work.
- `ScrumMaster`: manages user stories and work tasks, and can log work.
- `Developer`: can log work.

Access checks are centralized in `Src/Services/PermissionsService.cs`.

## Project Structure

```text
Sprintly/
|-- Program.cs
|-- Sprintly.csproj
|-- Src/
|   |-- Data/
|   |   |-- AppDbContext.cs
|   |   |-- Models/
|   |   |-- Persistance/Migrations/
|   |   `-- Scripts/
|   |-- Forms/
|   |   |-- BaseForm.cs
|   |   |-- LoginForm.cs
|   |   |-- MainForm.cs
|   |   |-- Panels/
|   |   `-- SubForms/
|   `-- Services/
|       |-- AuthService.cs
|       |-- PermissionsService.cs
|       |-- SeedService.cs
|       `-- Forms/
|-- Properties/
`-- Resources/
```

## Main Forms

- `LoginForm`: user login and remembered-session entry point.
- `MainForm`: dashboard and navigation shell.
- `EmployeesForm`: employee CRUD.
- `ProjectsForm`: project CRUD.
- `SprintsForm`: sprint planning, finishing, and deletion rules.
- `UserStoriesForm`: project-scoped user story CRUD.
- `WorkTasksForm`: task CRUD and employee assignment.
- `WorkLogForm`: logged work entry for assigned tasks.

## EF Core Commands

```bash
# Add a migration
dotnet ef migrations add MigrationName

# Apply migrations to the configured database
dotnet ef database update

# Drop the configured database
dotnet ef database drop

# Generate SQL for migrations
dotnet ef migrations script

# Generate SQL for the current model
dotnet ef dbcontext script
```
