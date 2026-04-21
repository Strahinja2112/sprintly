namespace Sprintra.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Meeting {
  public int Id { get; set; }

  public int SprintId { get; set; }

  public DateTime DateTime { get; set; }

  public int DurationMinutes { get; set; }

  [MaxLength(300)]
  public string? Description { get; set; }

  [Required]
  public MeetingType Type { get; set; }

  // Polja specifična za podtipove
  [MaxLength(300)]
  public string? SprintGoal { get; set; }

  [MaxLength(300)]
  public string? Feedback { get; set; }

  [ForeignKey("SprintId")]
  public virtual Sprint Sprint { get; set; } = null!;
}

public enum MeetingType {
  Standard,
  SprintPlanning,
  DailyStandup,
  SprintReview
}