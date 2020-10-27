using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Instagram.Common.DTOs.Post;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Instagram.Services.Newsfeed.Domain.Repositories
{
    public interface INewsfeedRepository
    {
        Task<BsonArray> GetUserNewsfeedAsync(
            FilterDefinition<BsonDocument> filter);
        Task<BsonArray> GetUserNewsfeedByTimeStampAsync(
            FilterDefinition<BsonDocument> filter);
        Task AddAsync(BsonDocument document);
        Task PushUsersNewPostsAsync(
            FilterDefinition<BsonDocument> filter, 
            UpdateDefinition<BsonDocument> update);
        Task SetNewsfeedTimeStampAsync(
            FilterDefinition<BsonDocument> filter, 
            UpdateDefinition<BsonDocument> update);
        Task SortNewsfeedAsync(BsonDocument command);
    }
}