using ConfSys.Domain.Entity;
using ConfSys.Service.Implement;
using ConfSys.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ConfSys.Api.Controllers;

[Route("[controller]/[action]")]
public class ProjectController : Controller
{
    private readonly IProjectService _projectService;
    public ProjectController(IProjectService projectService) => _projectService = projectService;


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