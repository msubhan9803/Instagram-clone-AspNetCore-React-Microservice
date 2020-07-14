using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Instagram.Services.User.Domain.Models;

namespace Instagram.Services.User.Domain.Repositories
{
    public interface IUserBioRepository
    {
        Task<UserBio> GetUserBioAsync(Guid userId);
        Task CreateUserBioAsync(UserBio Bio);
        Task UpdateUserBioAsync(UserBio Bio);
    }
}