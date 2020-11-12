using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Instagram.Common.DTOs.User;
using Instagram.Common.Exceptions;
using Instagram.Services.User.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Services.User.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/v1/users/
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<UserReadDto>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();

            return Ok(users);
        }

        // GET: api/v1/users/{usereName}
        [HttpGet("{userName}")]
        public async Task<ActionResult> GetUserByUsername(string userName)
        {
            try
            {
                var users = await _userService.GetUserByUsernameAsync(userName);
                if (users != null)
                {
                    return Ok(users);
                }

                return NotFound();
            }
            catch (InstagramException ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message
                });
            }
        }

        // GET: api/v1/users/follow/uid/fuid
        [HttpGet("follow/{userId}/{followedUserId}")]
        public async Task<ActionResult<object>> GetUserRelation(Guid userId, Guid followedUserId)
        {
            var userRelation = await _userService.CheckRelationshipAsync(userId, followedUserId);
            if (userRelation != null)
            {
                return Ok(userRelation);
            }

            return new {
                Relation = 0
            };
        }

        // POST: api/v1/users/follow/
        [HttpPost("follow")]
        public async Task<ActionResult<IEnumerable<UserRelationReadDto>>> CreateUserRelation([FromBody] UserRelationCreateDto userRelation)
        {
            var userRelationReadDto = await _userService.CreateUserRelationAsync(userRelation);

            return Ok(userRelationReadDto);
        }

        // DELETE: api/v1/users/unfollow/{userId}/{followedUserId}
        [HttpDelete("unfollow/{userId}/{followedUserId}")]
        public async Task<ActionResult<IEnumerable<UserRelationReadDto>>> DeleteUserRelation(Guid userId, Guid followedUserId)
        {
            var userRelationReadDto = await _userService.DeleteUserRelation(userId, followedUserId);
            if (userRelationReadDto != null)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}