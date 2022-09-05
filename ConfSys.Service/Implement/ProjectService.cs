#nullable disable
using ConfSys.Data;
using ConfSys.Domain.Entity;
using ConfSys.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace ConfSys.Service.Implement;

public class ProjectService : IProjectService
{
    private readonly ConfSysDbContext db;
    public ProjectService()
    {
        db = new ConfSysDbContext();
    }

    public async Task<bool> CreateProjectAsync(Project model)
    {
        db.Projects.Add(model);
        var result = await db.SaveChangesAsync();
        if (result >= 1)
            return true;
        return false;
    }

    public async Task<bool> DeleteAsync(int userId, int projectId)
    {
        var result = await db.Projects.FirstOrDefaultAsync(X => X.UserId == userId && X.ProjectId == projectId);

        if (result is null)
            return false;

        db.Projects.Remove(result);
        var db_result = await db.SaveChangesAsync();
        if (db_result >= 1)
            return true;

        return false;
    }

    public async Task<List<Project>> GetAllAsync(int userId)
    => await db.Projects.Where(X => X.UserId == userId).ToListAsync();

}
