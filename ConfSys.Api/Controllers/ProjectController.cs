using ConfSys.Domain.Entity;
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
         
        [HttpPost]
        public async Task<ActionResult> DeleteAsync(int userId, int projectId)
            => Ok(await _projectService.DeleteAsync(userId, projectId));

        [HttpPost]
        public async Task<ActionResult> CreateAsync(Project project)
            => Ok(await _projectService.CreateAsync(project));
    }
}
