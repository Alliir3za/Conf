using ConfSys.Domain.Entity;

namespace ConfSys.Service.Interface;

public interface IUserService
{
    public Task<bool> LogIn(string Email, string Password);
    public Task<List<User>> CreatUser(string name,string family);

}
