using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation.AspNetCore;
using Instagram.Services.Post.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Instagram.Services.Post.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddApiVersioning(o => {  
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = false;
            });
            services.AddMvc(opt => { 
                opt.EnableEndpointRouting = false;
                opt.Filters.Add<ValidatorFilter>();
            })
            .AddFluentValidation(mvcConfiguration => mvcConfiguration.RegisterValidatorsFromAssemblyContaining<Startup>())
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddLogging();
            services.AddSwaggerGen(x => {
                x.SwaggerDoc("v1", new OpenApiInfo{Title = "Instagram.Services.Post API", Version = "v1"});

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

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}