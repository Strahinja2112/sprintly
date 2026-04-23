namespace Sprintra.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Increment {
  public int Id { get; set; }

  public int DistributionId { get; set; }

  public DateTime CreatedAt { get; set; }

  [Required]
  [MaxLength(30)]
  public string Status { get; set; } = null!;

  [ForeignKey("DistributionId")]
  public virtual Distribution Distribution { get; set; } = null!;
}