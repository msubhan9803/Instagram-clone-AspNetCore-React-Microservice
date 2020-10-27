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

        public NewsfeedRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<BsonArray> GetUserNewsfeedAsync(
            FilterDefinition<BsonDocument> filter)
        {
            var newsfeedDoc = await newsfeedCollection.Find(filter).FirstOrDefaultAsync();
            return newsfeedDoc.GetValue("newsfeed").AsBsonArray;
        }

        public async Task<BsonArray> GetUserNewsfeedByTimeStampAsync(FilterDefinition<BsonDocument> filter)
        {
            var newsfeedDoc = await newsfeedCollection.Find(filter).FirstOrDefaultAsync();
            return newsfeedDoc.GetValue("newsfeed").AsBsonArray;
        }

        public async Task AddAsync(BsonDocument document)
        {
            await newsfeedCollection.InsertOneAsync(document);
        }

        public async Task PushUsersNewPostsAsync(
            FilterDefinition<BsonDocument> filter, 
            UpdateDefinition<BsonDocument> update)
        {
            await newsfeedCollection.UpdateOneAsync(filter, update);
        }

        public async Task SetNewsfeedTimeStampAsync(FilterDefinition<BsonDocument> filter, UpdateDefinition<BsonDocument> update)
        {
            await newsfeedCollection.UpdateOneAsync(filter, update);
        }

        public async Task SortNewsfeedAsync(BsonDocument command)
        {
            await _database.RunCommandAsync<BsonDocument>(command);
        }

        private IMongoCollection<BsonDocument> newsfeedCollection
            => _database.GetCollection<BsonDocument>("newsfeeds");
    }
}