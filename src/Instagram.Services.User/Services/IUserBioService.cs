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
        Task<UserBioReadDto> CreateBioAsync(UserBioCreateDto bio);
        Task<UserBio> UpdateBioAsync(Guid id, UserBioUpdateDto bio); 
    }
}