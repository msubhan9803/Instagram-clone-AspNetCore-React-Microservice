using System.Collections.Generic;
using System.Threading.Tasks;
using Instagram.Common.DTOs.User;
using model = Instagram.Services.User.Domain.Models;

namespace Instagram.Services.User.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserReadDto>> GetAllUsersAsync();
        Task<UserReadDto> GetUserByUsernameAsync(string userName);
    }
}