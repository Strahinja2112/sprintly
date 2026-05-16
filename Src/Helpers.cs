using System.ComponentModel;
using System.Reflection;

namespace Sprintra.Src;

public enum TimeUnit {
  Seconds,
  Minutes,
  Hours,
  Days,
  Weeks
}

public enum NotificationType {
  Info,
  Warning,
  Error,
  Success
}

public static class Helpers {
  private static readonly List<NotifyIcon> activeIcons = [];

  public static long CalculateTimeBetween(
    DateTime startDate, DateTime? endDate, TimeUnit? unit = TimeUnit.Days
  ) {
    if (endDate is null) {
      return 0;
    }

    TimeSpan timeSpan = (DateTime)endDate - startDate;

    return unit switch {
      TimeUnit.Seconds => (long)timeSpan.TotalSeconds,
      TimeUnit.Minutes => (long)timeSpan.TotalMinutes,
      TimeUnit.Hours => (long)timeSpan.TotalHours,
      TimeUnit.Days => (long)timeSpan.TotalDays,
      TimeUnit.Weeks => (long)(timeSpan.TotalDays / 7),
      _ => throw new ArgumentOutOfRangeException(nameof(unit), unit, null)
    };
  }

  public static void ClearClickEvents(Control control) {
    FieldInfo? f1 = typeof(Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);
    if (f1 == null) {
      return;
    }

    object? obj = f1.GetValue(control);
    PropertyInfo? pi = typeof(Control).GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
    if (pi == null) {
      return;
    }

    EventHandlerList? list = (EventHandlerList?)pi.GetValue(control, null);
    if (list != null && obj != null) {
      list.RemoveHandler(obj, list[obj]);
    }
  }

  public static void ShowToast(
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

    activeIcons.Add(trayIcon);

    trayIcon.ShowBalloonTip(500, actualTitle, message, type switch {
      NotificationType.Info => ToolTipIcon.Info,
      NotificationType.Warning => ToolTipIcon.Warning,
      NotificationType.Error => ToolTipIcon.Error,
      _ => ToolTipIcon.Info
    });

    trayIcon.BalloonTipClosed += (s, e) => {
      activeIcons.Remove(trayIcon);
      trayIcon.Dispose();
    };
    trayIcon.BalloonTipClicked += (s, e) => {
      activeIcons.Remove(trayIcon);
      trayIcon.Dispose();
    };
  }
}
