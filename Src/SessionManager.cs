namespace Sprintra.Src;

using System.Security.Cryptography;
using System.Text;

public static class SessionManager {
  private static readonly string SessionFile = "userlogindata.dat";
  private static readonly byte[] additionalEntropy = [9, 2, 0, 2, 6];

  public static void SaveSession(string username) {
    try {
      byte[] dataToEncrypt = Encoding.UTF8.GetBytes(username);
      byte[] encryptedData = ProtectedData.Protect(dataToEncrypt, additionalEntropy, DataProtectionScope.CurrentUser);
      File.WriteAllText(SessionFile, Convert.ToBase64String(encryptedData));
    }
    catch { }
  }

  public static string? GetSavedUsername() {
    if (!File.Exists(SessionFile)) {
      return null;
    }

    try {
      byte[] dataToDecrypt = Convert.FromBase64String(File.ReadAllText(SessionFile));
      byte[] decryptedData = ProtectedData.Unprotect(dataToDecrypt, additionalEntropy, DataProtectionScope.CurrentUser);
      return Encoding.UTF8.GetString(decryptedData);
    }
    catch {
      ClearSession();
      return null;
    }
  }

  public static void ClearSession() {
    if (File.Exists(SessionFile)) {
      File.Delete(SessionFile);
    }
  }
}
