using System.Threading.Tasks;
using Instagram.Common.DTOs.User;
using Instagram.Services.User.Services;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Services.User.Controllers.V1
{
    [Route("api/v1/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // Post: api/v1/users/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthenticateUser command)
            => Json(await _userService.LoginAsync(command.Email, command.Password));

        // Post: api/v1/users/
        [HttpPost("")]
        public async Task<IActionResult> Register([FromBody]RegisterUser command)
        {
            await _userService.RegisterAsync(command.UserName, command.Email, command.Password);
            
            return Accepted();
        }
    }
}