using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ProjectHub.Api.Config
{
    internal static class Cors
    {
        private const string DevCorsPolicy = "devCorsPolicy";

        public static IServiceCollection AddPreConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                    DevCorsPolicy,
                    builder =>
                    {
                        builder
                            .WithOrigins(
                                "http://localhost:4200"
                            );
                    });
            });

            return services;
        }

        public static IApplicationBuilder UsePreConfiguredCors(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors(DevCorsPolicy);
            }

            return app;
        }
    }
}
