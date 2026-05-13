# Changelog

All notable changes to this project will be documented in this file.

---

## 2026-05-12

### Removed
- Client entity and related references

### Refactored
- Helpers utility for date difference calculations
- Moved towards services architecture
- Refactored folder structure for better organization

---

## Up To 2026-05-12 (First date to keep track)

### Added
- Login system with username/password authentication
- Session management with "Remember Me" (encrypted with DPAPI)
- Role-based access control (Admin, ScrumMaster, ProductOwner, Developer)
- Employee management (CRUD, roles, seniority, field assignment)
- Project management (CRUD, status tracking, member assignment)
- Sprint management (CRUD, linked to projects, scrum master assignment)
- User story management (CRUD, priority, status, project/sprint linking)
- Database with Entity Framework Core and SQL Server Express
- Default seed data (admin, strahinja, nikola.dev accounts)
- WorkTask and WorkTaskEntry models (backend only, no UI yet)
- Meeting model with types (backend only, no UI yet)
- Client, Distribution, Increment, Feature models (backend only)

### Known Issues
- Work Log panel opens SprintsForm instead of work logging form
- WorkTask CRUD has no UI implementation
- Meeting Management has no UI
- Client Management has no UI
- Distribution/Increment/Feature management incomplete

