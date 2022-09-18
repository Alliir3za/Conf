using ConfSys.Service.Implement;
using Microsoft.AspNetCore.Mvc;

namespace ConfSys.Api.Controllers;

[Route("[controller]/[action]")]
public class OriginController : Controller
{
    private readonly OriginService _originService;
    public OriginController()
    {
        _originService = new OriginService();
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
        => Ok(await _originService.GetAllAsync());
}