using System;
using System.Threading.Tasks;
using Instagram.Common.Commands;
using Instagram.Services.Post.Services;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Instagram.Services.Post.Handlers
{
    public class GetUserNewPostsHandler : ICommandHandler<GetUserNewPosts>
    {
        private readonly ILogger _logger;
        private readonly IUserPostService _userPostService;

        public GetUserNewPostsHandler(ILogger<GetUserNewPosts> logger, IUserPostService userPostService)
        {
            _logger = logger;
            _userPostService = userPostService;
        }

        public async Task HandleAsync(GetUserNewPosts command)
        {
            _logger.LogInformation($"Handler Getting Posts of User: '{command.UserId}'.");
            var userPosts = await _userPostService.GetUserLatestPostsAsync(command.UserId, command.LastModified);

            var json = JsonConvert.SerializeObject(userPosts, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
}