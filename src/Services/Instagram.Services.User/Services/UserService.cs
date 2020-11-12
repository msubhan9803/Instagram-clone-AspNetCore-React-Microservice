using System.Threading.Tasks;
using Instagram.Common.Auth;
using Instagram.Common.Exceptions;
using models = Instagram.Services.User.Domain.Models;
using Instagram.Services.User.Domain.Services;
using Instagram.Services.User.Domain.Repositories;
using System.Collections.Generic;
using AutoMapper;
using Instagram.Common.DTOs.User;
using System;
using Instagram.Services.User.Domain.Models;
using RawRabbit;
using Instagram.Common.Events;

namespace Instagram.Services.User.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IBusClient _busClient;

        public UserService(IUserRepository userRepository, IEncrypter encrypter, IJwtHandler jwtHandler, IMapper mapper, IBusClient busClient)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _busClient = busClient;
        }

        public async Task<IEnumerable<UserReadDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();

            return _mapper.Map<IEnumerable<UserReadDto>>(users);
        }

        public async Task<UserReadDto> GetUserByUsernameAsync(string userName)
        {
            if (userName == null)
            {
                throw new InstagramException("username_is_null",
                    $"Username is required, can't be null.");
            }

            var users = await _userRepository.GetUserByUsernameAsync(userName);

            return _mapper.Map<UserReadDto>(users);
        }

        public async Task<UserRelationReadDto> CreateUserRelationAsync(UserRelationCreateDto userRelation)
        {
            if (userRelation == null)
            {
                throw new InstagramException("parameters_are_null",
                    $"UserId and FollowedUserId is required, can't be null.");
            }

            var userRelationModelCheck = await _userRepository.CheckRelationshipAsync(userRelation.UserId, userRelation.FollowedUserId);

            if (userRelationModelCheck == null)
            {
                var userRelationModel = _mapper.Map<UserRelation>(userRelation);
                await _userRepository.CreateUserRelationAsync(userRelationModel);

                var userRelationDto = _mapper.Map<UserRelationReadDto>(userRelationModel);
                userRelationDto.Relation = 1;
                
                await _busClient.PublishAsync(new UserFollowed(userRelation.UserId, userRelation.FollowedUserId));

                return userRelationDto;
            }
            else
            {
                var userRelationDto = _mapper.Map<UserRelationReadDto>(userRelationModelCheck);
                userRelationDto.Relation = 1;

                return userRelationDto;
            }
        }

        public async Task<UserRelationReadDto> CheckRelationshipAsync(Guid userId, Guid followedUserId)
        {
            if (userId == null && followedUserId == null)
            {
                throw new InstagramException("parameters_are_null",
                    $"UserId and FollowedUserId is required, can't be null.");
            }

            var userRelation = await _userRepository.CheckRelationshipAsync(userId, followedUserId);
            if (userRelation != null)
            {
                var userRelationModel = _mapper.Map<UserRelationReadDto>(userRelation);
                userRelationModel.Relation = 1;

                return userRelationModel;
            }

            return null;
        }

        public async Task<UserRelation> DeleteUserRelation(Guid userId, Guid followedUserId)
        {
            var userRelationModel = await _userRepository.CheckRelationshipAsync(userId, followedUserId);

            if (userRelationModel == null)
            {
                return userRelationModel;
            }

            _userRepository.DeleteUserRelation(userId, followedUserId);

            return userRelationModel;
        }
    }
}