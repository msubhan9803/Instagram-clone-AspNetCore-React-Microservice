using System;
using System.Threading.Tasks;
using Instagram.Common.Commands;
using Instagram.Common.Events;
using Instagram.Common.Exceptions;
using Instagram.Services.Newsfeed.Domain.Repositories;
using Instagram.Services.Newsfeed.Services;
using Microsoft.Extensions.Logging;
using RawRabbit;

namespace Instagram.Services.Newsfeed.Handlers
{
    public class UserFollowedHandler : IEventHandler<UserFollowed>
    {
        private readonly ILogger _logger;
        private readonly IBusClient _busClient;
        private readonly IUserService _userService;

        public UserFollowedHandler(IBusClient busClient,
            ILogger<UserCreated> logger, IUserService userService)
        {
            _busClient = busClient;
            _logger = logger;
            _userService = userService;
        }

        public async Task HandleAsync(UserFollowed @event)
        {
            _logger.LogInformation($"Adding FollowedUserId to UserId followingList collection: '{@event.UserId}'.");
            await _userService.AddFollowedUserAsync(@event.UserId, @event.FollowedUserId);
        }
    }
}