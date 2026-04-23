namespace Sprintra.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserStory {
  public int Id { get; set; }

  public int? ClientId { get; set; }

  [Required]
  [MaxLength(50)]
  public string Title { get; set; } = null!;

  [Required]
  [MaxLength(50)]
  public string Description { get; set; } = null!;

  public int Priority { get; set; }

  [Required]
  [MaxLength(50)]
  public string Status { get; set; } = null!;

  [ForeignKey("ClientId")]
  public virtual Client? Client { get; set; }

  public virtual ICollection<WorkTask> WorkTasks { get; set; } = [];
}