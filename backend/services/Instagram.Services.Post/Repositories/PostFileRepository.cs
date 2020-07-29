using System;
using System.Threading.Tasks;
using Instagram.Services.Post.Data;
using Instagram.Services.Post.Domain.Repositories;

namespace Instagram.Services.Post.Repositories
{
    public class PostFileRepository : IPostFileRepository
    {
        public AppDbContext _context;
        public PostFileRepository(AppDbContext context)
        {
            _context = context;

        }

        public async Task<string> GetPostFileNameByIdAsync(Guid postFileId)
        {
            var postFile = await _context.PostFiles.FindAsync(postFileId);
            return postFile.Name;
        }
    }
}