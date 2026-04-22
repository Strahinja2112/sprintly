namespace Sprintra.Models;

using System.ComponentModel.DataAnnotations;

public class Employee {
  public int Id { get; set; }

  [Required]
  [MaxLength(50)]
  public string FirstName { get; set; } = null!;

  [Required]
  [MaxLength(50)]
  public string LastName { get; set; } = null!;

  [Required]
  [MaxLength(120)]
  public string Email { get; set; } = null!;

  [MaxLength(30)]
  public string? Phone { get; set; }

  public DateTime HireDate { get; set; }

  [Required]
  [MaxLength(20)]
  public string Status { get; set; } = null!;

  [Required]
  [MaxLength(50)]
  public string Username { get; set; } = null!;

  [Required]
  public string PasswordHash { get; set; } = null!;

  public string? TeamRole { get; set; }
  public string? SeniorityLevel { get; set; }
  public string? Field { get; set; }

  [Required]
  public EmployeeType Type { get; set; }

  public virtual ICollection<Project> Projects { get; set; } = [];
  public virtual ICollection<Meeting> Meetings { get; set; } = [];
}

public enum EmployeeType {
  ScrumMaster,
  ProductOwner,
  Developer,
  Admin
}