using Instagram.Services.Post.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration.Binder;
using Microsoft.Extensions.Configuration.Json;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Hosting;
using Instagram.Common.Options;

namespace Instagram.Services.Post.Data
{
    public class AppDbContext : DbContext
    {
        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _env;

        public AppDbContext() : base()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration,
            IWebHostEnvironment env) : base(options)
        {
            Configuration = configuration;
            _env = env;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(DbContextSetting.ConnectionString);
            }
        }

        public DbSet<UserPost> Posts { get; set; }
        public DbSet<PostFile> PostFiles { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
    }
}