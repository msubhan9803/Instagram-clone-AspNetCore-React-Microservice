using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Instagram.Services.Post.Services
{
    public interface IFileOptimizationService
    {
        Stream CreateImageThumbnail(IFormFile file);
        Task<Stream> CreateVideoThumbnailAsync(IFormFile file, string thumbnailName);
    }
}