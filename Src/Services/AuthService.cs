namespace Sprintra.Src.Services;

using BCrypt.Net;
using Sprintra.Data;
using Sprintra.Src.Data.Models;
using System.Security.Cryptography;
using System.Text;

public static class AuthService {
  private static readonly string SessionFile = "userlogindata.dat";
  private static readonly byte[] additionalEntropy = [9, 2, 0, 2, 6];

  public static Employee? CurrentUser { get; private set; }

  public static bool Login(string username, string password, bool rememberMe) {
    using var db = new AppDbContext();
    var user = db.Employees.FirstOrDefault(u => u.Username == username);

    if (user != null && BCrypt.Verify(password, user.PasswordHash)) {
      CurrentUser = user;
      if (rememberMe) {
        SaveSessionToFile(username);
      }
      return true;
    }

    return false;
  }

  public static bool TryAutoLogin() {
    string username = ReadSessionFromFile();
    if (string.IsNullOrEmpty(username)) {
      return false;
    }

    using var db = new AppDbContext();
    var user = db.Employees.FirstOrDefault(u => u.Username == username);

    if (user != null) {
      CurrentUser = user;
      return true;
    }

    return false;
  }

  public static void Logout(Form form) {
    CurrentUser = null;
    if (File.Exists(SessionFile)) {
      File.Delete(SessionFile);
    }
    form.Close();
  }

  private static void SaveSessionToFile(string username) {
    try {
      string encrypted = Protect(username);
      File.WriteAllText(SessionFile, encrypted);
    }
    catch { }
  }

  private static string ReadSessionFromFile() {
    if (!File.Exists(SessionFile)) {
      return string.Empty;
    }

    try {
      string encryptedData = File.ReadAllText(SessionFile);
      return Unprotect(encryptedData);
    }
    catch {
      File.Delete(SessionFile);
      return string.Empty;
    }
  }

  private static string Protect(string data) {
    byte[] dataToEncrypt = Encoding.UTF8.GetBytes(data);
    byte[] encryptedData = ProtectedData.Protect(dataToEncrypt, additionalEntropy, DataProtectionScope.CurrentUser);

    return Convert.ToBase64String(encryptedData);
  }

  private static string Unprotect(string encryptedData) {
    try {
      byte[] dataToDecrypt = Convert.FromBase64String(encryptedData);
      byte[] decryptedData = ProtectedData.Unprotect(dataToDecrypt, additionalEntropy, DataProtectionScope.CurrentUser);
      return Encoding.UTF8.GetString(decryptedData);
    }
    catch {
      return string.Empty;
    }
  }

  public static string HashPassword(string password) => BCrypt.HashPassword(password);
}