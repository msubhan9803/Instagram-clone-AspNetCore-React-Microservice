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
using Newtonsoft.Json;

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
        private readonly IPostFileService _postFileService;

        public UserPostsController(IUserPostService userPostService, IPostFileService postFileService)
        {
            _postFileService = postFileService;
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
                if (userPost != null)
                {
                    return Ok(userPost);
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

        // GET: api/v1/userposts/file/{postFileId}
        [HttpGet("file/{postFileId}", Name = "GetUserPostFileByPostFileIdAsync")]
        public async Task<IActionResult> GetUserPostFileByPostFileIdAsync(Guid postFileId)
        {
            var data = await _postFileService.GetPostFileAsync(postFileId);
            return File(data.Content, data.ContentType);
        }

        // GET: api/v1/userposts/user/{userId}
        [HttpGet("user/{userId}", Name = "GetUserPostByUserIdAsync")]
        public async Task<ActionResult<IEnumerable<UserPostReadDto>>> GetUserPostByUserIdAsync(Guid userId)
        {
            try
            {
                var userPost = await _userPostService.GetPostByUserIdAsync(userId);
                if (userPost != null)
                {
                    return Ok(userPost);
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

        //POST api/v1/userPosts
        [HttpPost]
        public async Task<ActionResult<UserPostCreateDto>> CreateUserPostAsync([FromBody] UserPostCreateDto post)
        {
            var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var userPostReadDto = await _userPostService.CreatePostAsync(userId, post);

            return CreatedAtRoute(nameof(GetUserPostFileByPostFileIdAsync), new { postFileId = userPostReadDto.FileId }, userPostReadDto);
        }

        //PUT api/v1/userPosts/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserPostAsync(Guid id, [FromBody] UserPostUpdateDto post)
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