using Instagram.Common.Auth;
using Instagram.Common.RabbitMq;
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
        }
    }
}