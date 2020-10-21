using System;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Instagram.Services.Newsfeed.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(BsonDocument document);
        Task AddFollowerAsync(Guid userId, Guid followerUserId);
    }
}