using Microsoft.AspNetCore.StaticFiles;

namespace Instagram.Services.Post.Extensions
{
    public static class FileExtensions
    {
        private static readonly FileExtensionContentTypeProvider Provider = new FileExtensionContentTypeProvider();
        
        public static string GetContentType(this string fileName)
        {
            if(!Provider.TryGetContentType(fileName, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }
    }
}