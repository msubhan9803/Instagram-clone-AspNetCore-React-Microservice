using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Instagram.Common.Exceptions;
using Instagram.Services.User.Data;
using Instagram.Services.User.Domain.Models;
using Instagram.Services.User.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Services.User.Repositories
{
    public class UserBioRepository : IUserBioRepository
    {
        private readonly AppDbContext _context;

        public UserBioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserBio> GetUserBioByIdAsync(Guid id)
        {
            return await _context.UserBios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserBio> GetUserBioByUserIdAsync(Guid userId)
        {
            return await _context.UserBios.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task CreateUserBioAsync(UserBio Bio)
        {
            await _context.UserBios.AddAsync(Bio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserBioAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}