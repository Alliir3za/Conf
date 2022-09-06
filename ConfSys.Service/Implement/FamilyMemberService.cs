#nullable disable
using ConfSys.Data;
using ConfSys.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace ConfSys.Service.Implement;

public class FamilyMemberService : IFamilyMemberService
{
    private readonly ConfSysDbContext db;

    public FamilyMemberService()
    {
        db = new ConfSysDbContext();
    }
    public async Task<bool> CreateFamilyAsync(FamilyMember model)
    {
        db.FamilyMembers.Add(model);
        return (await db.SaveChangesAsync()).ToSaveChangeResult();
    }

    public async Task<bool> DeleteFamilyAsync(int userId)
    {
        var result = await db.FamilyMembers.FirstOrDefaultAsync(x => x.UserId == userId);
        if (result == null)
            return false;
        db.FamilyMembers.Remove(result);

        return (await db.SaveChangesAsync()).ToSaveChangeResult();
    }

    public async Task<List<FamilyMember>> GetAllFamilyMembersAsync(int userId)
      => await db.FamilyMembers.Where(x => x.UserId == userId).ToListAsync();

}
