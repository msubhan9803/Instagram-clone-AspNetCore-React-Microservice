using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Instagram.Common.DTOs.Post;
using MongoDB.Bson;

namespace Instagram.Services.Newsfeed.Domain.Repositories
{
    public interface INewsfeedRepository
    {
        Task AddAsync(BsonDocument document);
        Task UpdateNewsfeedAsync();
        Task PushUsersNewPostsAsync(Guid userId, IEnumerable<UserPostReadDto> userNewPosts);
    }
}