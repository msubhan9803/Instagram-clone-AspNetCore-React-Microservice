using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Binder;
using Microsoft.Extensions.Configuration.Json;
using MySql.Data.MySqlClient;

namespace Instagram.Services.User.Data
{
    public class AppDbContext : DbContext
    {
        public IConfiguration Configuration { get; }
        
        public AppDbContext() : base()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new MySqlConnectionStringBuilder();
            builder.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
            builder.UserID = Configuration["Uid"];
            builder.Password = Configuration["Password"];

            optionsBuilder.UseMySql(builder.ConnectionString);
        }

        public DbSet<Domain.Models.User> Users { get; set; }
        public DbSet<Domain.Models.UserBio> UserBios { get; set; }
    }
}