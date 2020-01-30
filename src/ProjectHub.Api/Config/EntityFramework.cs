using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectHub.Data;

namespace ProjectHub.Api.Config
{
    internal static class EntityFramework
    {
        public static IServiceCollection AddPreConfiguredDbContext(this IServiceCollection services, IConfiguration config)
        {
            return services.AddDbContext<HubContext>(
                options => options
                    .EnableSensitiveDataLogging()
                    .UseSqlServer(config.GetConnectionString("HubConnection"))
            );
        }
    }
}
