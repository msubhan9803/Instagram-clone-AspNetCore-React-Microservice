using System;
using System.Threading.Tasks;
using BlobInfo = Instagram.Common.DTOs.Post.BlobInfo;

namespace Instagram.Services.Post.Services
{
    public interface IPostFileService
    {
        Task<BlobInfo> GetPostFileAsync(Guid postFileId);
        Task<BlobInfo> GetPostFileTHumbnailAsync(Guid postFileId);
    }
}