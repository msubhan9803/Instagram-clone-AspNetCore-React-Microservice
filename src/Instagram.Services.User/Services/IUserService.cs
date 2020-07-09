using System.Threading.Tasks;
using Instagram.Common.Auth;

namespace Instagram.Services.User.Services
{
    public interface IUserService
    {
        Task RegisterAsync(string email, string password, string name);
        Task<JsonWebToken> LoginAsync(string email, string password);  
    }
}