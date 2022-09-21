#nullable disable
using ConfSys.Domain.Entity;

namespace ConfSys.Service.Implement;

public class ProjectService : IProjectService
{
    private readonly ConfSysDbContext _db;
    public ProjectService(ConfSysDbContext db) => _db = db;

    public async Task<bool> CreateAsync(Project model)
    {
        await _db.Projects.AddAsync(model);
        return (await _db.SaveChangesAsync()).ToSaveChangeResult();
    }

    public async Task<bool> DeleteAsync(int userId, int projectId)
    {
        var result = await _db.Projects.FirstOrDefaultAsync(X => X.UserId == userId && X.ProjectId == projectId);

        if (result is null)
            return false;

        _db.Projects.Remove(result);
        return (await _db.SaveChangesAsync()).ToSaveChangeResult();
    }

    public async Task<List<Project>> GetAllAsync(int userId)
               => await _db.Projects.Where(X => X.UserId == userId).ToListAsync();
}
