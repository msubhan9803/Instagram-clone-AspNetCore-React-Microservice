using System;
using System.Threading.Tasks;
using Instagram.Common.Events;
using Instagram.Services.Newsfeed.Services;

namespace Instagram.Services.Newsfeed.Handlers
{
    public class UsersNewPostsFetchedHandler : IEventHandler<UsersNewPostsFetched>
    {
        private readonly INewsfeedService _newsfeedService;

        public UsersNewPostsFetchedHandler(INewsfeedService newsfeedService)
        {
            _newsfeedService = newsfeedService;
        }

        public async Task HandleAsync(UsersNewPostsFetched @event)
        {
            await _newsfeedService.PushUsersNewPostsAsync(@event.ParentUserId, @event.Posts);
        }
    }
}