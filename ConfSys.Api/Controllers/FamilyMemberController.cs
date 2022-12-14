using ConfSys.Domain.Entity;
using ConfSys.Service.Implement;
using ConfSys.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ConfSys.Api.Controllers;

[Route("[controller]/[action]")]
public class FamilyMemberController : Controller
{
    private readonly IFamilyMemberService _familyMember;

    public FamilyMemberController(IFamilyMemberService familyMember) => _familyMember = familyMember;

    //public async Task<ActionResult> Create(FamilyMember familyMember)
    //    => Ok(await _familyMember.CreateAsync(familyMember));

    //public async Task<ActionResult> Delete(int userId)
    //    => Ok(await _familyMember.DeleteAsync(userId));

    public async Task<ActionResult> GetAll(int userId)
        => Ok(await _familyMember.GetAllAsync(userId));
}