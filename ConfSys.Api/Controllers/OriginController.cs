using ConfSys.Data.UnitOfWork;
using ConfSys.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ConfSys.Api.Controllers;

[Route("[controller]/[action]")]
public class OriginController : Controller
{
    private readonly IOriginService _originService;
    private readonly IConfUnitOfWork _confUnitOfWork; 
    public OriginController(IConfUnitOfWork confUnitOfWork ,IOriginService originService)
    {
        _confUnitOfWork = confUnitOfWork;
        _originService = originService;
    }
       
    [HttpGet]
    public async Task<ActionResult> GetAll()
        => Ok(_confUnitOfWork.ProjectRepo.Where(mdl => mdl.ProjectId == 1 ).ToList());
}