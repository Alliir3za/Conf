#nullable disable
namespace ConfSys.Service.Implement;

public class FamilyMemberService : IFamilyMemberService
{
    private readonly ConfSysDbContext db;
    public FamilyMemberService() => db = new ConfSysDbContext();

    public async Task<bool> CreateAsync(FamilyMember model)
    {
        await db.FamilyMembers.AddAsync(model);
        return (await db.SaveChangesAsync()).ToSaveChangeResult();
    }

    public async Task<bool> DeleteAsync(int userId)
    {
        var result = await db.FamilyMembers.FirstOrDefaultAsync(x => x.UserId == userId);
        if (result is null) // pattern matching
            return false;
        db.FamilyMembers.Remove(result);
        return (await db.SaveChangesAsync()).ToSaveChangeResult();
    }

    public async Task<object> GetAllAsync(int userId)
       => await db.FamilyMembers.Where(x => x.UserId == userId)
        .Select(X => new
        {
            X.Name,
            X.Family,
            X.Gender
        })
        .ToListAsync();
}
