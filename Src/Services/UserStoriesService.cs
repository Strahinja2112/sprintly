using Microsoft.EntityFrameworkCore;
using Sprintra.Src.Data;
using Sprintra.Src.Data.Models;

namespace Sprintra.Src.Services;

public class UserStoriesService {
  private readonly AppDbContext db;

  public UserStoriesService() {
    db = new AppDbContext();
  }

  public async Task<List<UserStory>> GetByProjectAsync(int projectId, string searchTerm = "", int? sprintId = null) {
    if (sprintId == null) {
      return [];
    }

    using var context = new AppDbContext();

    var query = context.UserStories
        .Include(us => us.Sprint)
        .Where(us => us.ProjectId == projectId);

    if (sprintId.HasValue && sprintId.Value > 0) {
      query = query.Where(us => us.SprintId == sprintId.Value);
    }

    if (!string.IsNullOrWhiteSpace(searchTerm)) {
      query = query.Where(us => us.Title.Contains(searchTerm));
    }

    return await query.OrderBy(us => us.Priority).ToListAsync();
  }

  public async Task SaveUserStoryAsync(UserStory userStory) {
    if (string.IsNullOrWhiteSpace(userStory.Title))
      throw new ArgumentException("Naslov korisničke priče je obavezan.");

    if (userStory.Id == 0) db.UserStories.Add(userStory);
    else db.Entry(userStory).State = EntityState.Modified;

    await db.SaveChangesAsync();
  }

  public async Task<UserStory?> GetByIdAsync(int id) {
    return await db.UserStories
        .Include(us => us.Sprint)
        .FirstOrDefaultAsync(us => us.Id == id);
  }
}