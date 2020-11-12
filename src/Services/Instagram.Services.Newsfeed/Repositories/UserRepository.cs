using System;
using System.Collections.Generic;
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

        public async Task<List<BsonDocument>> GetAllUsersAsync()
        {
            return await usersCollection.Find(Builders<BsonDocument>.Filter.Empty).ToListAsync();
        }

        public async Task<BsonDocument> GetUserAsync(FilterDefinition<BsonDocument> filter)
        {
            return await usersCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task AddAsync(BsonDocument document)
        {
            await usersCollection.InsertOneAsync(document);
        }

        public async Task AddFollowerAsync(
            FilterDefinition<BsonDocument> filter,
            UpdateDefinition<BsonDocument> update)
        {
            await usersCollection.UpdateOneAsync(filter, update);
        }

        public async Task SetNewsfeedTimeStampAsync(
            FilterDefinition<BsonDocument> filter, 
            UpdateDefinition<BsonDocument> update)
        {
            await usersCollection.UpdateOneAsync(filter, update);
        }

        private IMongoCollection<BsonDocument> usersCollection
            => _database.GetCollection<BsonDocument>("users");
    }
}