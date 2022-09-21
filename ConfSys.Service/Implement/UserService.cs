#nullable disable
using ConfSys.Domain.Dtos.User;
using ConfSys.Domain.Entity;

namespace ConfSys.Service.Implement;

public class UserService : IUserService
{
    private readonly ConfSysDbContext _db;
    public UserService(ConfSysDbContext db) => _db = db;

    public async Task<bool> CreateAsync(User model)
    {
        Random rnd = new();
        model.Password = rnd.Next(10000, 1000000).ToString();

        await _db.Users.AddAsync(model);
        return (await _db.SaveChangesAsync()).ToSaveChangeResult();
    }

    public async Task<bool> DeleteAsync(int userId)
    {
        var result = await _db.Users.FirstOrDefaultAsync(x => x.UserId == userId);
        if (result == null)
            return false;
        _db.Users.Remove(result);

        return (await _db.SaveChangesAsync()).ToSaveChangeResult();

    }

    public async Task<List<UserList>> GetAll()
    {
        var result = await _db.Users.Include(x => x.Origin).Include(c => c.FamilyMembers).Select(u => new UserList
        {
            Name = u.Name,
            Family = u.Family,
            Origin = u.Origin.Name,

        }).ToListAsync();
        return result;
    }

    public async Task<object> LoginAsync(string email, string password)
           => await _db.Users.Where(X => X.Email == email && X.Password == password).Select(u => new
           {
               u.Name,
               u.Family,
               u.Email,
               u.Password
           })
              .ToListAsync();

    public async Task<bool> Update(UserUpdateDto model)
    {
        var user = await _db.Users.FirstOrDefaultAsync(X => X.UserId == model.UserId);
        if (user is null)
            return false;

        user.Name = model.Name;
        user.Family = model.Family;
        user.Gender = model.Gender;
        return (await _db.SaveChangesAsync()).ToSaveChangeResult();
    }
}