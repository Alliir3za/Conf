using ConfSys.Data;
using ConfSys.Domain.Entity;
using ConfSys.Service.Interface;

namespace ConfSys.Service.Implement;

public class UserService : IUserService
{
    private readonly ConfSysDbContext db;
    public UserService()
    {
        db = new ConfSysDbContext();
    }

    public List<User> GetMale()
    {
        throw new NotImplementedException();
    }

    public List<User> GetName()
    {
        throw new NotImplementedException();
    }
}
