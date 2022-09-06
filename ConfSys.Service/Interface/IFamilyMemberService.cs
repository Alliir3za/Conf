namespace ConfSys.Service.Interface;

public interface IFamilyMemberService
{
    Task<bool> CreateFamilyAsync(FamilyMember model);
    Task<bool> DeleteFamilyAsync(int userId);
    Task<List<FamilyMember>> GetAllFamilyMembersAsync(int userId);
}
