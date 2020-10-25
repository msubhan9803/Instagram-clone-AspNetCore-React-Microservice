using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Instagram.Common.Commands;
using Instagram.Common.DTOs.Post;
using Instagram.Services.Newsfeed.Domain.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using RawRabbit;

namespace Instagram.Services.Newsfeed.Repositories
{
    public class NewsfeedRepository : INewsfeedRepository
    {
        private readonly IMongoDatabase _database;
        private readonly IBusClient _busCLient;

        public NewsfeedRepository(IMongoDatabase database, IBusClient busCLient)
        {
            _database = database;
            _busCLient = busCLient;
        }

        public async Task AddAsync(BsonDocument document)
        {
            await newsfeedCollection.InsertOneAsync(document);
        }

        public async Task UpdateNewsfeedAsync()
        {
            var usersList = await usersCollection.Find(Builders<BsonDocument>.Filter.Empty).ToListAsync();
            foreach (var user in usersList)
            {
                var userId = user.GetValue("userId");
                var nsfLastModified = (DateTime)user.GetValue("newsfeedLastModified");
                BsonArray fListBsonArray = (BsonArray)user.GetValue("followingList");
                var fList = fListBsonArray.ToList();

                foreach (var u in fList)
                {
                    Console.WriteLine($"Getting New Posts of User with UserId: {u}");
                    await _busCLient.PublishAsync(new GetUserNewPosts(
                        new Guid(userId.ToString()), new Guid(u.ToString()), nsfLastModified));
                }
            }
        }

        public async Task PushUsersNewPostsAsync(Guid userId, IEnumerable<UserPostReadDto> userNewPosts)
        {
            var usersFilter = Builders<BsonDocument>.Filter.Eq("userId", userId.ToString());
            var user = await usersCollection.Find(usersFilter).FirstOrDefaultAsync();

            var timeStamp = DateTime.UtcNow;
            var newsfeedId = user.GetValue("newsfeedId");
            var newsfeedFilter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(newsfeedId.ToString()));
            foreach (var post in userNewPosts)
            {
                var userNewPost = new UserNewPost(
                    post.Id.ToString(),
                    post.UserId.ToString(),
                    post.Caption,
                    post.FileId.ToString(),
                    post.FileType,
                    post.CreatedAt.ToString()
                );

                var newsfeedUpdate = Builders<BsonDocument>.Update.Push("newsfeed", userNewPost);
                await newsfeedCollection.UpdateOneAsync(newsfeedFilter, newsfeedUpdate);
            }

            var dateUpdate = Builders<BsonDocument>.Update.Set("lastModified", timeStamp);
            await newsfeedCollection.UpdateOneAsync(newsfeedFilter, dateUpdate);

            var usersUpdate = Builders<BsonDocument>.Update.Set("newsfeedLastModified", timeStamp).Set("lastModified", timeStamp);
            await usersCollection.UpdateOneAsync(usersFilter, usersUpdate);

            var sortCmd = string.Format(@"{
                db.getCollection('newsfeeds').update(
                    { _id: {0} },
                    {
                        $push: {
                        newsfeed: {
                            $each: [],
                            $sort: { CreatedAt: -1 }
                        }
                        }
                    }
                )}", newsfeedId);

            await _database.RunCommandAsync<string>(sortCmd);
        }

        private IMongoCollection<BsonDocument> usersCollection
            => _database.GetCollection<BsonDocument>("users");

        private IMongoCollection<BsonDocument> newsfeedCollection
            => _database.GetCollection<BsonDocument>("newsfeeds");
    }
}