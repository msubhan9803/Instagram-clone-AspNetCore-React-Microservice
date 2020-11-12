using System;
using System.Threading.Tasks;

namespace Instagram.Services.Newsfeed.Services
{
    public interface IUserService
    {
        Task CreateUserAsync(Guid userId);
        Task AddFollowedUserAsync (Guid userId, Guid followedUserId);
    }
}