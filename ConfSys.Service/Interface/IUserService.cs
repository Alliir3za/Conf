using ConfSys.Domain.Entity;

namespace ConfSys.Service.Interface;

public interface IUserService
{
    public List<User> GetName();
    public List<User> GetMale();
}
