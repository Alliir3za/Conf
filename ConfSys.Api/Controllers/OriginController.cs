using ConfSys.Service.Implement;
using ConfSys.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ConfSys.Api.Controllers;

[Route("[controller]/[action]")]
public class OriginController : Controller
{
    private readonly IOriginService _originService;
    public OriginController(IOriginService originService) => _originService = originService;


    [HttpGet]
    public async Task<ActionResult> GetAll()
        => Ok(await _originService.GetAllAsync());
}