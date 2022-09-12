using ConfSys.Domain.Dtos;
using ConfSys.Domain.Entity;
using ConfSys.Service.Implement;
using Microsoft.AspNetCore.Mvc;

namespace ConfSys.Api.Controllers;

[Route("[controller]/[action]")]
public class MemberController : Controller
{
    private readonly MemberService _memberService;
    public MemberController() => _memberService = new MemberService();

    [HttpGet]
    public async Task<ActionResult> Create(Members member)
        => Ok(await _memberService.CreateAsync(member));

    [HttpGet]
    public async Task<ActionResult> GetAll(int userId)
        => Ok(await _memberService.GetAll(userId));

    [HttpGet]
    public async Task<ActionResult> GetList()
        => Ok(await _memberService.GetList());

    [HttpPost]
    public async Task<ActionResult> Delete(int userId)
        => Ok(await _memberService.DeleteAsync(userId));

    [HttpGet]
    public async Task<ActionResult> GetAllProject()
        => Ok(await _memberService.GetAllProjects());

}
