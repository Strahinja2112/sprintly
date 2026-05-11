# Sprintra - Project Status Summary

## Overview
Sprintra is a Windows desktop application for Scrum teams to manage sprints, track tasks, log work, and collaborate through a WinForms interface.

**Tech Stack:**
- .NET 10.0 (Windows)
- WinForms with ReaLTaiizor UI library
- SQL Server with Entity Framework Core
- BCrypt for password hashing

---

## Current Status: IN PROGRESS

### Completed Features

1. **Authentication System**
   - Login with username/password
   - "Remember Me" (auto-login) with encrypted session storage
   - Logout functionality

2. **Authorization & Permissions**
   - Role-based access control (Admin, ScrumMaster, ProductOwner, Developer)
   - Permission service for feature visibility

3. **Project Management (Admin only)**
   - Create, edit, delete projects
   - Status tracking (Active, Completed, OnHold, Planned)
   - Start/End date tracking

4. **Sprint Management (Admin + ScrumMaster)**
   - View and manage sprints
   - Link sprints to projects
   - Assign Scrum Master

5. **Employee Management (Admin only)**
   - View employees with role/seniority info
   - Employee types and seniority levels defined

6. **User Stories**
   - UserStoriesForm exists and can be opened
   - Linked to Projects and Sprints

7. **Database Schema**
   - All models defined with EF Core migrations
   - Relationships properly configured

### Implemented Entities/Models:
- Employee (with Type, SeniorityLevel, Field enums)
- Project (with Status enum)
- Sprint (with Status enum)
- UserStory (with Priority, Status)
- WorkTask
- WorkTaskEntry (join table for time logging)
- Meeting (with Type enum, attendee many-to-many)
- Client
- Distribution (with Environment enum)
- Increment
- Feature

### Implemented Services:
- `AuthService` - Authentication, auto-login, session management
- `PermissionsService` - Role-based permission checks
- `SeedService` - Database seeding (not active)

### Forms Implemented:
- LoginForm (entry point)
- MainForm (dashboard with navigation)
- ProjectsForm (project CRUD)
- SprintsForm (sprint management)
- EmployeesForm (employee viewing)
- UserStoriesForm (user story management)
- BaseForm (base class with common functionality)

---

## Incomplete / Known Issues

1. **Work Log Panel** - Currently opens SprintsForm instead of actual work logging form
2. **WorkTask CRUD** - Not implemented in UI, model exists
3. **Meeting Management** - Not implemented in UI, model exists
4. **Client Management** - Not implemented in UI, model exists
5. **Distribution/Increment/Feature** - Not implemented in UI, models exist
6. **Full Sprint Detail View** - Basic SprintsForm exists but needs enhancement
7. **Time Tracking/Reports** - Not implemented
8. **Data Validation** - Needs improvement across forms

---

## Project Structure
```
Sprintra/
├── Program.cs                    # Entry point
├── Sprintra.csproj              # Project file
├── Data/
│   ├── AppDbContext.cs          # EF Core context
│   ├── Models/                  # 11 entity models
│   └── Persistance/Migrations/  # EF Core migrations
├── Services/
│   ├── AuthService.cs           # Authentication
│   ├── PermissionsService.cs    # Authorization
│   └── SeedService.cs           # Database seeding
├── Forms/                       # 6 WinForms + BaseForm
├── Properties/                   # Resources
└── Resources/                   # Images
```

---

## Database
- Server: `.\SQLEXPRESS`
- Database: `Sprintra`
- Authentication: Windows Trusted Connection

---

## How to Run
1. Ensure SQL Server (SQLEXPRESS) is running
2. Run `dotnet ef database update` to apply migrations
3. Optionally uncomment `SeedService.FullSeed()` in Program.cs
4. Run `dotnet run`

---

## User Roles & Permissions
| Feature | Admin | ScrumMaster | Developer | ProductOwner |
|---------|-------|-------------|-----------|---------------|
| Manage Projects | ✓ | ✗ | ✗ | ✗ |
| Manage Sprints | ✓ | ✓ | ✗ | ✗ |
| Manage Users | ✓ | ✗ | ✗ | ✗ |
| Log Work | ✓ | ✓ | ✓ | ✓ |

---

## Default Test Users (after seeding)
- admin / admin123 (Admin)
- strahinja / sifra123 (Developer, Senior, Fullstack)
- nikola.dev / nikola123 (Developer, Junior, Backend)

---

## Next Steps (Suggested)
1. Fix WorkLog panel to open proper work logging form
2. Implement WorkTask management within sprints
3. Create Meeting management form
4. Create Client management form
5. Add WorkTaskEntry form for time logging
6. Implement reporting/time tracking features
7. Add data validation
8. Polish UI/UX