using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Instagram.Services.User.Data;
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
    }
}