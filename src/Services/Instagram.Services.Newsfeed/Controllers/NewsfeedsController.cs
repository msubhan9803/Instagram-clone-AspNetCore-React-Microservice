using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Instagram.Common.DTOs.Post;
using Instagram.Services.Newsfeed.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Instagram.Services.Newsfeed.Hubs;
using Instagram.Services.Newsfeed.Hubs.Client;
using Microsoft.AspNetCore.SignalR;

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
        private readonly IHubContext<NewsfeedHub, INewsfeedClient> _newsfeedHub;

        public NewsfeedsController(INewsfeedService newsfeedService, 
            IHubContext<NewsfeedHub, INewsfeedClient> newsfeedHub)
        {
            _newsfeedService = newsfeedService;
            _newsfeedHub = newsfeedHub;
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
            long timeStamp)
        {
            return Ok(await _newsfeedService.GetUserNewsfeedByTimeStampAsync(userId, timeStamp));
        }
    }
}