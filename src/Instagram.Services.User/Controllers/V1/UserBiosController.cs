using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Instagram.Common.DTOs.User;
using Instagram.Common.Exceptions;
using Instagram.Services.User.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Services.User.Controllers.V1
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserBiosController : Controller
    {
        private readonly IUserBioService _userBioService;

        public UserBiosController(IUserBioService userBioService)
        {
            _userBioService = userBioService;
        }

        // GET: api/v1/userBios/{userId}
        [HttpGet("{userId}", Name = "GetUserBioByUserIdAsync")]
        public async Task<ActionResult<UserBioReadDto>> GetUserBioByUserIdAsync(Guid userId)
        {
            try
            {
                var userBio = await _userBioService.GetBioByUserIdAsync(userId);
                if (userBio != null) {
                    return Ok(userBio);
                }

                return NotFound();
            }
            catch (InstagramException ex)
            {
                return BadRequest(new {
                    Error = ex.Message
                }); 
            }
        }

        //POST api/v1/userBios
        [HttpPost]
        public async Task<ActionResult<UserBioCreateDto>> CreateUserBioAsync([FromBody]UserBioCreateDto bio)
        {
            bio.UserId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var userBioReadDto = await _userBioService.CreateBioAsync(bio);

            return CreatedAtRoute(nameof(GetUserBioByUserIdAsync), new {Id = userBioReadDto.Id}, userBioReadDto);      
        }

        //PUT api/v1/userBios/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserBioAsync(Guid id, [FromBody]UserBioUpdateDto post)
        {
            var UserBioModel = await _userBioService.UpdateBioAsync(id, post);
            if (UserBioModel != null)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}