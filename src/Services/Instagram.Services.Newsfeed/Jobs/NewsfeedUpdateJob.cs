using System;
using System.Threading.Tasks;
using Instagram.Services.Newsfeed.Hubs;
using Instagram.Services.Newsfeed.Hubs.Client;
using Instagram.Services.Newsfeed.Services;
using Microsoft.AspNetCore.SignalR;

namespace Instagram.Services.Newsfeed.Jobs
{
    public class NewsfeedUpdateJob : INewsfeedUpdateJob
    {
        private readonly INewsfeedService _newsfeedService;
        private readonly IHubContext<NewsfeedHub, INewsfeedClient> _newsfeedHub;

        public NewsfeedUpdateJob(
            INewsfeedService newsfeedService, 
            IHubContext<NewsfeedHub, INewsfeedClient> newsfeedHub)
        {
            _newsfeedService = newsfeedService;
            _newsfeedHub = newsfeedHub;
        }

        public async Task UpdateNewsfeedAsync()
        {
            Console.WriteLine($"Newsfeed update is in Progress");
            await _newsfeedService.UpdateNewsfeedAsync();

            await _newsfeedHub.Clients.All.FetchNewsfeed();
            Console.WriteLine($"Sent FetchNewsfeed Message");
        }
    }
}