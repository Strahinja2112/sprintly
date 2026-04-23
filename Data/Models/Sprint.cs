namespace Sprintra.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Sprint {
  public int Id { get; set; }

  public int ProjectId { get; set; }

  public int ScrumMasterId { get; set; }

  public DateTime StartDate { get; set; }

  public DateTime? EndDate { get; set; }

  public int EstimatedWorkHours { get; set; }

  [Required]
  [MaxLength(30)]
  public string Status { get; set; } = null!;

  [ForeignKey("ProjectId")]
  public virtual Project Project { get; set; } = null!;

  [ForeignKey("ScrumMasterId")]
  public virtual Employee ScrumMaster { get; set; } = null!;

  public virtual ICollection<WorkTask> WorkTasks { get; set; } = [];

  public virtual ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();
}