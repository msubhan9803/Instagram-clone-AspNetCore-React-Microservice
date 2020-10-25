using System;
using System.Threading.Tasks;
using Instagram.Common.Commands;
using Instagram.Common.Events;
using Instagram.Services.Post.Services;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RawRabbit;

namespace Instagram.Services.Post.Handlers
{
    public class GetUserNewPostsHandler : ICommandHandler<GetUserNewPosts>
    {
        private readonly ILogger _logger;
        private readonly IUserPostService _userPostService;
        private readonly IBusClient _busClient;

        public GetUserNewPostsHandler(ILogger<GetUserNewPosts> logger, IUserPostService userPostService, IBusClient busClient)
        {
            _logger = logger;
            _userPostService = userPostService;
            _busClient = busClient;
        }

        public async Task HandleAsync(GetUserNewPosts command)
        {
            _logger.LogInformation($"Handler Getting Posts of User: '{command.UserId}'.");
            var userPosts = await _userPostService.GetUserLatestPostsAsync(command.UserId, command.LastModified);
            var json = JsonConvert.SerializeObject(userPosts, Formatting.Indented);
            Console.WriteLine(json);

            await _busClient.PublishAsync(new UsersNewPostsFetched(command.ParentUserId, userPosts));
        }
    }
}