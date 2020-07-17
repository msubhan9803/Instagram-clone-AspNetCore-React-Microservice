using System.Collections.Generic;
using System.Threading.Tasks;
using Instagram.Common.Auth;
using model = Instagram.Services.User.Domain.Models;

namespace Instagram.Services.User.Services
{
    public interface IAccountService
    {
        Task RegisterAsync(string email, string password, string name);
        Task<JsonWebToken> LoginAsync(string email, string password);
    }
}