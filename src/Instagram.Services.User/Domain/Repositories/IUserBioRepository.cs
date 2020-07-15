using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Instagram.Services.User.Domain.Models;

namespace Instagram.Services.User.Domain.Repositories
{
    public interface IUserBioRepository
    {
        Task<UserBio> GetUserBioByIdAsync(Guid id);
        Task<UserBio> GetUserBioByUserIdAsync(Guid userId);
        Task CreateUserBioAsync(UserBio Bio);
        Task UpdateUserBioAsync();
    }
}