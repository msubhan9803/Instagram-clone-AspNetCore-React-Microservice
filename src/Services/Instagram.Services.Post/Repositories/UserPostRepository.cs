using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Instagram.Common.DTOs.Post;
using Instagram.Common.Exceptions;
using Instagram.Services.Post.Data;
using Instagram.Services.Post.Domain.Models;
using Instagram.Services.Post.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Instagram.Services.Post.Repositories
{
    public class UserPostRepository : IUserPostRepository
    {
        private readonly AppDbContext _context;

        public UserPostRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserPostReadDto>> GetAllPostsAsync()
        {
            var result = await (
                        from post in _context.Set<UserPost>()
                        join postFile in _context.Set<PostFile>()
                        on post.FileId equals postFile.Id
                        orderby post.CreatedAt descending
                        select (new UserPostReadDto
                        (
                            post.Id,
                            post.UserId,
                            post.UserName,
                            post.Caption,
                            post.FileId,
                            postFile.Type,
                            post.CreatedAt
                        ))
                        ).ToListAsync();

            return result;
        }

        public async Task<UserPost> GetPostModelByIdAsync(Guid id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task<UserPostReadDto> GetPostByIdAsync(Guid id)
        {
            var result = await (
                            from post in _context.Set<UserPost>()
                            join postFile in _context.Set<PostFile>()
                            on post.FileId equals postFile.Id
                            where post.Id == id
                            select (new UserPostReadDto
                            (
                                post.Id,
                                post.UserId,
                                post.UserName,
                                post.Caption,
                                post.FileId,
                                postFile.Type,
                                post.CreatedAt
                            ))
                        ).FirstOrDefaultAsync();

            return result;
        }

        public async Task<IEnumerable<UserPostReadDto>> GetPostByUserIdAsync(Guid userId)
        {
            var result = await (
                        from post in _context.Set<UserPost>()
                        join postFile in _context.Set<PostFile>()
                        on post.FileId equals postFile.Id
                        where post.UserId == userId
                        orderby post.CreatedAt descending
                        select (new UserPostReadDto
                        (
                            post.Id,
                            post.UserId,
                            post.UserName,
                            post.Caption,
                            post.FileId,
                            postFile.Type,
                            post.CreatedAt
                        ))
                        ).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<UserPostReadDto>> GetUserLatestPostsAsync(Guid userId, DateTime lastModified)
        {
            using (var c = new AppDbContext())
            {
                Console.WriteLine($"UserRepository for User: {userId}");
                var result = await (
                        from post in c.Set<UserPost>()
                        join postFile in c.Set<PostFile>()
                        on post.FileId equals postFile.Id
                        where post.UserId == userId
                        && post.CreatedAt > lastModified
                        orderby post.CreatedAt descending
                        select (new UserPostReadDto
                        (
                            post.Id,
                            post.UserId,
                            post.UserName,
                            post.Caption,
                            post.FileId,
                            postFile.Type,
                            post.CreatedAt
                        ))
                        ).ToListAsync();

                return result;
            }
        }

        public async Task CreatePostAsync(UserPost post, PostFile postFileModel)
        {
            await _context.Posts.AddAsync(post);
            await _context.PostFiles.AddAsync(postFileModel);
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