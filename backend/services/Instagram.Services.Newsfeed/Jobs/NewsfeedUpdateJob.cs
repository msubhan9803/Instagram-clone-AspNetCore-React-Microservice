using System;
using System.Threading.Tasks;
using Instagram.Services.Newsfeed.Services;

namespace Instagram.Services.Newsfeed.Jobs
{
    public class NewsfeedUpdateJob : INewsfeedUpdateJob
    {
        private readonly INewsfeedService _newsfeedService;

        public NewsfeedUpdateJob(INewsfeedService newsfeedService)
        {
            _newsfeedService = newsfeedService;
        }

        public async Task UpdateNewsfeedAsync()
        {
            await _newsfeedService.UpdateNewsfeedAsync();
            Console.WriteLine("Updated Newsfeed!");
        }
    }
}