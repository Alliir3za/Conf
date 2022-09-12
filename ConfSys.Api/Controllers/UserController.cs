using ConfSys.Domain.Dtos.User;
using ConfSys.Domain.Entity;
using ConfSys.Service.Implement;
using Microsoft.AspNetCore.Mvc;

namespace ConfSys.Api.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly UserService _userService;
        public UserController() => _userService = new UserService();

        [HttpGet]
        public async Task<ActionResult> GetAll()
          => Ok(await _userService.GetAll());

        [HttpPost]
        public async Task<ActionResult> CreateAsync(User user)
         => Ok(await _userService.CreateAsync(user));

        [HttpPost]
        public async Task<ActionResult> LoginAsync([FromBody] UserLoginDto model)
            => Ok(await _userService.LoginAsync(model.Email, model.Password));

    }
}
