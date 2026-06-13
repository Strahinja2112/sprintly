using Microsoft.EntityFrameworkCore;
using Sprintly.Src.Data;
using Sprintly.Src.Data.Models;

namespace Sprintly.Src.Services.Forms;

public class UserStoriesService {
  private readonly AppDbContext db;

  public UserStoriesService() {
    db = new AppDbContext();
  }

  public async Task<List<UserStory>> GetByProjectAsync(int projectId, string searchTerm = "", int? sprintId = null) {
    using var context = new AppDbContext();

    var query = context.UserStories
        .Where(us => us.ProjectId == projectId);

    if (!string.IsNullOrWhiteSpace(searchTerm)) {
      query = query.Where(us => us.Title.Contains(searchTerm));
    }

    return await query.OrderBy(us => us.Priority).ToListAsync();
  }

  public async Task SaveUserStoryAsync(UserStory userStory) {
    if (string.IsNullOrWhiteSpace(userStory.Title))
      throw new ArgumentException("Naslov korisničke priče je obavezan.");

    if (userStory.Id == 0)
      db.UserStories.Add(userStory);
    else
      db.Entry(userStory).State = EntityState.Modified;

    await db.SaveChangesAsync();
  }

  public async Task<UserStory?> GetByIdAsync(int id) {
    return await db.UserStories.FirstOrDefaultAsync(us => us.Id == id);
  }

  public async Task DeleteUserStoryAsync(int id) {
    var story = await db.UserStories
        .Include(us => us.WorkTasks)
        .FirstOrDefaultAsync(us => us.Id == id);

    if (story == null) return;

    if (story.WorkTasks.Count != 0) {
      throw new InvalidOperationException("Ne možete obrisati korisničku priču koja ima povezane zadatke. Prvo obrišite ili premestite zadatke.");
    }

    db.UserStories.Remove(story);
    await db.SaveChangesAsync();
  }
}
