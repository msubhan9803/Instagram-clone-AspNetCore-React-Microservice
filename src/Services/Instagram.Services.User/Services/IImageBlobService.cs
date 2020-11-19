using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Instagram.Common.DTOs.User;
using Instagram.Services.User.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Instagram.Services.User.Services
{
    public interface IImageBlobService
    {
        Task<BlobInfo> GetFileAsync(string fileName);
        Task UploadProfileImageBlobAsync(IFormFile file, string fileName);
    }
}