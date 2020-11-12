using System;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Instagram.Services.Post.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;

namespace Instagram.Services.Post.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>();
            // services.AddDbContext<AppDbContext>(opt => {
            //     var builder = new MySqlConnectionStringBuilder();
            //     builder.ConnectionString = configuration.GetConnectionString("DefaultConnection");
            //     builder.UserID = configuration["Uid"];
            //     builder.Password = configuration["Password"];

            //     opt.UseMySql(builder.ConnectionString);
            // }, ServiceLifetime.Transient);
            // services.AddDbContext<AppDbContext>(ServiceLifetime.Transient);
            
            services.AddSingleton(x =>
                new BlobServiceClient(configuration.GetValue<string>("AzureBlobStorageConnectionString")));
        }
    }
}