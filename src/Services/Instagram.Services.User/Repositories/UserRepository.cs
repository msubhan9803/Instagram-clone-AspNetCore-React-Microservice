using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Instagram.Services.User.Data;
using Instagram.Services.User.Domain.Models;
using Instagram.Services.User.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using model = Instagram.Services.User.Domain.Models;

namespace Instagram.Services.User.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<model.User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<model.User> GetUserByUsernameAsync(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(p => p.UserName == userName);
        }

        public async Task CreateUserRelationAsync(UserRelation userRelation)
        {
            await _context.UserRelations.AddAsync(userRelation);
            await _context.SaveChangesAsync();
        }

        public async Task<UserRelation> CheckRelationshipAsync(Guid userId, Guid followedUserId)
        {
            return await _context.UserRelations.FirstOrDefaultAsync(x => x.UserId == followedUserId && x.FollowerId == userId);
        }

        public void DeleteUserRelation(Guid userId, Guid followedUserId)
        {
            var userRelation = _context.UserRelations.FirstOrDefault(x => x.UserId == followedUserId && x.FollowerId == userId);
            _context.UserRelations.Remove(userRelation);
            _context.SaveChanges();
        }
    }
}