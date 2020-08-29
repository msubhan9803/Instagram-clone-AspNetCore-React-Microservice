using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using FFMpegCore;
using Instagram.Services.Post.Extensions;
using Microsoft.AspNetCore.Http;

namespace Instagram.Services.Post.Services
{
    public class FileOptimizationService : IFileOptimizationService
    {
        public Stream CreateImageThumbnail(IFormFile file)
        {
            Stream stream = file.OpenReadStream();

            using (var image = Image.FromStream(stream))
            {
                Image thumbnail = image.GetThumbnailImage(Convert.ToInt32(Math.Round(image.Width * 0.5)), Convert.ToInt32(Math.Round(image.Height * 0.5)), () => false, IntPtr.Zero);
                return thumbnail.ToStream(ImageFormat.Jpeg);
            }
        }

        public async Task<Stream> CreateVideoThumbnailAsync(IFormFile file, string thumbnailName)
        {
            string path = Directory.GetCurrentDirectory() + Path.GetTempPath();
            Directory.CreateDirectory("tmp");
            var filePath = Path.Combine(path, file.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create)) {
                await file.CopyToAsync(fileStream);
                var mediaFileAnalysis = await FFProbe.AnalyseAsync(filePath);
                var bitmap = await FFMpeg.SnapshotAsync(mediaFileAnalysis, new Size(), TimeSpan.FromMinutes(1));
                
                Directory.Delete("tmp", true);

                return bitmap.ToStream(ImageFormat.Jpeg);
            }
        }
    }
}