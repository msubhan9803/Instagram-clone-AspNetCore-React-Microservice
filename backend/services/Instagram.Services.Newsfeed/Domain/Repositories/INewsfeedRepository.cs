using System.Threading.Tasks;
using MongoDB.Bson;

namespace Instagram.Services.Newsfeed.Domain.Repositories
{
    public interface INewsfeedRepository
    {
        Task AddAsync(BsonDocument document);
        Task UpdateNewsfeedAsync();
    }
}