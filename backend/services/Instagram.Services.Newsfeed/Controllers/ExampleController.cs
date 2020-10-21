using System.Threading.Tasks;
using Instagram.Services.Newsfeed.Services;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Services.Newsfeed.Controllers
{

    [Route("api/v1/[controller]")]
    public class ExampleController : Controller
    {
        private readonly INewsfeedService _newsfeedService;

        public ExampleController(INewsfeedService newsfeedService)
        {
            _newsfeedService = newsfeedService;
        }

        // GET: api/v1/example
        [HttpGet()]
        public async Task GetAllUserPostsAsync()
        {
            await _newsfeedService.UpdateNewsfeedAsync();
        }
    }
}