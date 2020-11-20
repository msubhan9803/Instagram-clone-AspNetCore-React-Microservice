using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Instagram.Common.Commands;
using Instagram.Common.DTOs.Newsfeed;
using Instagram.Common.DTOs.Post;
using Instagram.Services.Newsfeed.Domain.Repositories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;
using RawRabbit;

namespace Instagram.Services.Newsfeed.Services
{
    public class NewsfeedService : INewsfeedService
    {
        private readonly INewsfeedRepository _newsfeedRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBusClient _busCLient;

        public NewsfeedService(
            INewsfeedRepository newsfeedRepository,
            IUserRepository userRepository,
            IBusClient busCLient)
        {
            _newsfeedRepository = newsfeedRepository;
            _userRepository = userRepository;
            _busCLient = busCLient;
        }

        public async Task<IEnumerable<UserPostReadDto>> GetUserNewsfeedAsync(Guid userId)
        {
            var userFilter = Builders<BsonDocument>.Filter.Eq("userId", userId.ToString());
            var user = await _userRepository.GetUserAsync(userFilter);

            var newsfeedId = user.GetValue("newsfeedId");
            var newsfeedFilter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(newsfeedId.ToString()));
            var newsfeedResult = await _newsfeedRepository.GetUserNewsfeedAsync(newsfeedFilter);

            var newsfeedArray = newsfeedResult.Select(p => p.AsBsonDocument).ToArray();

            var userPostList = new List<UserPostReadDto>();
            foreach (var post in newsfeedArray)
            {
                var userPost = new UserPostReadDto(
                    new Guid(post.GetValue("_id").ToString()),
                    new Guid(post.GetValue("UserId").ToString()),
                    post.GetValue("UserName").ToString(),
                    post.GetValue("Caption").ToString(),
                    new Guid(post.GetValue("FileId").ToString()),
                    post.GetValue("FileType").ToString(),
                    Convert.ToDateTime(post.GetValue("CreatedAt").ToString())
                );

                userPostList.Add(userPost);
            }

            return userPostList;
        }

        public async Task<IEnumerable<UserPostReadDto>> GetUserNewsfeedByTimeStampAsync(
            Guid userId,
            long timeStamp)
        {
            DateTime dt_1970 = new DateTime(1970, 1, 1);
            long tricks_1970 = dt_1970.Ticks;
            long time_tricks = tricks_1970 + timeStamp * 10000;
            DateTime dt = new DateTime(time_tricks);
            var utcDate = dt + TimeSpan.FromHours(5);

            var userFilter = Builders<BsonDocument>.Filter.Eq("userId", userId.ToString());
            var user = await _userRepository.GetUserAsync(userFilter);

            var newsfeedId = user.GetValue("newsfeedId");
            var newsfeedFilter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(newsfeedId.ToString()));
            var newsfeedResult = await _newsfeedRepository.GetUserNewsfeedAsync(newsfeedFilter);

            var newsfeedByList = newsfeedResult.Select(p => p.AsBsonDocument).
                Where(p => Convert.ToDateTime(p.GetValue("CreatedAt")) > utcDate).ToList();

            var userPostList = new List<UserPostReadDto>();
            foreach (var post in newsfeedByList)
            {
                var userPost = new UserPostReadDto(
                    new Guid(post.GetValue("_id").ToString()),
                    new Guid(post.GetValue("UserId").ToString()),
                    post.GetValue("UserName").ToString(),
                    post.GetValue("Caption").ToString(),
                    new Guid(post.GetValue("FileId").ToString()),
                    post.GetValue("FileType").ToString(),
                    Convert.ToDateTime(post.GetValue("CreatedAt").ToString())
                );

                userPostList.Add(userPost);
            }

            return userPostList;
        }

        public async Task PushUsersNewPostsAsync(Guid userId, IEnumerable<UserPostReadDto> userNewPosts)
        {
            var usersFilter = Builders<BsonDocument>.Filter.Eq("userId", userId.ToString());
            var user = await _userRepository.GetUserAsync(usersFilter);

            var timeStamp = DateTime.UtcNow;
            var newsfeedId = user.GetValue("newsfeedId");
            var newsfeedFilter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(newsfeedId.ToString()));

            foreach (var post in userNewPosts)
            {
                var userNewPost = new UserNewPost(
                    post.Id.ToString(),
                    post.UserId.ToString(),
                    post.UserName.ToString(),
                    post.Caption,
                    post.FileId.ToString(),
                    post.FileType,
                    post.CreatedAt.ToString()
                );

                var newsfeedUpdate = Builders<BsonDocument>.Update.Push("newsfeed", userNewPost);
                await _newsfeedRepository.PushUsersNewPostsAsync(newsfeedFilter, newsfeedUpdate);
            }

            var newsfeedDateUpdate = Builders<BsonDocument>.Update.Set("lastModified", timeStamp);
            await _newsfeedRepository.SetNewsfeedTimeStampAsync(newsfeedFilter, newsfeedDateUpdate);

            var usersUpdate = Builders<BsonDocument>.Update.Set("newsfeedLastModified", timeStamp).Set("lastModified", timeStamp);
            await _userRepository.SetNewsfeedTimeStampAsync(usersFilter, usersUpdate);

            var sortCommand = new BsonDocument {
                    new BsonElement("update", "newsfeeds"),
                    new BsonElement("updates", new BsonArray {
                        new BsonDocument {
                            new BsonElement("q", new BsonDocument {
                                new BsonElement("_id", new BsonObjectId(new ObjectId(newsfeedId.ToString())))
                            }),
                            new BsonElement("u", new BsonDocument {
                                new BsonElement("$push", new BsonDocument {
                                    new BsonElement("newsfeed", new BsonDocument {
                                        new BsonElement("$each", new BsonArray()),
                                        new BsonElement("$sort", new BsonDocument {
                                            new BsonElement("CreatedAt", -1)
                                        })
                                    })
                                })
                            })
                        }
                    })
                };

            await _newsfeedRepository.SortNewsfeedAsync(sortCommand);
        }

        public async Task UpdateNewsfeedAsync()
        {
            var usersList = await _userRepository.GetAllUsersAsync();
            
            if (usersList.Count > 0) 
            {
                foreach (var user in usersList)
                {
                    var userId = user.GetValue("userId");
                    var nsfLastModified = (DateTime)user.GetValue("newsfeedLastModified");
                    BsonArray fListBsonArray = (BsonArray)user.GetValue("followingList");

                    var fList = fListBsonArray.ToList();

                    // Initiate GetUserNewsPosts command for UserId as well
                    Console.WriteLine($"Getting New Posts of User with UserId: {userId}");
                        await _busCLient.PublishAsync(new GetUserNewPosts(
                            new Guid(userId.ToString()), new Guid(userId.ToString()), nsfLastModified));

                    foreach (var u in fList)
                    {
                        Console.WriteLine($"Getting New Posts of User with UserId: {u}");
                        await _busCLient.PublishAsync(new GetUserNewPosts(
                            new Guid(userId.ToString()), new Guid(u.ToString()), nsfLastModified));
                    }
                }
            }
        }
    }
}