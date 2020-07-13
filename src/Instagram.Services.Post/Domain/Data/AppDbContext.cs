using Instagram.Services.Post.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Binder;
using Microsoft.Extensions.Configuration.Json;

namespace Instagram.Services.Post.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseMySql(config.GetConnectionString("DefaultConnection"));
        }

        public DbSet<UserPost> Posts { get; set; }
    }
}