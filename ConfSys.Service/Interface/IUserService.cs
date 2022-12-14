using ConfSys.Domain.Dtos.User;
using ConfSys.Domain.Entity;

namespace ConfSys.Service.Interface;

public interface IUserService
{
    //Task<bool> CreateAsync(User model);
    Task<object> LoginAsync(string email, string password);
    //Task<bool> DeleteAsync(int userId);
    Task<List<UserList>> GetAll();
    //Task<bool> Update(UserUpdateDto model);
    Task<List<User>> GetList();
}