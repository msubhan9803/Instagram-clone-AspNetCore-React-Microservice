using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration.Binder;
using Microsoft.Extensions.Configuration.Json;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Hosting;
using Instagram.Common.Options;

namespace Instagram.Services.User.Data
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

        public DbSet<Domain.Models.User> Users { get; set; }
        public DbSet<Domain.Models.UserBio> UserBios { get; set; }
        public DbSet<Domain.Models.UserRelation> UserRelations { get; set; }
    }
}