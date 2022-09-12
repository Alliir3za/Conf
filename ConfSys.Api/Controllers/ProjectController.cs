using ConfSys.Service.Implement;
using Microsoft.AspNetCore.Mvc;

namespace ConfSys.Api.Controllers
{
    [Route("[controller]/[action]")]
    public class ProjectController : Controller
    {
        private readonly ProjectService _projectService;
        public ProjectController() => _projectService = new ProjectService();

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int userId)
        => Ok(await _projectService.GetAllAsync(userId));
    }
}
