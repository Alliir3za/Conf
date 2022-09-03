#nullable disable
using ConfSys.Data;
using ConfSys.Domain.Entity;
using ConfSys.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace ConfSys.Service.Implement;

public class UserService : IUserService
{
    private readonly ConfSysDbContext db;
    public UserService()
    {
        db = new ConfSysDbContext();
    }

    public async Task<List<User>> CreatUser(string name, string family)
    {
        var result = await db.Users.Where(g => g.Name == name && g.Family == family).Select(x => new User
        {
            Name = x.Name,
            Family = x.Family
        }).ToListAsync();

        return result;
    }

    public async Task<bool> IUserService.LogIn(string Email, string Password)
    {
        var result_1 = await db.Users.FirstOrDefaultAsync(x => x.Password == Password && x.Email == Email);
        return true;

        if (result_1 == null)
            return false;

    }

}
