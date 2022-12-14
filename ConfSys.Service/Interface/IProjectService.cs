using ConfSys.Domain.Entity;

namespace ConfSys.Service.Interface;

public interface IProjectService
{
    //Task<bool> DeleteAsync(int userId, int projectId);
    Task<List<Project>> GetAllAsync(int userId);
    //Task<bool> CreateAsync(Project model);
}