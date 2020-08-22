using System;
using System.Collections.Generic;
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
        private readonly IMapper _mapper;

        public UserPostService(IUserPostRepository userPostRepository,
            IImageBlobService blobService, IMapper mapper = null, IVideoBlobService videoBlobService = null)
        {
            _userPostRepository = userPostRepository;
            _mapper = mapper;
            _imageBlobService = blobService;
            _videoBlobService = videoBlobService;
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
            var contentType = post.File.FileName.GetContentType().Substring(0, 5);
            
            if (contentType == "image")
            {
                await _imageBlobService.UploadFileBlobAsync(post.File);
            } else if (contentType == "video") {
                await _videoBlobService.UploadFileBlobAsync(post.File);
            }

            var postFileModel = new PostFile(post.File.FileName, contentType);
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