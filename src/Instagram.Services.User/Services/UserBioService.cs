using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Instagram.Common.DTOs.User;
using Instagram.Common.Exceptions;
using Instagram.Services.User.Domain.Models;
using Instagram.Services.User.Domain.Repositories;
using Instagram.Services.User.Services;
using Newtonsoft.Json;

namespace Instagram.Services.Bio.Services
{
    public class UserBioService : IUserBioService
    {
        private readonly IUserBioRepository _userBioRepository;
        private readonly IMapper _mapper;

        public UserBioService(IUserBioRepository userBioRepository, IMapper mapper = null)
        {
            _userBioRepository = userBioRepository;
            _mapper = mapper;
        }

        public async Task<UserBioReadDto> GetBioByUserIdAsync(Guid userId)
        {
            if (userId == null)
            {
                throw new InstagramException("id_is_null",
                    $"User Id is required, can't be null.");
            }

            var userBio = await _userBioRepository.GetUserBioAsync(userId);
            
            return _mapper.Map<UserBioReadDto>(userBio);
        }

        public async Task<UserBioReadDto> CreateUserBioAsync(UserBioCreateDto bio)
        {
            var userBioModel = _mapper.Map<UserBio>(bio);
            await _userBioRepository.CreateUserBioAsync(userBioModel);
            
            return _mapper.Map<UserBioReadDto>(userBioModel);
        }

        public async Task<UserBio> UpdateUserBioAsync(Guid id, UserBioUpdateDto bio)
        {
            var userBioModel = await _userBioRepository.GetUserBioAsync(id);

            if(userBioModel == null)
            {
                return userBioModel;
            }

            _mapper.Map(bio, userBioModel);
            await _userBioRepository.UpdateUserBioAsync(userBioModel);

            return userBioModel;
        }
    }
}