# Subform Delete Behavior Plan

## Summary

Delete actions should preserve project history and avoid accidental cascade deletion. A selected item should only be hard-deleted when it has no meaningful dependent records. If dependent records exist, the UI should either block deletion with a clear message, require the user to delete or move dependent records first, or use a safer domain action such as unassigning, cancelling, archiving, or deactivating.

The current code already has delete handlers for Employees, Projects, and Sprints. User Stories and Work Tasks have visible delete buttons in the designer, but those buttons are not currently wired to handlers.

## Global Rules

- Always require a selected row before attempting delete.
- Always show a confirmation dialog before a destructive delete.
- Do not rely only on database cascade behavior for user-facing delete decisions.
- Prefer blocking hard delete for anything with logged work, completed work, or sprint/project history.
- After successful delete or alternative action, clear the right-side form, refresh the grid, and collapse the panel if it was expanded.
- Keep permission behavior consistent with existing `PermissionsService.CanCurrentUserManageForm(...)` checks.

## Employees

Source: `Src/Forms/SubForms/EmployeesForm.cs`

### Delete Selected Employee

Hard-delete the selected employee only when all of these are true:

- The selected employee exists.
- The selected employee is not the currently logged-in user.
- The employee has no work log entries.
- The employee is not assigned as a Scrum Master on any sprint.
- The employee has no blocking meeting attendance records.

### Use Another Action Instead

- If the selected employee is the current user, block deletion.
- If the employee has work log entries, do not hard-delete; deactivate the employee instead, or require an explicit archive/deactivation workflow.
- If the employee is assigned to work tasks, remove task assignment links before deleting.
- If the employee is a Scrum Master on any sprint, block deletion until those sprints are reassigned.
- If the employee is a meeting attendee, remove attendance links first or block deletion if meeting history must remain immutable.

### Implementation Notes

- The current handler already blocks deleting the current user.
- EF currently cascades `WorkTaskEntry.EmployeeId`, which would delete logged work if an employee is deleted. The UI should block this.
- EF currently cascades `Sprint.ScrumMasterId`, which risks deleting sprints when a Scrum Master is deleted. This should be treated as unsafe behavior and blocked in the UI.
- Meeting attendees use `NoAction`, so deleting an employee with meeting attendance may fail unless attendance links are removed first.

## Projects

Source: `Src/Forms/SubForms/ProjectsForm.cs`

### Delete Selected Project

Hard-delete the selected project only when all of these are true:

- The selected project exists.
- The project has no sprints.
- The project has no user stories.
- The project has no dependent work tasks reachable through user stories.

### Use Another Action Instead

- If the project has sprints, block deletion and tell the user to delete or resolve sprints first.
- If the project has user stories, block deletion and tell the user to delete or resolve user stories and tasks first.
- For completed or historically meaningful projects, prefer marking the project `Completed` or `OnHold` over hard delete.

### Implementation Notes

- The current handler blocks deletion when sprints exist.
- Add a user-story dependency check before deleting.
- EF has cascade paths from project to sprints and user stories, so hard-delete should only be allowed for empty projects.

## Sprints

Source: `Src/Forms/SubForms/SprintsForm.cs` and `Src/Services/Forms/SprintsService.cs`

### Delete Selected Sprint

Hard-delete the selected sprint only when all of these are true:

- The selected sprint exists.
- The sprint status is `Planned`.
- The sprint has no work tasks.
- The sprint has no meetings.
- The sprint has no features.

### Use Another Action Instead

- If the sprint has work tasks, block deletion and require moving/removing those tasks first.
- If the sprint is `Active`, use the finish/cancel workflow instead of hard delete.
- If the sprint is `Completed`, never hard-delete from the normal UI.
- If the sprint has meetings or features, block deletion until those records are resolved or explicitly deleted through their owning workflow.

### Implementation Notes

- The current service blocks deletion when work tasks exist.
- The current service blocks deletion unless the sprint is `Planned`.
- The existing `DeleteSprintAsync` sets `task.SprintId = null` before checking `sprint.WorkTasks.Count`; this is misleading because deletion is still blocked. Move or remove that loop unless a real detach-and-delete behavior is intentionally added.
- EF uses `NoAction` for `WorkTask.SprintId`, so a sprint with tasks should not be deleted without explicitly moving tasks.

## User Stories

Source: `Src/Forms/SubForms/UserStoriesForm.cs` and `Src/Forms/SubForms/UserStoriesForm.Designer.cs`

### Delete Selected User Story

Hard-delete the selected user story only when all of these are true:

- The selected user story exists.
- The user story has no work tasks.

### Use Another Action Instead

- If the user story has work tasks, block deletion and tell the user to delete, move, or otherwise resolve those tasks first.
- If any task under the story has logged work, do not allow cascading deletion from the user story.

### Implementation Notes

- The delete button exists but is not wired to a click handler.
- Add a delete method to `UserStoriesService`.
- The service should load or count related work tasks before deleting.
- EF currently cascades `UserStory -> WorkTask -> WorkTaskEntry`, so the UI must not blindly delete a user story with tasks.

## Work Tasks

Source: `Src/Forms/SubForms/WorkTasksForm.cs`, `Src/Forms/SubForms/WorkTasksForm.Designer.cs`, and `Src/Services/Forms/WorkTasksService.cs`

### Delete Selected Work Task

Hard-delete the selected work task only when all of these are true:

- The selected work task exists.
- The task has no work log entries.

### Use Another Action Instead

- If the task has work log entries, do not hard-delete; mark it `Cancelled` instead.
- If the task has assigned employees but no work log entries, clear assignment links as part of deletion.
- If the task is `Done`, prefer keeping it for history instead of deleting it.

### Implementation Notes

- The delete button exists but is not wired to a click handler.
- `WorkTasksService.DeleteTaskAsync` currently removes the task directly.
- Update delete logic to check `WorkTaskEntries` first.
- If delete is allowed, include assigned employees so the many-to-many links can be cleared before removal.
- If delete is not allowed because work was logged, provide a cancel action or update the task status to `Cancelled`.

## Work Log

Source: `Src/Forms/SubForms/WorkLogForm.cs`

There is no delete button in the Work Log subform. It only creates work log entries.

If a future delete action is added for work log entries, it should be restricted and explicit because work logs are audit/history data. A safer default is to allow corrections through an adjustment entry rather than hard deletion.

## Test Plan

- Verify each delete button with no selected row shows a warning and does not mutate data.
- Verify employee delete blocks the current user.
- Verify employee delete blocks employees with work logs or Scrum Master assignments.
- Verify employee delete either clears task assignment links or blocks until assignments are removed.
- Verify project delete succeeds for an empty project.
- Verify project delete blocks projects with sprints.
- Verify project delete blocks projects with user stories even if there are no sprints.
- Verify sprint delete succeeds for a planned sprint with no tasks, meetings, or features.
- Verify sprint delete blocks active and completed sprints.
- Verify sprint delete blocks sprints with work tasks.
- Verify user story delete succeeds only when no work tasks exist.
- Verify user story delete blocks when tasks exist and does not cascade-delete task history.
- Verify work task delete succeeds when no work logs exist.
- Verify work task delete clears assigned employees when hard-delete is allowed.
- Verify work task delete blocks or cancels tasks that have logged work.
- Verify all successful actions refresh grids and clear/collapse the edit panel consistently.

## Assumptions

- Hard delete is acceptable only for empty or not-yet-used planning records.
- Work logs are historical records and should not be deleted through parent-record cascades.
- Completed sprints, completed tasks, and completed projects should normally remain available for history.
- Deactivation/cancellation is preferred over deletion when a record has business history.
