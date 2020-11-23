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
        private readonly IImageBlobService _imageBlobService;

        public UserBiosController(IUserBioService userBioService,
            IImageBlobService imageBlobService)
        {
            _userBioService = userBioService;
            _imageBlobService = imageBlobService;
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

                return NoContent();
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
        public async Task<ActionResult<UserBioReadDto>> CreateUserBioAsync([FromForm]UserBioCreateDto bio)
        {
            Console.WriteLine(bio);
            var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var response = await _userBioService.CreateUserBioAsync(userId, bio);

            return CreatedAtRoute(nameof(GetUserBioByUserIdAsync), new {userId = response.Item1}, response.Item2);      
        }

        [AllowAnonymous]
        // GET: api/v1/userbios/file/{userId}
        [HttpGet("file/{userId}", Name = "GetUserProfileImageasync")]
        public async Task<IActionResult> GetUserProfileImageasync(Guid userId)
        {
            var userBio = await _userBioService.GetBioByUserIdAsync(userId);
            var data = await _imageBlobService.GetFileAsync(userBio.ProfileImageName);
            return File(data.Content, data.ContentType);
        }

        //PUT api/v1/userBios/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserBioAsync(Guid id, [FromBody]UserBioUpdateDto post)
        {
            var UserBioModel = await _userBioService.UpdateUserBioAsync(id, post);
            if (UserBioModel != null)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}