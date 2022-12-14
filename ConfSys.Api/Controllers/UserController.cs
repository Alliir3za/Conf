using ConfSys.Domain.Dtos.User;
using ConfSys.Domain.Entity;
using ConfSys.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ConfSys.Api.Controllers;

[ApiVersion("1.0")]
[Route("[controller]/[action]")]
public class UserController : Controller
{
    private readonly IUserService _userService;
    public UserController(IUserService userService) => _userService = userService;

    [HttpGet]
    public async Task<ActionResult> GetAll()
      => Ok(await _userService.GetAll());

    //[HttpPost]
    //public async Task<ActionResult> CreateAsync(User user)
    // => Ok(await _userService.CreateAsync(user));

    [HttpPost]
    public async Task<ActionResult> LoginAsync([FromBody] UserLoginDto model)
        => Ok(await _userService.LoginAsync(model.Email, model.Password));

    //[HttpPost]
    //public async Task<ActionResult> DeleteAsync(int userId)
    //    => Ok(await _userService.DeleteAsync(userId));

    //[HttpPost]
    //public async Task<ActionResult> Update([FromBody] UserUpdateDto model)
    //    => Ok(await _userService.Update(model));

    [HttpGet]
    public async Task<ActionResult> GetList()
        => Ok(await _userService.GetList());
}