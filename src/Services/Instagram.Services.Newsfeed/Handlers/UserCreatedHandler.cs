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
    public class UserCreatedHandler : IEventHandler<UserCreated>
    {
        private readonly ILogger _logger;
        private readonly IBusClient _busClient;
        private readonly IUserService _userService;

        public UserCreatedHandler(IBusClient busClient,
            ILogger<UserCreated> logger, IUserService userService)
        {
            _busClient = busClient;
            _logger = logger;
            _userService = userService;
        }

        public async Task HandleAsync(UserCreated @event)
        {
            _logger.LogInformation($"Creating Newsfeed of user: '{@event.UserId}'.");
            await _userService.CreateUserAsync(@event.UserId);
        }
    }
}