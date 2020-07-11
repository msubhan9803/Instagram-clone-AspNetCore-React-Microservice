using System.Collections.Generic;
using FluentValidation.AspNetCore;
using Instagram.Services.User.Filters;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Instagram.Services.User.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddMvc(opt => { 
                opt.EnableEndpointRouting = false;
                opt.Filters.Add<ValidatorFilter>();
            })
            .AddFluentValidation(mvcConfiguration => mvcConfiguration.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddLogging();
            services.AddSwaggerGen(x => {
                x.SwaggerDoc("v1", new OpenApiInfo{Title = "Instagram.Services.User API", Version = "v1"});

                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {new OpenApiSecurityScheme{Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }}, new List<string>()} 
                });
            });
            services.AddApiVersioning(o => {
                o.ApiVersionReader = new MediaTypeApiVersionReader();
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.ApiVersionSelector = new CurrentImplementationApiVersionSelector(o);
            });
        }
    }
}