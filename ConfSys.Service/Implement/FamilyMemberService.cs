#nullable disable
using ConfSys.Data.UnitOfWork;
using ConfSys.Domain.Entity;

namespace ConfSys.Service.Implement;

public class FamilyMemberService : IFamilyMemberService
{
    private readonly IConfUnitOfWork _uow;
    public FamilyMemberService(IConfUnitOfWork uow) => _uow = uow;

    //public async Task<bool> CreateAsync(FamilyMember model)
    //{
    //    await _uow.FamilyMemberRepo.AddAsync(model);
    //    return (await _uow.SaveChangesAsync()).ToSaveChangeResult();
    //}

    //public async Task<bool> DeleteAsync(int userId)
    //{
    //    var result = await _uow.FamilyMemberRepo.FirstOrDefaultAsync(x => x.UserId == userId);
    //    if (result is null) // pattern matching
    //        return false;
    //    _uow.FamilyMemberRepo.Remove(result);
    //    return (await _uow.SaveChangesAsync()).ToSaveChangeResult();
    //}

    public async Task<object> GetAllAsync(int userId)
       => await _uow.FamilyMemberRepo.Where(x => x.UserId == userId)
        .Select(X => new
        {
            X.Name,
            X.Family,
            X.Gender
        })
        .ToListAsync();
}
