using ConfSys.Domain.Entity;

namespace ConfSys.Service.Interface;

public interface IMemberService
{
    //Task<bool> CreateAsync(Members member);
    //Task<bool> DeleteAsync(int userId);
    Task<List<Members>> GetAll(int userId);
    Task<List<MemberList>> GetList();
    Task<List<MemberList>> GetAllProjects();
}
