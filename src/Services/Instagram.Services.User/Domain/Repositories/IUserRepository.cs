using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Instagram.Services.User.Domain.Models;
using model = Instagram.Services.User.Domain.Models;

namespace Instagram.Services.User.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<model.User>> GetAllUsersAsync();
        Task<model.User> GetUserByUsernameAsync(string userName);
        Task CreateUserRelationAsync(UserRelation userRelation);
        Task<UserRelation> CheckRelationshipAsync(Guid userId, Guid followedUserId);
        void DeleteUserRelation(Guid userId, Guid followedUserId);
    }
}