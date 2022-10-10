using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Instagram.Services.Newsfeed.Installers;
using Instagram.Common.Mongo;
using Hangfire;
using Instagram.Services.Newsfeed.Jobs;
using Instagram.Services.Newsfeed.Hubs;
using Instagram.Common.Options;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.HttpOverrides;

namespace Instagram.Services.Newsfeed
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.InstallServicesInAssmebly(Configuration);
            services.AddControllers();
            services.AddSignalR(options =>
            {
                options.EnableDetailedErrors = true;
            });

            services.AddHangfireServer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IRecurringJobManager recurringJobManager,
            IServiceProvider serviceProvider)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            
            app.UseAuthentication();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseRouting();
            app.UseAuthorization();
            app.UseApiVersioning();

            app.UseHangfireDashboard();
            app.UseHangfireServer();
            // app.UseHangfireDashboard("/hangfire", new DashboardOptions()  
            // {  
            //     AppPath = null,  
            //     DashboardTitle = "Hangfire Dashboard",  
            //     Authorization = new {
            //         User = Configuration.GetSection("HangfireCredentials:UserName").Value,  
            //         Pass = Configuration.GetSection("HangfireCredentials:Password").Value  
            //     }
            // });
            
            recurringJobManager.AddOrUpdate(
                "Update.Newsfeed",
                () => serviceProvider.GetService<INewsfeedUpdateJob>().UpdateNewsfeedAsync(),
                // "*/10 * * * * *"
                "* * * * * *"
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<NewsfeedHub>("/hubs/newsfeed");
            });

            app.UseSwagger(options => options.RouteTemplate = swaggerOptions.JsonRoute);
            app.UseSwaggerUI(opt => opt.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description));

            app.UseMvc();

            // app.ApplicationServices.GetService<IDatabaseInitializer>().InitializeAsync();
        }
    }
}
