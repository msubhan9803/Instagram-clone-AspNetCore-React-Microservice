using Instagram.Common.Options;
using Instagram.Services.Post.Installers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;

namespace Instagram.Services.Post
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
            //     builder.UserID = Configuration["Uid"];
            //     builder.Password = Configuration["Pwd"];

            //     DbContextSetting.ConnectionString = builder.ConnectionString;
            // } else {
            //     DbContextSetting.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
            // }
            DbContextSetting.ConnectionString = Configuration.GetConnectionString("DefaultConnection");

            var swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseApiVersioning();

            app.UseSwagger(options => options.RouteTemplate = swaggerOptions.JsonRoute);
            app.UseSwaggerUI(opt => opt.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description));

            app.UseMvc();

        }
    }
}
