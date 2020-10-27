using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Instagram.Services.Newsfeed.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<List<BsonDocument>> GetAllUsersAsync();
        Task<BsonDocument> GetUserAsync(FilterDefinition<BsonDocument> filter);
        Task AddAsync(BsonDocument document);
        Task AddFollowerAsync(
            FilterDefinition<BsonDocument> filter,
            UpdateDefinition<BsonDocument> update);
        Task SetNewsfeedTimeStampAsync(
            FilterDefinition<BsonDocument> filter, 
            UpdateDefinition<BsonDocument> update);
    }
}