using System;
using System.Threading.Tasks;
using Instagram.Services.Newsfeed.Domain.Repositories;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;

namespace Instagram.Services.Newsfeed.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly INewsfeedRepository _newsfeedRepository;
        private readonly ILogger _logger;

        public UserService(IUserRepository userRepository,
        ILogger<UserService> logger, INewsfeedRepository newsfeedRepository)
        {
            _userRepository = userRepository;
            _logger = logger;
            _newsfeedRepository = newsfeedRepository;
        }

        public async Task CreateUserAsync(Guid userId)
        {
            var followingListId = ObjectId.GenerateNewId();
            var newsfeedId = ObjectId.GenerateNewId();

            var userDocument = new BsonDocument {
                new BsonElement("userId", userId.ToString()),
                new BsonElement("followingList", new BsonArray ()),
                new BsonElement("newsfeedId", newsfeedId),
                new BsonElement("newsfeedLastModified", new BsonDateTime(DateTime.UtcNow))
            };
            _logger.LogInformation($"Adding User Document to User Collection");
            await _userRepository.AddAsync(userDocument);

            var newsfeedDocument = new BsonDocument {
                new BsonElement("_id", newsfeedId),
                new BsonElement("newsfeed", new BsonArray ()),
                new BsonElement("lastModified", new BsonDateTime(DateTime.UtcNow))
            };
            _logger.LogInformation($"Adding Newsfeed Document to Newsfeed Collection");
            await _newsfeedRepository.AddAsync(newsfeedDocument);
        }

        public async Task AddFollowedUserAsync(Guid userId, Guid followedUserId)
        {
            await _userRepository.AddFollowerAsync(userId, followedUserId);
        }
    }
}