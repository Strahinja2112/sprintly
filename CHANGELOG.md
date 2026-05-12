# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/).

---

## [Unreleased]

### Added

### Changed

### Fixed

### Removed

---

## 2026-05-12 - Initial Setup

### Added
- Created project with .NET 10 WinForms application
- Added ReaLTaiizor 3.8.1.8 for UI components
- Added FontAwesome.Sharp 6.6.0 for icons
- Added Entity Framework Core 10.0.6 for database access
- Added BCrypt.Net-Next 4.1.0 for password hashing
- Added SQL Server Express database configuration

### Added - Data Models
- Employee model (Admin, ScrumMaster, ProductOwner, Developer roles)
- Project model with status tracking
- Sprint model linked to projects
- UserStory model with priority and status
- WorkTask model with estimated hours
- WorkTaskEntry model for work logging
- Meeting model with types (Standard, SprintPlanning, DailyStandup, SprintReview)
- Client model for user story assignment
- Distribution model for versioning
- Increment model for releases
- Feature model for feature tracking
- User model (legacy, not used)

### Added - Services
- AuthService for authentication and session management
- PermissionsService for role-based access control
- SeedService for default test data

### Added - Forms/UI
- LoginForm with username/password authentication
- MainForm with navigation and dashboard
- ProjectsForm with CRUD operations
- SprintsForm with sprint management
- EmployeesForm with employee management
- UserStoriesForm with story management
- BaseForm for shared UI functionality

### Added - Authentication Features
- Login system with encrypted session storage
- "Remember Me" functionality using DPAPI encryption
- Role-based access control (4 roles)
- Self-deletion protection for logged-in users

### Added - Documentation
- README.md with project documentation
- PROJECT_STATUS.md with current status
- LICENSE (MIT License)
- ddl.sql with database schema script

### Added - Resources
- Hawk logo image
- Logout icons (multiple sizes)

---

## Historical Development (Before Changelog Practice)

### Initial Setup
- Created .NET WinForms project structure
- Set up git repository with .gitignore

### Database Work
- Configured Entity Framework Core with migrations
- Created all entity models
- Set up SQL Server Express connection

### Authentication
- Implemented login form UI
- Added BCrypt password hashing
- Created session management with encrypted storage
- Added role-based permissions

### Project Management
- Full CRUD for projects
- Status tracking (Active, Completed, OnHold, Planned)
- Date validation and auto-completion
- Member assignment

### Sprint Management
- Sprint creation and management
- Link to projects and scrum masters
- Date-based status tracking
- Estimated work hours

### Employee Management
- Employee CRUD with role assignment
- Seniority levels (Junior, Medior, Senior, Lead)
- Field assignment (Backend, Frontend, Fullstack, QA, DevOps)
- Username uniqueness validation

### User Stories
- Basic CRUD operations
- Priority and status tracking
- Project and sprint linking
- Client assignment support

### UI Improvements
- ReaLTaiizor styling for modern look
- FontAwesome icons throughout
- Base form for consistent styling
- Seed service with test data

---

## Known Issues / Incomplete Features

- Work Log panel opens SprintsForm instead of work logging form
- WorkTask CRUD has no UI implementation
- Meeting Management has no UI
- Client Management has no UI
- Distribution/Increment/Feature management incomplete
- Full Sprint Detail View needs enhancement
- Time Tracking/Reports not implemented
- Data validation needs improvement

---

## Roadmap

### Phase 1: Core Functionality
- Fix WorkLog panel to open correct form
- Implement WorkLog form for logging hours

### Phase 2: Sprint Management
- Full sprint detail view
- Task creation/editing within sprints
- Sprint planning features
- Task assignment to employees

### Phase 3: User Stories & Requirements
- UserStory management form
- Link stories to projects
- Client assignment to stories

### Phase 4: Meetings & Collaboration
- Meeting management form
- Meeting scheduling
- Attendance tracking

### Phase 5: Time Tracking & Reporting
- Work log reports
- Sprint burndown charts
- Time tracking statistics
- Export functionality (PDF/Excel)

### Phase 6: Client Management
- Client management form
- Client portal view (read-only)
- Client feedback collection

### Phase 7: DevOps & Releases
- Distribution management
- Increment tracking
- Feature management per increment

### Phase 8: Polish & Enhancements
- Data validation
- Undo/redo functionality
- Keyboard shortcuts
- Search and filtering improvements
- Notification system
- User settings/preferences
