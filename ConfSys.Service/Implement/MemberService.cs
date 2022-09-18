#nullable disable
namespace ConfSys.Service.Implement;

public class MemberService : IMemberService
{
    private readonly ConfSysDbContext db;

    public MemberService() => db = new ConfSysDbContext();

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

    public async Task<List<MemberList>> GetList()
    {
        var result = await db.Members.Include(x => x.User).ThenInclude(k => k.Origin).Include(c => c.Project).Select(m => new MemberList
        {
            Name = m.User.Name,
            ProjectName = m.Project.Name,
            Origin = m.User.Origin.Name,
            Position = m.Position,
            Family = m.User.Family

        }).ToListAsync();
        return result;
    }

    public async Task<List<MemberList>> GetAllProjects()
    => await db.Members.Include(x => x.Project)
                       .Include(x => x.User)
                       .ThenInclude(x => x.Origin)
                       .Select(m => new MemberList
                       {
                           Name = m.User.Name,
                           Family = m.User.Family,
                           ProjectName = m.Project.Name,
                           Origin = m.User.Origin.Name,
                           Position = m.Position
                       }).ToListAsync();
}
