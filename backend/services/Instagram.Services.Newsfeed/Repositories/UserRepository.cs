using System;
using System.Threading.Tasks;
using Instagram.Services.Newsfeed.Domain.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Instagram.Services.Newsfeed.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoDatabase _database;

        public UserRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task AddAsync(BsonDocument document)
        {
            await usersCollection.InsertOneAsync(document);
        }

        public async Task AddFollowerAsync(Guid userId, Guid followerUserId)
        {
            // Pushing followedUserId to users collection
            var filter = Builders<BsonDocument>.Filter.Eq("userId", userId.ToString());
            var fListUpdate = Builders<BsonDocument>.Update.Push("followingList", followerUserId.ToString()).CurrentDate("lastModified");
            var followingList = await usersCollection.UpdateOneAsync(filter, fListUpdate);
        }

        private IMongoCollection<BsonDocument> usersCollection
            => _database.GetCollection<BsonDocument>("users");
    }
}