using System;
using System.Linq;
using System.Threading.Tasks;
using Instagram.Common.DTOs.User;
using Instagram.Common.Exceptions;
using Instagram.Services.User.Services;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Services.User.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
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
        {
            try
            {
                return Json(await _userService.LoginAsync(user.Email, user.Password));
            }
            catch (InstagramException ex)
            {
                // _logger.LogError(ex, ex.Message);
                return BadRequest(new {
                    Error = ex.Message
                });
            }
            catch (Exception ex)
            {
                // _logger.LogError(ex, ex.Message);
                return BadRequest(new {
                    Error = ex.Message
                }); 
            }
        }

        // Post: api/v1/users/
        [HttpPost("")]
        public async Task<IActionResult> Register([FromBody]RegisterUser user)
        {
            try
            {
                await _userService.RegisterAsync(user.UserName, user.Email, user.Password);
                return Accepted();
            }
            catch (InstagramException ex)
            {
                // _logger.LogError(ex, ex.Message);
                return BadRequest(new {
                    Error = ex.Message
                });
            }
            catch (Exception ex)
            {
                // _logger.LogError(ex, ex.Message);
                return BadRequest(new {
                    Error = ex.Message
                }); 
            }
        }
    }
}