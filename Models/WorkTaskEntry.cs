namespace Sprintra.Models;

using System.ComponentModel.DataAnnotations.Schema;

public class WorkTaskEntry {
  public int EmployeeId { get; set; }

  public int WorkTaskId { get; set; }

  public DateTime WorkDate { get; set; }

  [Column(TypeName = "decimal(6,2)")]
  public decimal HoursWorked { get; set; }

  [ForeignKey("EmployeeId")]
  public virtual Employee Employee { get; set; } = null!;

  [ForeignKey("WorkTaskId")]
  public virtual WorkTask WorkTask { get; set; } = null!;
}