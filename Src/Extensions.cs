namespace Sprintra.Src;

public enum NotificationType {
  Info,
  Warning,
  Error,
  Success
}

public static class Extensions {
  extension(Form form) {
    public void ShowToast(
      string message, NotificationType type = NotificationType.Info, string? title = null
    ) {
      var actualTitle = title ?? type switch {
        NotificationType.Info => "Informacija!",
        NotificationType.Warning => "Upozorenje!",
        NotificationType.Error => "Greška!",
        _ => "Notifikacija!"
      };

      var trayIcon = new NotifyIcon() {
        Icon = SystemIcons.Application,
        Visible = true,
        Text = actualTitle
      };

      trayIcon.ShowBalloonTip(500, actualTitle, message, type switch {
        NotificationType.Info => ToolTipIcon.Info,
        NotificationType.Warning => ToolTipIcon.Warning,
        NotificationType.Error => ToolTipIcon.Error,
        _ => ToolTipIcon.Info
      });

      trayIcon.BalloonTipClosed += (s, e) => {
        trayIcon.Dispose();
      };
      trayIcon.BalloonTipClicked += (s, e) => {
        trayIcon.Dispose();
      };
    }
  }
}