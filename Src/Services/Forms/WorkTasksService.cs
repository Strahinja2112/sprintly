using Microsoft.EntityFrameworkCore;
using Sprintly.Src.Data;
using Sprintly.Src.Data.Models;

namespace Sprintly.Src.Services.Forms;

public class WorkTasksService {

  public async Task<List<WorkTask>> GetTasksAsync(int projectId, int? sprintId = null, string searchTerm = "", int? employeeId = null) {
    using var db = new AppDbContext();

    var query = db.WorkTasks
        .Include(t => t.UserStory)
        .Include(t => t.Sprint)
        .Include(t => t.WorkLogEntries)
        .Where(t => t.UserStory.ProjectId == projectId);

    if (sprintId.HasValue && sprintId.Value > 0) {
      query = query.Where(t => t.SprintId == sprintId.Value);
    }

    if (!string.IsNullOrWhiteSpace(searchTerm)) {
      query = query.Where(t => t.Name.Contains(searchTerm) || t.Description.Contains(searchTerm));
    }

    if (employeeId.HasValue) {
      query = query.Where(t => t.AssignedEmployees.Any(e => e.Id == employeeId.Value));
    }

    return await query.OrderByDescending(t => t.Id).ToListAsync();
  }

  public async Task<WorkTask?> GetByIdAsync(int id) {
    using var db = new AppDbContext();
    return await db.WorkTasks
        .Include(t => t.UserStory)
        .Include(t => t.Sprint)
        .FirstOrDefaultAsync(t => t.Id == id);
  }

  public async Task SaveTaskAsync(WorkTask task) {
    using var db = new AppDbContext();

    if (task.Id == 0) {
      db.WorkTasks.Add(task);
    }
    else {
      db.WorkTasks.Attach(task);
      db.Entry(task).State = EntityState.Modified;
    }

    await db.SaveChangesAsync();
  }

  public async Task<bool> DeleteTaskAsync(int id) {
    using var db = new AppDbContext();
    var task = await db.WorkTasks.FindAsync(id);

    if (task == null) return false;

    db.WorkTasks.Remove(task);
    await db.SaveChangesAsync();
    return true;
  }

  public async Task<decimal> GetTotalLoggedHoursAsync(int taskId) {
    using var db = new AppDbContext();
    return await db.WorkTaskEntries
        .Where(we => we.WorkTaskId == taskId)
        .SumAsync(we => we.HoursWorked);
  }
}