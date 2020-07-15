using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Instagram.Common.DTOs.User;
using Instagram.Services.User.Domain.Models;

namespace Instagram.Services.User.Services
{
    public interface IUserBioService
    {
        Task<UserBioReadDto> GetBioByUserIdAsync(Guid userId);
        Task<(Guid, UserBioReadDto)> CreateUserBioAsync(Guid userId, UserBioCreateDto bio);
        Task<UserBio> UpdateUserBioAsync(Guid id, UserBioUpdateDto bio); 
    }
}