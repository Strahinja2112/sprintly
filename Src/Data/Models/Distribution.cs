namespace Sprintra.Src.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Distribution {
  public int Id { get; set; }

  [Required]
  [MaxLength(30)]
  public string Version { get; set; } = null!;

  [Required]
  public DistributionEnvironment Environment { get; set; }

  public virtual ICollection<Sprint> Sprints { get; set; } = [];
}

public enum DistributionEnvironment {
  Web,
  Mobile,
  Desktop,
  Api
}