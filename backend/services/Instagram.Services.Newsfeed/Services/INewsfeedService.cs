using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Instagram.Common.DTOs.Post;

namespace Instagram.Services.Newsfeed.Services
{
    public interface INewsfeedService
    {
        Task<IEnumerable<UserPostReadDto>> GetUserNewsfeedAsync(Guid userId);
        Task<IEnumerable<UserPostReadDto>> GetUserNewsfeedByTimeStampAsync(
            Guid userId,
            DateTime timeStamp);
        Task PushUsersNewPostsAsync(Guid userId, IEnumerable<UserPostReadDto> userNewPosts);
        Task UpdateNewsfeedAsync();
    }
}