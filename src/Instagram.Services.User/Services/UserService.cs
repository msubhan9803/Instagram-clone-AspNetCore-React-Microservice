using System.Threading.Tasks;
using Instagram.Common.Auth;
using Instagram.Common.Exceptions;
using models = Instagram.Services.User.Domain.Models;
using Instagram.Services.User.Domain.Services;
using Instagram.Services.User.Domain.Repositories;

namespace Instagram.Services.User.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;
        private readonly IJwtHandler _jwtHandler;

        public UserService(IUserRepository userRepository, IEncrypter encrypter, IJwtHandler jwtHandler)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
            _jwtHandler = jwtHandler;
        }

        public async Task<JsonWebToken> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user == null)
            {
                throw new InstagramException("invalid_credentials",
                    $"Invalid credentials.");
            }
            if (!user.ValidatePassword(password, _encrypter))
            {
                throw new InstagramException("invalid_credentials",
                    $"Invalid credentials.");
            }

            return _jwtHandler.Create(user.Id);
        }

        public async Task RegisterAsync(string userName, string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user != null)
            {
                throw new InstagramException("email_in_use",
                    $"Email: '{email}' is already in use.");
            }
            user = new models.User(userName, email);
            user.SetPassword(password, _encrypter);
            await _userRepository.AddAsync(user);
        }
    }
}