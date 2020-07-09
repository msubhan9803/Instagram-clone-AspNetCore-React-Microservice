using System.Linq;
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
        public async Task<IActionResult> Login([FromBody] AuthenticateUser user)
            => Json(await _userService.LoginAsync(user.Email, user.Password));

        // Post: api/v1/users/
        [HttpPost("")]
        public async Task<IActionResult> Register([FromBody]RegisterUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new {error = ModelState.Values.SelectMany(x => x.Errors.Select(y => y.ErrorMessage)) });
            }

            await _userService.RegisterAsync(user.UserName, user.Email, user.Password);
            
            return Accepted();
        }
    }
}