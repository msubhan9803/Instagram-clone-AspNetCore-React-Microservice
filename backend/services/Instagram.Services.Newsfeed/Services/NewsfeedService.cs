using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Instagram.Common.DTOs.Post;
using Instagram.Services.Newsfeed.Domain.Repositories;

namespace Instagram.Services.Newsfeed.Services
{
    public class NewsfeedService : INewsfeedService
    {
        private readonly INewsfeedRepository _newsfeedRepository;

        public NewsfeedService(INewsfeedRepository newsfeedRepository)
        {
            _newsfeedRepository = newsfeedRepository;
        }

        public async Task PushUsersNewPostsAsync(Guid userId, IEnumerable<UserPostReadDto> userNewPosts)
        {
            await _newsfeedRepository.PushUsersNewPostsAsync(userId, userNewPosts);
        }

        public async Task UpdateNewsfeedAsync()
        {
            await _newsfeedRepository.UpdateNewsfeedAsync();
        }
    }
}