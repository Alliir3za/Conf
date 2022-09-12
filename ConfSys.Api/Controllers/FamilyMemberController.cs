using ConfSys.Domain.Entity;
using ConfSys.Service.Implement;
using Microsoft.AspNetCore.Mvc;

namespace ConfSys.Api.Controllers;

[Route("[controller]/[action]")]
public class FamilyMemberController : Controller
{
    private readonly FamilyMemberService _familyMember;

    public FamilyMemberController()
    {
        _familyMember = new FamilyMemberService();
    }
    public async Task<ActionResult> Create(FamilyMember familyMember)
        => Ok(await _familyMember.CreateAsync(familyMember));

    public async Task<ActionResult> Delete(int userId)
        => Ok(await _familyMember.DeleteAsync(userId));

    public async Task<ActionResult> GetAll(int userId)
        => Ok(await _familyMember.GetAllAsync(userId));
}
