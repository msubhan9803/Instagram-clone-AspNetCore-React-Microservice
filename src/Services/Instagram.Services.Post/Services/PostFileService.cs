using System;
using System.Threading.Tasks;
using Instagram.Services.Post.Domain.Repositories;
using BlobInfo = Instagram.Common.DTOs.Post.BlobInfo;

namespace Instagram.Services.Post.Services
{
    public class PostFileService : IPostFileService
    {
        public IPostFileRepository _postFileRepository;
        private readonly IImageBlobService _imageBlobService;
        private readonly IVideoBlobService _videoBlobService;
        public PostFileService(IPostFileRepository postFileRepository, 
            IImageBlobService blobService, IVideoBlobService videoBlobService)
        {
            _imageBlobService = blobService;
            _postFileRepository = postFileRepository;
            _videoBlobService = videoBlobService;
        }

        public async Task<BlobInfo> GetPostFileAsync(Guid postFileId)
        {
            var postFile = await _postFileRepository.GetPostFileByIdAsync(postFileId);

            if (postFile.Type == "image")
            {
                return await _imageBlobService.GetBlobAsync(postFile.Name);
            } else {
                return await _videoBlobService.GetBlobAsync(postFile.Name);
            }
        }

        public async Task<BlobInfo> GetPostFileTHumbnailAsync(Guid postFileId)
        {
            var postFileThumb = await _postFileRepository.GetPostFileThumbnailByIdAsync(postFileId);

            if (postFileThumb != null)
            {
                return await _imageBlobService.GetBlobAsync(postFileThumb);
            }

            return null;
        }
    }
}