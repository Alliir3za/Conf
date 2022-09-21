#nullable disable
using ConfSys.Domain.Entity;

namespace ConfSys.Service.Implement;

public class MemberService : IMemberService
{
    private readonly ConfSysDbContext _db;

    public MemberService(ConfSysDbContext db) => _db = db;

    public async Task<bool> CreateAsync(Members member)
    {
        _db.Members.Add(member);
        return (await _db.SaveChangesAsync()).ToSaveChangeResult();
    }

    public async Task<bool> DeleteAsync(int userId)
    {
        var result = await _db.Members.FirstOrDefaultAsync(x => x.UserId == userId);
        if (result == null)
            return false;
        _db.Members.Remove(result);

        return (await _db.SaveChangesAsync()).ToSaveChangeResult();
    }

    public async Task<List<Members>> GetAll(int userId)
    => await _db.Members.Where(x => x.UserId == userId).ToListAsync();

    public async Task<List<MemberList>> GetList()
    {
        var result = await _db.Members.Include(x => x.User).ThenInclude(k => k.Origin).Include(c => c.Project).Select(m => new MemberList
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
    => await _db.Members.Include(x => x.Project)
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
