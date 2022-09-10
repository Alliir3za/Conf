#nullable disable
using ConfSys.Data;
using ConfSys.Domain.Dtos;
using ConfSys.Domain.Entity;
using ConfSys.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace ConfSys.Service.Implement;

public class UserService : IUserService
{
    private readonly ConfSysDbContext db;
    public UserService() => db = new ConfSysDbContext();

    public async Task<bool> CreateAsync(User model)
    {
        Random rnd = new();
        model.Password = rnd.Next(10000, 1000000).ToString();

        await db.Users.AddAsync(model);
        return (await db.SaveChangesAsync()).ToSaveChangeResult();
    }

    public async Task<bool> DeleteAsync(int userId)
    {
        var result = await db.Users.FirstOrDefaultAsync(x => x.UserId == userId);
        if (result == null)
            return false;
        db.Users.Remove(result);

        return (await db.SaveChangesAsync()).ToSaveChangeResult();
    }

    public async Task<User> LoginAsync(string email, string password)
           => await db.Users.FirstOrDefaultAsync(X => X.Email == email && X.Password == password);
}