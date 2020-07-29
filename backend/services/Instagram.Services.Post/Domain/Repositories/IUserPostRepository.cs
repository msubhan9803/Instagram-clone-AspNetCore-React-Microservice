using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Instagram.Services.Post.Domain.Models;

namespace Instagram.Services.Post.Domain.Repositories
{
    public interface IUserPostRepository
    {
        Task<IEnumerable<UserPost>> GetAllPostsAsync();
        Task<UserPost> GetPostByIdAsync(Guid id);
        Task<IEnumerable<UserPost>> GetPostByUserIdAsync(Guid userId);
        Task CreatePostAsync(UserPost post, PostFile postFileModel);
        Task UpdatePostAsync(UserPost post);
        void DeletePost(Guid id);   
    }
}