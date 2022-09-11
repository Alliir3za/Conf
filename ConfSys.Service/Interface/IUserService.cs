using ConfSys.Domain.Dtos.User;

namespace ConfSys.Service.Interface;

public interface IUserService
{
    Task<bool> CreateAsync(User model);
    Task<User> LoginAsync(string email, string password);
    Task<bool> DeleteAsync(int userId);
    Task<List<UserList>> GetAll();
    Task<bool> Update(UserUpdateDto model);
}
