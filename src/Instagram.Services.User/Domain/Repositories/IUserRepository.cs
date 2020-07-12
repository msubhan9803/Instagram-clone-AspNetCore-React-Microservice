using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using model = Instagram.Services.User.Domain.Models;

namespace Instagram.Services.User.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<model.User>> GetAllUsersAsync();
        Task<model.User> GetUserByUsernameAsync(string userName);
    }
}