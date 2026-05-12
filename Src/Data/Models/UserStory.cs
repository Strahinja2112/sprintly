namespace Sprintra.Src.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserStory {
  public int Id { get; set; }

  public int? ClientId { get; set; }

  [Required]
  public int ProjectId { get; set; }

  public int? SprintId { get; set; }

  [Required]
  [MaxLength(100)]
  public string Title { get; set; } = null!;

  [Required]
  [MaxLength(500)]
  public string Description { get; set; } = null!;

  public int Priority { get; set; }

  [Required]
  public UserStoryStatus Status { get; set; }

  [ForeignKey("ClientId")]
  public virtual Client? Client { get; set; }

  [ForeignKey("ProjectId")]
  public virtual Project Project { get; set; } = null!;

  [ForeignKey("SprintId")]
  public virtual Sprint? Sprint { get; set; }

  public virtual ICollection<WorkTask> WorkTasks { get; set; } = [];
}

public enum UserStoryStatus {
  Backlog,
  Todo,
  InProgress,
  InReview,
  Done
}