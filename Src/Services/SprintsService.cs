using Microsoft.EntityFrameworkCore;
using Sprintra.Src.Data;
using Sprintra.Src.Data.Models;

namespace Sprintra.Src.Services;

public class SprintService {
  private readonly AppDbContext db;

  public SprintService() {
    db = new AppDbContext();
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
}