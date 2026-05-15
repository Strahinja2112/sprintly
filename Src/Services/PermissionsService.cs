namespace Sprintra.Src.Services;

using Sprintra.Src.Data.Models;

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

  private static bool HasAtleastRole(EmployeeType requiredRole) {
    if (AuthService.CurrentUser == null) {
      return false;
    }
    return AuthService.CurrentUser.Type >= requiredRole;
  }

  public static bool IsAdmin() => HasAnyRole(EmployeeType.Admin);

  public static bool CanManageUsers() => IsAdmin();

  public static bool CanManageProjects() => IsAdmin();

  public static bool CanLogWork() => HasAnyRole();

  public static bool CanManageSprints() => HasAnyRole(EmployeeType.Admin);

  public static bool CanManageUserStories() => HasAtleastRole(EmployeeType.ProductOwner);

  public static bool CanManageWorkTasks() => HasAtleastRole(EmployeeType.ProductOwner);
}