using Instagram.Common.Events;
using Instagram.Services.Newsfeed.Handlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Instagram.Common.RabbitMq;
using Instagram.Common.Mongo;
using Instagram.Services.Newsfeed.Domain.Repositories;
using Instagram.Services.Newsfeed.Repositories;
using Instagram.Services.Newsfeed.Services;
using Hangfire;
using Hangfire.MemoryStorage;
using Instagram.Services.Newsfeed.Jobs;

namespace Instagram.Services.Newsfeed.Installers
{
    public class OtherInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddRabbitMq(configuration);
            services.AddMongoDB(configuration);
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddTransient<INewsfeedRepository, NewsfeedRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<INewsfeedService, NewsfeedService>();
            services.AddScoped<IEventHandler<UserCreated>, UserCreatedHandler>();
            services.AddScoped<IEventHandler<UserFollowed>, UserFollowedHandler>();
            services.AddTransient<IEventHandler<UsersNewPostsFetched>, UsersNewPostsFetchedHandler>();
            // services.AddScoped<IDatabaseSeeder, CustomMongoSeeder>();
            services.AddHangfire(config => 
                config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseDefaultTypeSerializer()
                .UseMemoryStorage());

            services.AddHangfireServer();
            services.AddScoped<INewsfeedUpdateJob, NewsfeedUpdateJob>();
        }
    }
}