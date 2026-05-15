# Sprintra

A Windows desktop application for Scrum teams to manage sprints, track tasks, and log work.

## Features

- **Authentication** — Login with username/password, "Remember Me" support
- **Role-Based Access** — Admin, ScrumMaster, ProductOwner, Developer
- **Project Management** — Create, edit, and track project status
- **Sprint Management** — Manage sprints (Admin/ScrumMaster)
- **Employee Directory** — View team members with roles and seniority
- **Work Logging** — Track hours on tasks

## Tech Stack

| Component | Technology |
|-----------|------------|
| Framework | .NET 10.0 |
| UI | WinForms |
| UI Library | ReaLTaiizor |
| ORM | Entity Framework Core |
| Database | SQL Server |
| Auth | BCrypt.Net |

## Getting Started

```bash
# Run the app
dotnet run

# Setup database
dotnet ef database update
```

### Default Users

| Username | Password | Role |
|----------|----------|------|
| admin | admin123 | Admin |
| strahinja | sifra123 | Developer |
| nikola.dev | nikola123 | Developer |

## Database

- **Server:** `.\SQLEXPRESS`
- **Database:** `Sprintra`
- **Auth:** Windows Trusted Connection

SQL scripts available in `Src/Data/Scripts/`

## Project Structure

```
Sprintra/
├── Data/           # Models & DbContext
├── Services/       # Business logic
├── Forms/          # WinForms UI
└── Program.cs     # Entry point
```

---

*Built with .NET WinForms + Entity Framework Core*