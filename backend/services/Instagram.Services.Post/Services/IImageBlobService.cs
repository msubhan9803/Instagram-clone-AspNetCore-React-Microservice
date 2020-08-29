using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Instagram.Common.DTOs.Post;
using Instagram.Services.Post.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Instagram.Services.Post.Services
{
    public interface IImageBlobService
    {
        Task<BlobInfo> GetBlobAsync(string name);

        Task<IEnumerable<string>> ListBlobsAsync();

        Task UploadFileBlobAsync(IFormFile file, string fileNewName);
        Task UploadFileBlobAsync(Stream file, string fileNewName);
    }
}