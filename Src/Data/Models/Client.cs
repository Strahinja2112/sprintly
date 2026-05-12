namespace Sprintra.Src.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Client {
  public int Id { get; set; }

  [Required]
  [MaxLength(50)]
  public string FirstName { get; set; } = null!;

  [Required]
  [MaxLength(50)]
  public string LastName { get; set; } = null!;

  [Required]
  [MaxLength(100)]
  public string Email { get; set; } = null!;

  [Required]
  [MaxLength(30)]
  public string Phone { get; set; } = null!;

  public virtual ICollection<UserStory> UserStories { get; set; } = new List<UserStory>();
}