using System.Collections.Generic;
using System.Threading.Tasks;
using Instagram.Common.DTOs.Post;
using Instagram.Services.Post.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Instagram.Services.Post.Services
{
    public interface IVideoBlobService
    {
        Task<BlobInfo> GetBlobAsync(string name);

        Task<IEnumerable<string>> ListBlobsAsync();

        Task UploadFileBlobAsync(IFormFile file);
    }
}