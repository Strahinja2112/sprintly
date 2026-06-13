namespace Sprintly.Src.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Sprint {
  public int Id { get; set; }

  [Required]
  [MaxLength(100)]
  public string Name { get; set; } = null!;

  [MaxLength(500)]
  public string? Goal { get; set; }

  public int ProjectId { get; set; }

  public int? ScrumMasterId { get; set; }

  public DateTime StartDate { get; set; }

  public DateTime? EndDate { get; set; }

  public int EstimatedWorkHours { get; set; }

  [Required]
  public SprintStatus Status { get; set; }

  [ForeignKey("ProjectId")]
  public virtual Project Project { get; set; } = null!;

  [ForeignKey("ScrumMasterId")]
  public virtual Employee? ScrumMaster { get; set; }

  public virtual ICollection<WorkTask> WorkTasks { get; set; } = [];
}

public enum SprintStatus {
  Planned,
  Active,
  Completed,
  Canceled
}
