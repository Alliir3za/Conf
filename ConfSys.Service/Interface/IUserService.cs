using ConfSys.Domain.Dtos;

namespace ConfSys.Service.Interface;

public interface IUserService
{
    Task<bool> CreateAsync(User model);
    Task<User> LoginAsync(string email, string password);
    Task<bool> DeleteAsync(int userId);
   
}
