namespace Sprintra.Services;

using Sprintra.Data.Models;

public static class PermissionsService {
  public static bool CanManageProjects() {
    if (AuthService.CurrentUser == null) {
      return false;
    }

    return AuthService.CurrentUser.Type == EmployeeType.Admin;
  }

  public static bool CanManageSprints() {
    if (AuthService.CurrentUser == null) {
      return false;
    }

    return AuthService.CurrentUser.Type == EmployeeType.Admin ||
           AuthService.CurrentUser.Type == EmployeeType.ScrumMaster;
  }

  public static bool CanManageUsers() {
    if (AuthService.CurrentUser == null) {
      return false;
    }

    return AuthService.CurrentUser.Type == EmployeeType.Admin;
  }

  public static bool CanLogWork() {
    if (AuthService.CurrentUser == null) {
      return false;
    }

    return true;
  }

  public static bool IsAdmin() {
    if (AuthService.CurrentUser == null) {
      return false;
    }

    return AuthService.CurrentUser.Type == EmployeeType.Admin;
  }
}