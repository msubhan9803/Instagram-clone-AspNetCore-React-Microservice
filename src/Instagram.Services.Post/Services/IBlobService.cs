using System.Collections.Generic;
using System.Threading.Tasks;
using Instagram.Common.DTOs.Post;
using Instagram.Services.Post.Domain.Models;

namespace Instagram.Services.Post.Services
{
    public interface IBlobService
    {
        Task<BlobInfo> GetBlobAsync(string name);

        Task<IEnumerable<string>> ListBlobsAsync();

        Task UploadFileBlobAsync(string filePath, string fileName);
    }
}