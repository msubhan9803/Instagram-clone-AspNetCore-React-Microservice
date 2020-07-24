using System;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Instagram.Services.Post.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Instagram.Services.Post.Installers
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