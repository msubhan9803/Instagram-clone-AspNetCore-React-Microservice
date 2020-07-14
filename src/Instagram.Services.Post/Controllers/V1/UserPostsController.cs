using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Instagram.Common.DTOs.Post;
using Instagram.Common.Exceptions;
using Instagram.Services.Post.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Services.Post.Controllers.V1
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserPostsController : Controller
    {
        private readonly IUserPostService _userPostService;

        public UserPostsController(IUserPostService userPostService)
        {
            _userPostService = userPostService;
        }

        // GET: api/v1/userposts
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<UserPostReadDto>>> GetAllUserPostsAsync()
        {
            var userPosts = await _userPostService.GetAllPostsAsync();

            return Ok(userPosts);
        }

        // GET: api/v1/userposts/{id}
        [HttpGet("{id}", Name = "GetUserPostByIdAsync")]
        public async Task<ActionResult<UserPostReadDto>> GetUserPostByIdAsync(Guid id)
        {
            try
            {
                var userPost = await _userPostService.GetPostByIdAsync(id);
                if (userPost != null) {
                    return Ok(userPost);
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

        //POST api/v1/userPosts
        [HttpPost]
        public async Task<ActionResult<UserPostCreateDto>> CreateUserPostAsync([FromBody]UserPostCreateDto post)
        {
            post.UserId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var userPostReadDto = await _userPostService.CreatePostAsync(post);

            return CreatedAtRoute(nameof(GetUserPostByIdAsync), new {Id = userPostReadDto.Id}, userPostReadDto);      
        }

        //PUT api/v1/userPosts/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserPostAsync(Guid id, [FromBody]UserPostUpdateDto post)
        {
            var userPostModel = await _userPostService.UpdatePostAsync(id, post);
            if (userPostModel != null)
            {
                return NoContent();
            }

            return NotFound();
        }

        //DELETE api/v1/userPosts/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCommand(Guid id)
        {
            var userPostModel = await _userPostService.DeletePostAsync(id);
            if (userPostModel != null)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}