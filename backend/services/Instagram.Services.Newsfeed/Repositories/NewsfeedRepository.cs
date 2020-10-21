using System;
using System.Threading.Tasks;
using Instagram.Common.Commands;
using Instagram.Services.Newsfeed.Domain.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
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
                var nsfLastModified = (DateTime) user.GetValue("newsfeedLastModified");
                BsonArray fListBsonArray = (BsonArray) user.GetValue("followingList");
                var fList = fListBsonArray.ToList();

                foreach (var u in fList)
                {
                    Console.WriteLine($"Getting New Posts of User with UserId: {u}");
                    await _busCLient.PublishAsync(new GetUserNewPosts(
                        new Guid(u.ToString()), nsfLastModified));
                }
            }
        }

        private IMongoCollection<BsonDocument> usersCollection
            => _database.GetCollection<BsonDocument>("users");

        private IMongoCollection<BsonDocument> newsfeedCollection
            => _database.GetCollection<BsonDocument>("newsfeeds");
    }
}