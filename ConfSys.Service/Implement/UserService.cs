#nullable disable
using ConfSys.Domain.Dtos.User;

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

    public async Task<List<UserList>> GetAll()
    {
        var result = await db.Users.Include(x => x.Origin).Include(c => c.FamilyMembers).Select(u => new UserList
        {
            Name = u.Name,
            Family = u.Family,
            Origin = u.Origin.Name,

        }).ToListAsync();
        return result;
    }

    public async Task<User> LoginAsync(string email, string password)
           => await db.Users.FirstOrDefaultAsync(X => X.Email == email && X.Password == password);

    public async Task<bool> Update(UserUpdateDto model)
    {
        var user = await db.Users.FirstOrDefaultAsync(X => X.UserId == model.UserId);
        if (user is null)
            return false;

        user.Name = model.Name;
        user.Family = model.Family;
        user.Gender = model.Gender;
        return (await db.SaveChangesAsync()).ToSaveChangeResult();
    }
}