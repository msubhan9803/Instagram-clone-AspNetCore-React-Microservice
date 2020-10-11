using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Instagram.Common.DTOs.User;
using Instagram.Services.User.Domain.Models;
using model = Instagram.Services.User.Domain.Models;

namespace Instagram.Services.User.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserReadDto>> GetAllUsersAsync();
        Task<UserReadDto> GetUserByUsernameAsync(string userName);
        Task<UserRelationReadDto> CreateUserRelationAsync(UserRelationCreateDto userRelation);
        Task<UserRelationReadDto> CheckRelationshipAsync(Guid userId, Guid followedUserId);
        Task<UserRelation> DeleteUserRelation(Guid userId, Guid followedUserId);
    }
}