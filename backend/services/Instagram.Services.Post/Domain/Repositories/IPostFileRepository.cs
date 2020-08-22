using System;
using System.Threading.Tasks;
using Instagram.Services.Post.Domain.Models;

namespace Instagram.Services.Post.Domain.Repositories
{
    public interface IPostFileRepository
    {
        Task<PostFile> GetPostFileByIdAsync(Guid postFileId);
    }
}