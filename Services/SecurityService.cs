using System.Security.Cryptography;
using System.Text;

namespace Sprintra.Services;

internal class SecurityService {
  private static readonly byte[] additionalEntropy = { 9, 2, 0, 2, 6 };

  public static string Protect(string data) {
    byte[] dataToEncrypt = Encoding.UTF8.GetBytes(data);
    byte[] encryptedData = ProtectedData.Protect(dataToEncrypt, additionalEntropy, DataProtectionScope.CurrentUser);
    return Convert.ToBase64String(encryptedData);
  }

  public static string Unprotect(string encryptedData) {
    try {
      byte[] dataToDecrypt = Convert.FromBase64String(encryptedData);
      byte[] decryptedData = ProtectedData.Unprotect(dataToDecrypt, additionalEntropy, DataProtectionScope.CurrentUser);
      return Encoding.UTF8.GetString(decryptedData);
    }
    catch {
      return string.Empty;
    }
  }
}
