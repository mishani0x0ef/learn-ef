using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace ProjectHub.Api.Config
{
    internal static class Swagger
    {
        public static IServiceCollection AddPreConfiguredSwagger(this IServiceCollection services)
        {
            return services
                .AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Project Hub", Version = "v1" });

                    var docs = new[] {
                        "ProjectHub.Api.xml",
                        "ProjectHub.Data.xml",
                        "ProjectHub.Domain.xml",
                    };
                    foreach (var doc in docs)
                    {
                        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, doc));
                    }
                })
                .AddSwaggerGenNewtonsoftSupport();
        }

        public static IApplicationBuilder UsePreConfiguredSwaggerWithUI(this IApplicationBuilder app)
        {
            return app
                .UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Project Hub API v1");
                    options.DisplayRequestDuration();
                    options.EnableFilter();
                });
        }
    }
}
