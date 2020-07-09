using Instagram.Common.Auth;
using Instagram.Common.RabbitMq;
using Instagram.Services.User.Domain.Repositories;
using Instagram.Services.User.Domain.Services;
using Instagram.Services.User.Repositories;
using Instagram.Services.User.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Instagram.Services.User.Installers
{
    public class OtherInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddJwt(configuration);
            services.AddRabbitMq(configuration);
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<IEncrypter, Encrypter>();
        }
    }
}