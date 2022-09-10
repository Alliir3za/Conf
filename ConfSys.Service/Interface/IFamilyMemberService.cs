namespace ConfSys.Service.Interface;

public interface IFamilyMemberService
{
    Task<bool> CreateAsync(FamilyMember model);
    Task<bool> DeleteAsync(int userId);
    Task<List<FamilyMember>> GetAllAsync(int userId);  
}
