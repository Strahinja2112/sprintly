namespace Sprintra.Src.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserStory {
  public int Id { get; set; }

  [Required]
  public int ProjectId { get; set; }

  [Required]
  [MaxLength(100)]
  public string Title { get; set; } = null!;

  [Required]
  [MaxLength(500)]
  public string Description { get; set; } = null!;

  public int Priority { get; set; }

  [ForeignKey("ProjectId")]
  public virtual Project Project { get; set; } = null!;

  public virtual ICollection<WorkTask> WorkTasks { get; set; } = [];
}