using System;
using System.Threading.Tasks;
using Instagram.Services.Post.Domain.Repositories;
using BlobInfo = Instagram.Common.DTOs.Post.BlobInfo;

namespace Instagram.Services.Post.Services
{
    public class PostFileService : IPostFileService
    {
        public IPostFileRepository _postFileRepository;
        private readonly IBlobService _blobService;
        public PostFileService(IPostFileRepository postFileRepository, IBlobService blobService)
        {
            _blobService = blobService;
            _postFileRepository = postFileRepository;

        }

        public async Task<BlobInfo> GetPostFileAsync(Guid postFileId)
        {
            var postFileName = await _postFileRepository.GetPostFileNameByIdAsync(postFileId);
            return await _blobService.GetBlobAsync(postFileName);
        }
    }
}