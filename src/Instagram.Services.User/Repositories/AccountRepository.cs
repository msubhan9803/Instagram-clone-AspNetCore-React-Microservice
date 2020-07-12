using System;
using System.Linq;
using System.Threading.Tasks;
using Instagram.Services.User.Data;
using Instagram.Services.User.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Services.User.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;

        public AccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Domain.Models.User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<Domain.Models.User> GetAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<Domain.Models.User> GetAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}