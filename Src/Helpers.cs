namespace Sprintra.Src;

public enum TimeUnit {
  Seconds,
  Minutes,
  Hours,
  Days,
  Weeks
}

public static class Helpers {
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
}
