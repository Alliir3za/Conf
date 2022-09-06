#nullable disable
using ConfSys.Data;
using ConfSys.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace ConfSys.Service.Implement;

public class MemberService : IMemberService
{
    private readonly ConfSysDbContext db;

    public MemberService()
    {
        db = new ConfSysDbContext();
    }

    public async Task<bool> CreateAsync(Members member)
    {
        db.Members.Add(member);
        return (await db.SaveChangesAsync()).ToSaveChangeResult();
    }

    public async Task<bool> DeleteAsync(int userId)
    {
        var result = await db.Members.FirstOrDefaultAsync(x => x.UserId == userId);
        if (result == null)
            return false;
        db.Members.Remove(result);

        return (await db.SaveChangesAsync()).ToSaveChangeResult();
    }

    public async Task<List<Members>> GetAll(int userId)
    => await db.Members.Where(x => x.UserId == userId).ToListAsync();

}
