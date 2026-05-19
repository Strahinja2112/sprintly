namespace Sprintly.Src.Services;

using Sprintly.Src.Data.Models;

public static class PermissionsService {
  private static bool HasAnyRole(params EmployeeType[] allowedRoles) {
    if (AuthService.CurrentUser == null) {
      return false;
    }

    if (allowedRoles.Length == 0) {
      return true;
    }

    return allowedRoles.Contains(AuthService.CurrentUser.Type);
  }

  private static bool CurrentUserHasAtleastRole(EmployeeType requiredRole) {
    if (AuthService.CurrentUser == null) {
      return false;
    }
    return AuthService.CurrentUser.Type >= requiredRole;
  }

  public static bool IsCurrentUserAdmin() => HasAnyRole(EmployeeType.Admin);

  public static bool CanCurrentUserManageUsers() => IsCurrentUserAdmin();

  public static bool CanCurrentUserManageProjects() => IsCurrentUserAdmin();

  public static bool CanCurrentUserLogWork() => HasAnyRole();

  public static bool CanCurrentUserManageSprints() => HasAnyRole(EmployeeType.Admin);

  public static bool CanCurrentUserManageUserStories() => CurrentUserHasAtleastRole(EmployeeType.ProductOwner);

  public static bool CanCurrentUserManageWorkTasks() => CurrentUserHasAtleastRole(EmployeeType.ProductOwner);

  public static bool CanCurrentUserManageForm(Type formType) {
    return formType.Name switch {
      "EmployeesForm" => CanCurrentUserManageUsers(),
      "ProjectsForm" => CanCurrentUserManageProjects(),
      "SprintsForm" => CanCurrentUserManageSprints(),
      "UserStoriesForm" => CanCurrentUserManageUserStories(),
      "WorkTasksForm" => CanCurrentUserManageWorkTasks(),
      "WorkLogForm" => CanCurrentUserLogWork(),
      _ => false
    };
  }
}