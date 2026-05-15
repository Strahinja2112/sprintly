using Microsoft.EntityFrameworkCore;
using Sprintra.Src.Data;
using Sprintra.Src.Data.Models;

namespace Sprintra.Src.Services;

public class SprintsService {
  private readonly AppDbContext db;

  public SprintsService() {
    db = new AppDbContext();
  }

  internal async Task<List<Sprint>> GetSprintsForProject(int projectId) {
    return await db.Sprints
        .Where(s => s.ProjectId == projectId)
        .OrderBy(s => s.Name)
        .ToListAsync();
  }

  public async Task<List<Sprint>> GetSprintsByProjectAsync(int projectId, string searchTerm = "") {
    var query = db.Sprints.Where(s => s.ProjectId == projectId);

    if (!string.IsNullOrWhiteSpace(searchTerm)) {
      query = query.Where(s => s.Name.Contains(searchTerm));
    }

    return await query.OrderByDescending(s => s.StartDate).ToListAsync();
  }

  public async Task SaveSprintAsync(Sprint sprint) {
    if (string.IsNullOrWhiteSpace(sprint.Name))
      throw new ArgumentException("Ime sprinta je obavezno.");

    ValidateSprintRules(sprint);

    if (sprint.Id == 0) db.Sprints.Add(sprint);
    else db.Entry(sprint).State = EntityState.Modified;

    await db.SaveChangesAsync();
  }

  public void ValidateSprintRules(Sprint sprint) {
    if (sprint.Status == SprintStatus.Active && sprint.StartDate.Date > DateTime.Now.Date) {
      throw new InvalidOperationException("Sprint ne može biti aktivan pre datuma početka.");
    }

    if (sprint.Status == SprintStatus.Completed && sprint.StartDate.Date > DateTime.Now.Date) {
      throw new InvalidOperationException("Ne možete završiti sprint koji još nije ni počeo.");
    }
  }

  public async Task<Sprint?> GetByIdAsync(int id) {
    return await db.Sprints.FirstOrDefaultAsync(s => s.Id == id);
  }

  public async Task<bool> HasUnfinishedTasksAsync(int sprintId) {
    return await db.WorkTasks.AnyAsync(t => t.SprintId == sprintId && t.Status != WorkTaskStatus.Done);
  }

  public async Task MoveUnfinishedTasksToBacklogAsync(int sprintId) {
    var unfinishedTasks = await db.WorkTasks
        .Where(t => t.SprintId == sprintId && t.Status != WorkTaskStatus.Done)
        .ToListAsync();

    foreach (var task in unfinishedTasks) {
      task.Status = WorkTaskStatus.Cancelled;
    }

    await db.SaveChangesAsync();
  }

  public async Task DeleteSprintAsync(int sprintId) {
    var sprint = await db.Sprints
        .Include(s => s.WorkTasks)
        .FirstOrDefaultAsync(s => s.Id == sprintId);

    if (sprint == null) return;

    foreach (var task in sprint.WorkTasks) {
      task.SprintId = null;
    }

    if (sprint.WorkTasks.Count != 0)
      throw new InvalidOperationException("Ne možete obrisati sprint koji ima povezane zadatke. Prvo obrišite ili premestite zadatke.");

    if (sprint.Status != SprintStatus.Planned)
      throw new InvalidOperationException("Samo planirani sprintovi (Planned) se mogu obrisati.");

    db.Sprints.Remove(sprint);
    await db.SaveChangesAsync();
  }
}