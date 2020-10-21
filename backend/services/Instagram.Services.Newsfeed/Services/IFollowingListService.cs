using System;
using System.Threading.Tasks;

namespace Instagram.Services.Newsfeed.Services
{
    public interface IFollowingListService
    {
        Task AddFollowedUserAsync (Guid userId, Guid followedUserId);
    }
}