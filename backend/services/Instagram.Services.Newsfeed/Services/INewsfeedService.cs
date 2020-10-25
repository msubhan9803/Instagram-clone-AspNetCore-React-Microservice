using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Instagram.Common.DTOs.Post;

namespace Instagram.Services.Newsfeed.Services
{
    public interface INewsfeedService
    {
        Task PushUsersNewPostsAsync(Guid userId, IEnumerable<UserPostReadDto> userNewPosts);
        Task UpdateNewsfeedAsync();
    }
}