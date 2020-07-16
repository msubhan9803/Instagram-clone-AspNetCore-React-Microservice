using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Instagram.Common.Exceptions;
using Instagram.Services.Post.Data;
using Instagram.Services.Post.Domain.Models;
using Instagram.Services.Post.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Services.Post.Repositories
{
    public class UserPostRepository : IUserPostRepository
    {
        private readonly AppDbContext _context;

        public UserPostRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserPost>> GetAllPostsAsync()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<UserPost> GetPostByIdAsync(Guid id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task<IEnumerable<UserPost>> GetPostByUserIdAsync(Guid userId)
        {
            return await _context.Posts.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task CreatePostAsync(UserPost post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePostAsync(UserPost post)
        {
            await _context.SaveChangesAsync();
        }

        public void DeletePost(Guid id)
        {
            var userPost = _context.Posts.Find(id);
            _context.Posts.Remove(userPost);
            _context.SaveChanges();
        }
    }
}