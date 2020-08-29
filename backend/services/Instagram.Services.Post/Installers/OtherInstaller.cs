using Instagram.Common.Auth;
using Instagram.Common.RabbitMq;
using Instagram.Services.Post.Domain.Repositories;
using Instagram.Services.Post.Repositories;
// using Instagram.Services.Post.Repositories;
using Instagram.Services.Post.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Instagram.Services.Post.Installers
{
    public class OtherInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddJwt(configuration);
            services.AddRabbitMq(configuration);
            services.AddScoped<IUserPostService, UserPostService>();
            services.AddScoped<IUserPostRepository, UserPostRepository>();
            services.AddScoped<IImageBlobService, ImageBlobService>();
            services.AddScoped<IVideoBlobService, VideoBlobService>();
            services.AddScoped<IPostFileService, PostFileService>();
            services.AddScoped<IFileOptimizationService, FileOptimizationService>();
            services.AddScoped<IPostFileRepository, PostFileRepository>();
        }
    }
}