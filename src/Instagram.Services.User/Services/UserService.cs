using System.Threading.Tasks;
using Instagram.Common.Auth;
using Instagram.Common.Exceptions;
using models = Instagram.Services.User.Domain.Models;
using Instagram.Services.User.Domain.Services;
using Instagram.Services.User.Domain.Repositories;
using System.Collections.Generic;
using AutoMapper;
using Instagram.Common.DTOs.User;

namespace Instagram.Services.User.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IEncrypter encrypter, IJwtHandler jwtHandler, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserReadDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();

            return _mapper.Map<IEnumerable<UserReadDto>>(users);
        }

        public async Task<UserReadDto> GetUserByUsernameAsync(string userName)
        {
            var users = await _userRepository.GetUserByUsernameAsync(userName);

            return _mapper.Map<UserReadDto>(users);
        }
    }
}