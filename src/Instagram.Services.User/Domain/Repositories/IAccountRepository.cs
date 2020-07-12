using System;
using System.Threading.Tasks;

namespace Instagram.Services.User.Domain.Repositories
{
    public interface IAccountRepository
    {
        Task<Models.User> GetAsync(Guid id);
        Task<Models.User> GetAsync(string email);
        Task AddAsync(Models.User user);
    }
}