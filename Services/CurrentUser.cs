using Sprintra.Models;

namespace Sprintra.Services;

internal class CurrentUser {
  public static User? Details { get; private set; }
  public static bool IsLoggedIn => Details != null;

  public static void Initialize(User user) {
    Details = user;
  }

  public static void Logout() {
    Details = null;
  }
}
