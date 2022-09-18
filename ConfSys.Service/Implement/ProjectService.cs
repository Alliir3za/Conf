#nullable disable
namespace ConfSys.Service.Implement;

public class ProjectService : IProjectService
{
    private readonly ConfSysDbContext db;
    public ProjectService() => db = new ConfSysDbContext();

    public async Task<bool> CreateAsync(Project model)
    {
        await db.Projects.AddAsync(model);
        return (await db.SaveChangesAsync()).ToSaveChangeResult();
    }

    public async Task<bool> DeleteAsync(int userId, int projectId)
    {
        var result = await db.Projects.FirstOrDefaultAsync(X => X.UserId == userId && X.ProjectId == projectId);

        if (result is null)
            return false;

        db.Projects.Remove(result);
        return (await db.SaveChangesAsync()).ToSaveChangeResult();
    }

    public async Task<List<Project>> GetAllAsync(int userId)
               => await db.Projects.Where(X => X.UserId == userId).ToListAsync();
}
