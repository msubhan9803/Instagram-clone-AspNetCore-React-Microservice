using System.Threading.Tasks;
using Instagram.Common.Auth;
using Instagram.Common.Exceptions;
using models = Instagram.Services.User.Domain.Models;
using Instagram.Services.User.Domain.Services;
using Instagram.Services.User.Domain.Repositories;
using System.Collections.Generic;
using RawRabbit;
using AutoMapper;
using Instagram.Common.Events;

namespace Instagram.Services.User.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEncrypter _encrypter;
        private readonly IJwtHandler _jwtHandler;
        private readonly IBusClient _busClient;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, IEncrypter encrypter, IJwtHandler jwtHandler, IBusClient busClient, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _encrypter = encrypter;
            _jwtHandler = jwtHandler;
            _busClient = busClient;
            _mapper = mapper;
        }

        public async Task<object> LoginAsync(string email, string password)
        {
            var user = await _accountRepository.GetAsync(email);
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

            return new {
                token = _jwtHandler.Create(user.Id),
                user = new {
                    userId = user.Id,
                    userName = user.UserName,
                    email = email
                } 
            };
        }

        public async Task RegisterAsync(string userName, string email, string password)
        {
            var user = await _accountRepository.GetAsync(email);
            if (user != null)
            {
                throw new InstagramException("email_in_use",
                    $"Email: '{email}' is already in use.");
            }
            user = new models.User(userName, email);
            user.SetPassword(password, _encrypter);
            await _accountRepository.AddAsync(user);

            await _busClient.PublishAsync(new UserCreated(user.Id));
        }
    }
}