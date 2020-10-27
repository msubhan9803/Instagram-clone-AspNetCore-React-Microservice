using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Instagram.Common.DTOs.Post;
using Instagram.Services.Newsfeed.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Instagram.Services.Newsfeed.Controllers
{

    [Route("api/v1/[controller]")]
    public class NewsfeedController : Controller
    {
        private readonly INewsfeedService _newsfeedService;

        public NewsfeedController(INewsfeedService newsfeedService)
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