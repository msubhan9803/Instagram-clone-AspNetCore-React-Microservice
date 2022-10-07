using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Instagram.Common.Auth;
using Instagram.Common.Options;
using Instagram.Common.RabbitMq;
using Instagram.Services.User.Filters;
using Instagram.Services.User.Installers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace Instagram.Services.User
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.InstallServicesInAssmebly(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            
            // if (env.IsDevelopment()) 
            // {
            //     app.UseDeveloperExceptionPage();
                
            //     var builder = new MySqlConnectionStringBuilder();
            //     builder.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
            //     // builder.UserID = Configuration["Uid"];
            //     // builder.Password = Configuration["Pwd"];

            //     Console.WriteLine($"builder.ConnectionString: {builder.ConnectionString}");
            //     Console.WriteLine($"builder.UserID: {builder.UserID}");

            //     DbContextSetting.ConnectionString = builder.ConnectionString;
            // } else {
            //     DbContextSetting.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
            // }
            DbContextSetting.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine($"Configuration GetConnectionString: {DbContextSetting.ConnectionString}");

            var swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseAuthentication();
            app.UseApiVersioning();

            app.UseSwagger(options => options.RouteTemplate = swaggerOptions.JsonRoute );
            app.UseSwaggerUI(opt => opt.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description));

            app.UseMvc();
        }
    }
}