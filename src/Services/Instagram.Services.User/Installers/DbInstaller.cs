using System;
using Azure.Storage.Blobs;
using Instagram.Services.User.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Instagram.Services.User.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>();
            services.AddSingleton(x =>
                new BlobServiceClient(configuration.GetValue<string>("AzureBlobStorageConnectionString")));
        }
    }
}