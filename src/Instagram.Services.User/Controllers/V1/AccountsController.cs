using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Instagram.Common.DTOs.User;
using Instagram.Common.Exceptions;
using Instagram.Services.User.Services;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Services.User.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // POST: api/v1/users/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserAuthenticateDto user)
        {
            try
            {
                return Json(await _accountService.LoginAsync(user.Email, user.Password));
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

        // POST: api/v1/users/
        [HttpPost("")]
        public async Task<IActionResult> Register([FromBody]UserRegisterDto user)
        {
            try
            {
                await _accountService.RegisterAsync(user.UserName, user.Email, user.Password);
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