using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Instagram.Common.DTOs.Post;
using Instagram.Common.Exceptions;
using Instagram.Services.Post.Domain.Models;
using Instagram.Services.Post.Domain.Repositories;
using Instagram.Services.Post.Extensions;
using Newtonsoft.Json;

namespace Instagram.Services.Post.Services
{
    public class UserPostService : IUserPostService
    {
        private readonly IUserPostRepository _userPostRepository;
        private readonly IImageBlobService _imageBlobService;
        private readonly IVideoBlobService _videoBlobService;
        private readonly IFileOptimizationService _fileOptimizationService;
        private readonly IMapper _mapper;

        public UserPostService(IUserPostRepository userPostRepository,
            IImageBlobService blobService, IMapper mapper = null, 
            IVideoBlobService videoBlobService = null, IFileOptimizationService fileOptimizationService = null)
        {
            _userPostRepository = userPostRepository;
            _mapper = mapper;
            _imageBlobService = blobService;
            _videoBlobService = videoBlobService;
            _fileOptimizationService = fileOptimizationService;
        }

        public async Task<IEnumerable<UserPostReadDto>> GetAllPostsAsync()
        {
            return await _userPostRepository.GetAllPostsAsync();
        }

        public async Task<UserPostReadDto> GetPostByIdAsync(Guid id)
        {
            if (id == null)
            {
                throw new InstagramException("id_is_null",
                    $"Id is required, can't be null.");
            }

            return await _userPostRepository.GetPostByIdAsync(id);
        }

        public async Task<IEnumerable<UserPostReadDto>> GetPostByUserIdAsync(Guid userId)
        {
            if (userId == null)
            {
                throw new InstagramException("id_is_null",
                    $"User Id is required, can't be null.");
            }

            return await _userPostRepository.GetPostByUserIdAsync(userId);
        }

        public async Task<UserPostReadDto> CreatePostAsync(Guid userId, UserPostCreateDto post)
        {
            var contentType = post.File.FileName.GetContentType();
            var type = contentType.Substring(0, 5);
            var extension = contentType.Substring(6);
            var fileNewNameGuid = Guid.NewGuid().ToString();
            var fileNewName = fileNewNameGuid + '.' + extension;
            var thumbnailNewName = Guid.NewGuid().ToString() + ".jpeg";

            if (type == "image")
            {
                var thumbnail = _fileOptimizationService.CreateImageThumbnail(post.File);
                await _imageBlobService.UploadFileBlobAsync(post.File, fileNewName);
                await _imageBlobService.UploadFileBlobAsync(thumbnail, thumbnailNewName);
            } else if (type == "video") {
                var thumbnail = await _fileOptimizationService.CreateVideoThumbnailAsync(post.File, thumbnailNewName);
                await _videoBlobService.UploadFileBlobAsync(post.File, fileNewName);
                await _imageBlobService.UploadFileBlobAsync(thumbnail, thumbnailNewName);
            }

            var postFileModel = new PostFile(fileNewName, type, thumbnailNewName);
            var userPostModel = new UserPost(userId, post.Caption, postFileModel.Id);
            await _userPostRepository.CreatePostAsync(userPostModel, postFileModel);
            
            return await _userPostRepository.GetPostByIdAsync(userPostModel.Id);
        }

        public async Task<UserPost> UpdatePostAsync(Guid id, UserPostUpdateDto post)
        {
            var userPostModel = await _userPostRepository.GetPostModelByIdAsync(id);

            if(userPostModel == null)
            {
                return userPostModel;
            }

            _mapper.Map(post, userPostModel);
            await _userPostRepository.UpdatePostAsync(userPostModel);

            return userPostModel;
        }

        public async Task<UserPost> DeletePostAsync(Guid id)
        {
            var userPostModel = await _userPostRepository.GetPostModelByIdAsync(id);
            
            if(userPostModel == null)
            {
                return userPostModel;
            }
            
            _userPostRepository.DeletePost(id);

            return userPostModel;
        }
    }
}