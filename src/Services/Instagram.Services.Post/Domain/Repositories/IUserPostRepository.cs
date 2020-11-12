using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Instagram.Common.DTOs.Post;
using Instagram.Services.Post.Domain.Models;

namespace Instagram.Services.Post.Domain.Repositories
{
    public interface IUserPostRepository
    {
        Task<IEnumerable<UserPostReadDto>> GetAllPostsAsync();
        Task<UserPost> GetPostModelByIdAsync(Guid id);
        Task<UserPostReadDto> GetPostByIdAsync(Guid id);
        Task<IEnumerable<UserPostReadDto>> GetPostByUserIdAsync(Guid userId);
        Task<IEnumerable<UserPostReadDto>> GetUserLatestPostsAsync(Guid userId, DateTime lastModified);
        Task CreatePostAsync(UserPost post, PostFile postFileModel);
        Task UpdatePostAsync(UserPost post);
        void DeletePost(Guid id);   
    }
}