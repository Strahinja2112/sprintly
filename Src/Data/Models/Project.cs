namespace Sprintly.Src.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Project {
  public int Id { get; set; }

  [Required]
  [MaxLength(100)]
  public string Name { get; set; } = null!;

  [Required]
  [MaxLength(300)]
  public string Description { get; set; } = null!;

  [Required]
  public ProjectStatus Status { get; set; }

  public DateTime StartDate { get; set; }

  public DateTime? EndDate { get; set; }

  public virtual ICollection<Sprint> Sprints { get; set; } = new List<Sprint>();

  public virtual ICollection<Employee> Members { get; set; } = new List<Employee>();
}

public enum ProjectStatus {
  Active,
  Completed,
  OnHold,
  Planned
}