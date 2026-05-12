namespace Sprintra.Src.Services;

using Sprintra.Src.Core;
using Sprintra.Src.Data;
using Sprintra.Src.Data.Models;

public static class AuthService {
  public static Employee? CurrentUser { get; private set; }

  public static bool Login(string username, string password, bool rememberMe) {
    using var db = new AppDbContext();
    var user = db.Employees.FirstOrDefault(u => u.Username == username);

    if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash)) {
      CurrentUser = user;
      if (rememberMe) {
        SessionManager.SaveSession(username);
      }
      return true;
    }
    return false;
  }

  public static bool TryAutoLogin() {
    string? username = SessionManager.GetSavedUsername();
    if (string.IsNullOrEmpty(username)) return false;

    using var db = new AppDbContext();
    var user = db.Employees.FirstOrDefault(u => u.Username == username);

    if (user != null) {
      CurrentUser = user;
      return true;
    }
    return false;
  }

  public static void Logout() {
    CurrentUser = null;
    SessionManager.ClearSession();
  }

  public static string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);
}