using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Instagram.Common.DTOs.Post;
using Instagram.Services.Newsfeed.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Instagram.Services.Newsfeed.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class NewsfeedsController : Controller
    {
        private readonly INewsfeedService _newsfeedService;

        public NewsfeedsController(INewsfeedService newsfeedService)
        {
            _newsfeedService = newsfeedService;
        }

        // GET: api/v1/newsfeed/{userId}
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<UserPostReadDto>>> GetUserNewsfeedAsync(Guid userId)
        {
            return Ok(await _newsfeedService.GetUserNewsfeedAsync(userId));
        }

        // Get: api/v1/newsfeed/{userId}/{timeStamp}
        [HttpGet("{userId}/{timeStamp}")]
        public async Task<ActionResult<IEnumerable<UserPostReadDto>>> GetUserNewsfeedByTimeStampAsync(
            Guid userId,
            DateTime timeStamp)
        {
            return Ok(await _newsfeedService.GetUserNewsfeedByTimeStampAsync(userId, timeStamp));
        }
    }
}