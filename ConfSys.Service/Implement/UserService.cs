#nullable disable
using ConfSys.Data.UnitOfWork;
using ConfSys.Domain.Dtos.User;
using ConfSys.Domain.Entity;

namespace ConfSys.Service.Implement;

public class UserService : IUserService
{
    private readonly IConfUnitOfWork _uow;

    public UserService(IConfUnitOfWork uow) => _uow = uow;

    //public async Task<bool> CreateAsync(User model)
    //{
    //    Random rnd = new();
    //    model.Password = rnd.Next(10000, 1000000).ToString();

    //    await _uow.UserRepo.AddAsync(model);
    //    var dbResult = await _uow.SaveChangesAsync();

    //}

    //public async Task<bool> DeleteAsync(int userId)
    //{
    //    var result = await _uow.UserRepo.FirstOrDefaultAsync(x => x.UserId == userId);
    //    if (result == null)
    //        return false;
    //    _uow.UserRepo.Remove(result);
    //    return (await _uow.UserRepo.SaveChangesAsync()).ToSaveChangeResult();
    
    //addd
    public async Task<List<UserList>> GetAll()
    {
        var result = await _uow.UserRepo.Include(x => x.Origin).Include(c => c.FamilyMembers).Select(u => new UserList
        {
            Name = u.Name,
            Family = u.Family,
            Origin = u.Origin.Name,

        }).ToListAsync();
        return result;
    }

    public async Task<List<User>> GetList()
        => await _uow.UserRepo.OrderByDescending(x => x.Family).Take(5).ToListAsync();

    public async Task<object> LoginAsync(string email, string password)
           => await _uow.UserRepo.Where(X => X.Email == email && X.Password == password).Select(u => new
           {
               u.Name,
               u.Family,
               u.Email,
               u.Password
           })
              .ToListAsync();

    //public async Task<bool> Update(UserUpdateDto model)
    //{
    //    var user = await _uow.UserRepo.FirstOrDefaultAsync(X => X.UserId == model.UserId);
    //    if (user is null)
    //        return false;

    //    user.Name = model.Name;
    //    user.Family = model.Family;
    //    user.Gender = model.Gender;

    //    var result = await _uow.SaveChangesAsync();
    //}
}
