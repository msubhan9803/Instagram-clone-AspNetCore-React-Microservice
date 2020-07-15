using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Instagram.Common.DTOs.Post;
using Instagram.Services.Post.Domain.Models;

namespace Instagram.Services.Post.Services
{
    public interface IUserPostService
    {
        Task<IEnumerable<UserPostReadDto>> GetAllPostsAsync();
        Task<UserPostReadDto> GetPostByIdAsync(Guid id);
        Task<UserPostReadDto> CreatePostAsync(Guid userId, UserPostCreateDto post);
        Task<UserPost> UpdatePostAsync(Guid id, UserPostUpdateDto post);
        Task<UserPost> DeletePostAsync(Guid id);   
    }
}