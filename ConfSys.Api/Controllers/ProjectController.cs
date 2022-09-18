using ConfSys.Domain.Entity;
using ConfSys.Service.Implement;
using Microsoft.AspNetCore.Mvc;

namespace ConfSys.Api.Controllers;

[Route("[controller]/[action]")]
public class ProjectController : Controller
{
    private readonly ProjectService _projectService;
    public ProjectController() => _projectService = new ProjectService();

    [HttpGet]
    public async Task<ActionResult> GetAllAsync(int userId)
    => Ok(await _projectService.GetAllAsync(userId));

    [HttpDelete]
    public async Task<ActionResult> DeleteAsync([FromBody] int userId, int projectId)
        => Ok(await _projectService.DeleteAsync(userId, projectId));

    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromBody] Project project)
        => Ok(await _projectService.CreateAsync(project));
}