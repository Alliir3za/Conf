#nullable disable
using ConfSys.Domain.Entity;

namespace ConfSys.Service.Implement;

public class FamilyMemberService : IFamilyMemberService
{
    private readonly ConfSysDbContext _db;

    public FamilyMemberService(ConfSysDbContext db) => _db = db;


    public async Task<bool> CreateAsync(FamilyMember model)
    {
        await _db.FamilyMembers.AddAsync(model);
        return (await _db.SaveChangesAsync()).ToSaveChangeResult();
    }

    public async Task<bool> DeleteAsync(int userId)
    {
        var result = await _db.FamilyMembers.FirstOrDefaultAsync(x => x.UserId == userId);
        if (result is null) // pattern matching
            return false;
        _db.FamilyMembers.Remove(result);
        return (await _db.SaveChangesAsync()).ToSaveChangeResult();
    }

    public async Task<object> GetAllAsync(int userId)
       => await _db.FamilyMembers.Where(x => x.UserId == userId)
        .Select(X => new
        {
            X.Name,
            X.Family,
            X.Gender
        })
        .ToListAsync();
}
