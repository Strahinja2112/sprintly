namespace Sprintra.Services;

using BCrypt.Net;
using Sprintra.Data;
using Sprintra.Models;

public static class AuthService {
  public static Employee? CurrentUser { get; private set; } = null;
  public static bool IsLoggedIn => CurrentUser != null;

  public static bool Login(string username, string password) {
    using var db = new AppDbContext();

    var user = db.Employees.FirstOrDefault(u => u.Username == username);

    if (user != null && BCrypt.Verify(password, user.PasswordHash)) {
      CurrentUser = user;
      return true;
    }

    return false;
  }

  public static void Logout() {
    CurrentUser = null;
  }

  public static string HashPassword(string password) {
    return BCrypt.HashPassword(password);
  }
}