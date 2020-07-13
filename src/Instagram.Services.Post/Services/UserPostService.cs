using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Instagram.Common.DTOs.Post;
using Instagram.Common.Exceptions;
using Instagram.Services.Post.Domain.Models;
using Instagram.Services.Post.Domain.Repositories;

namespace Instagram.Services.Post.Services
{
    public class UserPostService : IUserPostService
    {
        private readonly IUserPostRepository _userPostRepository;
        private readonly IMapper _mapper;

        public UserPostService(IUserPostRepository userPostRepository, IMapper mapper = null)
        {
            _userPostRepository = userPostRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserPostReadDto>> GetAllPostsAsync()
        {
            var userPosts = await _userPostRepository.GetAllPostsAsync();

            return _mapper.Map<IEnumerable<UserPostReadDto>>(userPosts);
        }

        public async Task<UserPostReadDto> GetPostByIdAsync(Guid id)
        {
            if (id == null)
            {
                throw new InstagramException("id_is_null",
                    $"User Id is required, can't be null.");
            }

            var userPost = await _userPostRepository.GetPostByIdAsync(id);
            
            return _mapper.Map<UserPostReadDto>(userPost);
        }

        public async Task<UserPostReadDto> CreatePostAsync(UserPostCreateDto post)
        {
            var userPostModel = _mapper.Map<UserPost>(post);
            await _userPostRepository.CreatePostAsync(userPostModel);
            
            return _mapper.Map<UserPostReadDto>(userPostModel);
        }

        public async Task<UserPost> UpdatePostAsync(Guid id, UserPostUpdateDto post)
        {
            var userPostModel = await _userPostRepository.GetPostByIdAsync(id);
            if(userPostModel == null)
            {
                return userPostModel;
            }

            _mapper.Map(userPostModel, post);
            await _userPostRepository.UpdatePostAsync(userPostModel);

            return userPostModel;
        }

        public async Task<UserPost> DeletePostAsync(Guid id)
        {
            var userPostModel = await _userPostRepository.GetPostByIdAsync(id);
            if(userPostModel == null)
            {
                return userPostModel;
            }
            
            _userPostRepository.DeletePost(id);

            return userPostModel;
        }
    }
}