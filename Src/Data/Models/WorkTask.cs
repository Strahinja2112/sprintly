namespace Sprintra.Src.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class WorkTask {
  public int Id { get; set; }

  public int UserStoryId { get; set; }

  public int SprintId { get; set; }

  [Required]
  [MaxLength(150)]
  public string Name { get; set; } = null!;

  [Required]
  [MaxLength(600)]
  public string Description { get; set; } = null!;

  [Required]
  [MaxLength(30)]
  public string Status { get; set; } = null!;

  [Column(TypeName = "decimal(6,2)")]
  public decimal EstimatedHours { get; set; }

  [ForeignKey("UserStoryId")]
  public virtual UserStory UserStory { get; set; } = null!;

  [ForeignKey("SprintId")]
  public virtual Sprint Sprint { get; set; } = null!;

  public virtual ICollection<WorkTaskEntry> WorkLogEntries { get; set; } = new List<WorkTaskEntry>();
}