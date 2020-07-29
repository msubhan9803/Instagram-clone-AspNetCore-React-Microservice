using System;
using System.Threading.Tasks;

namespace Instagram.Services.Post.Domain.Repositories
{
    public interface IPostFileRepository
    {
        Task<string> GetPostFileNameByIdAsync(Guid postFileId);
    }
}