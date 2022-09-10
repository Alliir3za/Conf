#nullable disable
using ConfSys.Data;
using ConfSys.Domain.Dtos;
using ConfSys.Domain.Entity;
using ConfSys.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace ConfSys.Service.Implement;

public class ProjectService : IProjectService
{
    private readonly ConfSysDbContext db;
    public ProjectService() => db = new ConfSysDbContext();

    public async Task<bool> CreateProjectAsync(Project model)
    {
        db.Projects.Add(model);
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

    public async Task<List<ProjectList>> GetAllProjects()
    {
        var result = await db.Projects.Include(x => x.User).Include(s => s.Members).Select(p => new ProjectList
        {
            Name = p.User.Name,
            Family = p.User.Family,
            ProjectName = p.ProjectName,

        }).ToListAsync();
        return result;
    }
}
