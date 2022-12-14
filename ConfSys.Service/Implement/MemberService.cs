#nullable disable
using ConfSys.Data.UnitOfWork;
using ConfSys.Domain.Entity;

namespace ConfSys.Service.Implement;

public class MemberService : IMemberService
{
    private readonly IConfUnitOfWork _uow;
    public MemberService(IConfUnitOfWork uow) => _uow = uow;

    //public async Task<bool> CreateAsync(Members member)
    //{
    //    _uow.MemberRepo.Add(member);
    //    return (await _uow.SaveChangesAsync()).ToSaveChangeResult();
    //}

    //public async Task<bool> DeleteAsync(int userId)
    //{
    //    var result = await _uow.MemberRepo.FirstOrDefaultAsync(x => x.UserId == userId);
    //    if (result == null)
    //        return false;
    //    _uow.MemberRepo.Remove(result);

    //    return (await _uow.SaveChangesAsync()).ToSaveChangeResult();
    //}

    public async Task<List<Members>> GetAll(int userId)
    => await _uow.MemberRepo.Where(x => x.UserId == userId).ToListAsync();

    public async Task<List<MemberList>> GetList()
    {
        var result = await _uow.MemberRepo.Include(x => x.User).ThenInclude(k => k.Origin).Include(c => c.Project).Select(m => new MemberList
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
    => await _uow.MemberRepo.Include(x => x.Project)
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
