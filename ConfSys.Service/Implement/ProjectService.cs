#nullable disable
using ConfSys.Data.UnitOfWork;
using ConfSys.Domain.Entity;

namespace ConfSys.Service.Implement;

public class ProjectService : IProjectService
{
    private readonly IConfUnitOfWork _uow;
    public ProjectService(IConfUnitOfWork uow) => _uow = uow;

    //public async Task<bool> CreateAsync(Project model)
    //{
    //    await _uow.ProjectRepo.AddAsync(model);
    //    return (await _uow.SaveChangesAsync()).ToSaveChangeResult();
    //}

    //public async Task<bool> DeleteAsync(int userId, int projectId)
    //{
    //    var result = await _uow.ProjectRepo.FirstOrDefaultAsync(X => X.UserId == userId && X.ProjectId == projectId);

    //    if (result is null)
    //        return false;

    //    _uow.ProjectRepo.Remove(result);
    //    return (await _uow.SaveChangesAsync()).ToSaveChangeResult();
    //}

    public async Task<List<Project>> GetAllAsync(int userId)
               => await _uow.ProjectRepo.Where(X => X.UserId == userId).ToListAsync();
}
