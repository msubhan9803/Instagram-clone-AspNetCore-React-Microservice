using System.IO;

namespace Instagram.Common.DTOs.User
{
    public class BlobInfo
    {
        public Stream Content { get; }
        public string ContentType { get; }

        public BlobInfo(Stream content, string contentType)
        {
            Content = content;
            ContentType = contentType;
        }
    }
}