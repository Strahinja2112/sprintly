namespace Sprintly.Src.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Feature {
  public int Id { get; set; }

  public int SprintId { get; set; }

  public int IncrementId { get; set; }

  [Required]
  [MaxLength(150)]
  public string Name { get; set; } = null!;

  [Required]
  [MaxLength(600)]
  public string Description { get; set; } = null!;

  [ForeignKey("SprintId")]
  public virtual Sprint Sprint { get; set; } = null!;

  [ForeignKey("IncrementId")]
  public virtual Increment Increment { get; set; } = null!;
}