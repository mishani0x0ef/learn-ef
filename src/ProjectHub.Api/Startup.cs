using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using ProjectHub.Data;
using System.IO;

namespace ProjectHub.Api
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
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
            services
                .AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            services
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
                        options.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, doc));
                    }
                })
                .AddSwaggerGenNewtonsoftSupport();

            services.AddDbContext<HubContext>(
                options => options
                    .EnableSensitiveDataLogging()
                    .UseSqlServer(Configuration.GetConnectionString("HubConnection"))
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app
                .UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Project Hub API v1");
                    options.DisplayRequestDuration();
                    options.EnableFilter();
                });
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
