# Sprintra

A Windows desktop application for Scrum teams. Manage sprints, track tasks, log work, and collaborate — all through a clean, native WinForms interface.

## Table of Contents

- [Project Overview](#project-overview)
- [Tech Stack](#tech-stack)
- [Architecture](#architecture)
- [Data Models](#data-models)
- [User Roles & Permissions](#user-roles--permissions)
- [Features](#features)
- [Database](#database)
- [Getting Started](#getting-started)
- [Entity Framework Core Commands](#entity-framework-core-commands)
- [Project Structure](#project-structure)
- [Development Roadmap](#development-roadmap)

---

## Project Overview

**Sprintra** is a Windows desktop application built with C# and WinForms that helps Scrum teams manage their projects, sprints, and tasks. It provides a native Windows experience with role-based access control and comprehensive project management features.

---

## Tech Stack

| Component | Technology |
|-----------|------------|
| Framework | .NET 10.0-windows |
| UI | WinForms |
| UI Library | ReaLTaiizor 3.8.1.8 |
| Icons | FontAwesome.Sharp 6.6.0 |
| ORM | Entity Framework Core 10.0.6 |
| Database | SQL Server |
| Password Hashing | BCrypt.Net-Next 4.1.0 |

---

## Architecture

```
Sprintra/
├── Data/
│   ├── Models/          # Entity models
│   └── AppDbContext.cs  # EF Core context
├── Services/            # Business logic
│   ├── AuthService.cs
│   ├── PermissionsService.cs
│   └── SeedService.cs
├── Forms/               # WinForms UI
│   ├── MainForm.cs
│   ├── LoginForm.cs
│   ├── ProjectsForm.cs
│   ├── SprintsForm.cs
│   └── EmployeesForm.cs
├── Properties/          # Resources
└── Resources/           # Images, icons
```

---

## Data Models

### Employee
- `Id`, `FirstName`, `LastName`, `Email`, `Phone`
- `Username`, `PasswordHash`
- `Type` (Admin, ScrumMaster, ProductOwner, Developer)
- `SeniorityLevel` (Junior, Medior, Senior, Lead)
- `Field` (Backend, Frontend, Fullstack, QA, DevOps)
- `Status`, `HireDate`, `TeamRole`

### Project
- `Id`, `Name`, `Description`
- `Status` (Active, Completed, OnHold, Planned)
- `StartDate`, `EndDate`
- `Members` (Many-to-Many with Employee)
- `Sprints` (One-to-Many)

### Sprint
- `Id`, `Name`, `Goal`
- `ProjectId` (FK to Project)
- `ScrumMasterId` (FK to Employee)
- `StartDate`, `EndDate`
- `EstimatedWorkHours`
- `Status` (Planned, Active, Completed, Canceled)
- `WorkTasks`, `Meetings`

### WorkTask
- `Id`, `Name`, `Description`
- `Status`, `EstimatedHours`
- `UserStoryId` (FK), `SprintId` (FK)
- `WorkLogEntries` (WorkTaskEntry collection)

### UserStory
- `Id`, `Title`, `Description`
- `Priority`, `Status`
- `ClientId` (FK - optional)
- `WorkTasks`

### WorkTaskEntry (Join Table)
- `EmployeeId`, `WorkTaskId`, `WorkDate`
- `HoursWorked`
- Composite key: (EmployeeId, WorkTaskId, WorkDate)

### Meeting
- `Id`, `SprintId` (FK)
- `DateTime`, `DurationMinutes`
- `Type` (Standard, SprintPlanning, DailyStandup, SprintReview)
- `Description`, `SprintGoal`, `Feedback`
- `Attendees` (Many-to-Many with Employee)

### Client
- `Id`, `FirstName`, `LastName`, `Email`, `Phone`
- `UserStories`

### Distribution
- `Id`, `Version`
- `Environment` (Web, Mobile, Desktop, Api)
- `Increments`

### Increment
- `Id`, `DistributionId` (FK)
- `CreatedAt`, `Status`
- `Features`

### Feature
- `Id`, `SprintId`, `IncrementId` (FKs)
- `Name`, `Description`

---

## User Roles & Permissions

| Permission | Admin | ScrumMaster | Developer | ProductOwner |
|------------|-------|-------------|-----------|--------------|
| Manage Projects | ✓ | ✗ | ✗ | ✗ |
| Manage Sprints | ✓ | ✓ | ✗ | ✗ |
| Manage Users | ✓ | ✗ | ✗ | ✗ |
| Log Work | ✓ | ✓ | ✓ | ✓ |

---

## Features

### Implemented
- **Authentication**: Login with username/password, "Remember Me" functionality
- **Authorization**: Role-based access control
- **Project Management**: Create, edit, delete projects with status tracking
- **Sprint Management**: View and manage sprints (Admin/ScrumMaster only)
- **Employee Management**: View employees with role/seniority info (Admin only)
- **Session Management**: Auto-login with encrypted session storage

### Pending/Incomplete
- Work logging functionality (PanelWorkLog_Click opens SprintsForm)
- Full sprint detail view with task management
- User story management
- Meeting scheduling
- Time tracking and reporting
- Client management
- Distribution/Increment/Feature tracking

---

## Database

- **Server**: `.\SQLEXPRESS`
- **Database**: `Sprintra`
- **Authentication**: Windows Trusted Connection
- **Connection String**: `Server={MachineName}\SQLEXPRESS;Database=Sprintra;Trusted_Connection=True;TrustServerCertificate=True;`

---

## Getting Started

### Prerequisites
- .NET 10.0 SDK
- SQL Server (with SQLEXPRESS instance)
- Visual Studio 2022+ or VS Code

### Setup
1. Clone the repository
2. Ensure SQL Server is running
3. Run migrations:
   ```bash
   dotnet ef database update
   ```
4. (Optional) Seed initial data:
   ```csharp
   // In Program.cs, uncomment:
   // SeedService.FullSeed();
   ```
5. Run the application:
   ```bash
   dotnet run
   ```

### Default Users (after seeding)
| Username | Password | Role |
|----------|----------|------|
| admin | admin123 | Admin |
| strahinja | sifra123 | Developer (Senior, Fullstack) |
| nikola.dev | nikola123 | Developer (Junior, Backend) |

---

## Entity Framework Core Commands

All commands run from the project root (where `.csproj` is located).

### Migrations
```bash
# Create new migration (after model changes)
dotnet ef migrations add MigrationName

# Apply migrations to database
dotnet ef database update

# Remove last migration (if not applied)
dotnet ef migrations remove

# Revert to specific migration
dotnet ef database update PreviousMigrationName
```

### Database Maintenance
```bash
# Drop entire database
dotnet ef database drop

# Reset database (drop + recreate)
dotnet ef database drop && dotnet ef database update

# Generate SQL script (for manual execution in SSMS)
dotnet ef migrations script
```

---

## Project Structure

```
Sprintra/
├── Sprintra.csproj
├── Sprintra.slnx
├── Program.cs                    # Application entry point
├── LICENSE
├── README.md
├── Data/
│   ├── AppDbContext.cs           # EF Core DbContext
│   ├── Models/
│   │   ├── Client.cs
│   │   ├── Distribution.cs
│   │   ├── Employee.cs
│   │   ├── Feature.cs
│   │   ├── Increment.cs
│   │   ├── Meeting.cs
│   │   ├── Project.cs
│   │   ├── Sprint.cs
│   │   ├── User.cs
│   │   ├── UserStory.cs
│   │   ├── WorkTask.cs
│   │   └── WorkTaskEntry.cs
│   └── Scripts/
│       └── dml.sql
├── Services/
│   ├── AuthService.cs            # Authentication logic
│   ├── PermissionsService.cs     # Role-based permissions
│   └── SeedService.cs            # Database seeding
├── Forms/
│   ├── BaseForm.cs               # Base form with common functionality
│   ├── MainForm.cs               # Main dashboard
│   ├── LoginForm.cs              # Login screen
│   ├── ProjectsForm.cs           # Project management
│   ├── SprintsForm.cs            # Sprint management
│   └── EmployeesForm.cs          # Employee viewing
├── Properties/
│   ├── Resources.resx
│   └── Resources.Designer.cs
└── Resources/
    ├── hawk-logo.jpg
    ├── logout.png
    ├── logout-small.png
    └── logout-35.png
```

---

## Development Roadmap

Use these Trello-style cards to plan future development:

### Phase 1: Core Functionality
- [ ] Fix WorkLog panel to open correct form (not SprintsForm)
- [ ] Implement WorkLog form for logging hours on tasks

### Phase 2: Sprint Management
- [ ] Create full sprint detail view
- [ ] Add task creation/editing within sprints
- [ ] Implement sprint planning features
- [ ] Add task assignment to employees

### Phase 3: User Stories & Requirements
- [ ] Create UserStory management form
- [ ] Link user stories to projects
- [ ] Add client assignment to stories

### Phase 4: Meetings & Collaboration
- [ ] Implement Meeting management form
- [ ] Add meeting scheduling
- [ ] Track meeting attendance

### Phase 5: Time Tracking & Reporting
- [ ] Create work log reports
- [ ] Add sprint burndown charts
- [ ] Implement time tracking statistics
- [ ] Export functionality (PDF/Excel)

### Phase 6: Client Management
- [ ] Create Client management form
- [ ] Add client portal view (read-only for Product Owners)
- [ ] Client feedback collection

### Phase 7: DevOps & Releases
- [ ] Create Distribution management
- [ ] Implement Increment tracking
- [ ] Add Feature management per increment

### Phase 8: Polish & Enhancements
- [ ] Add data validation across all forms
- [ ] Implement undo/redo for edits
- [ ] Add keyboard shortcuts
- [ ] Improve search and filtering
- [ ] Add notification system
- [ ] Create user settings/preferences

---

## Notes for AI Agent

When helping plan or implement features for Sprintra:

1. **UI Framework**: This is a WinForms application using ReaLTaiizor for modern UI components. Avoid WPF or web technologies.

2. **Database**: SQL Server with Entity Framework Core. All data access goes through `AppDbContext`.

3. **Authentication**: Uses `AuthService` for login/logout/session management. Password hashing with BCrypt.

4. **Permissions**: Use `PermissionsService` to check user capabilities before showing/hiding features.

5. **Forms Pattern**: All forms inherit from `BaseForm` for common functionality. Child forms are loaded into `PanelMainContent` in MainForm.

6. **Naming**: Code uses Serbian/Croatian naming for UI elements (labels, buttons) but English for code (classes, methods, properties).

7. **Enums**: Important enums include `EmployeeType`, `ProjectStatus`, `SprintStatus`, `MeetingType`, `SeniorityLevel`, `Field`, `DistributionEnvironment`.

8. **Seed Data**: `SeedService.FullSeed()` can be called to populate test data. Currently commented out in Program.cs.