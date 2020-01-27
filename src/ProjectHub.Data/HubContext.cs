using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectHub.Domain.Environment;
using System.Collections.Generic;

namespace ProjectHub.Data
{
    public class HubContext : DbContext
    {
        public DbSet<Environment> Environments { get; set; }
        public DbSet<SiteLink> SiteLinks { get; set; }

        private static readonly ILoggerFactory LogFactory = LoggerFactory.Create(
            builder => builder
                .AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)
                .AddConsole()
                .AddDebug()
            );

        public HubContext(DbContextOptions<HubContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LogFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<SiteLinkHashTag>()
                .HasKey(sh => new { sh.SiteLinkId, sh.HashTagId });

            // Only for testing purposes. MR
            SeedDatabase(modelBuilder);
        }

        private void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Environment>()
                .HasData(new List<Environment>
                {
                    new Environment{ Id = 1, Name = "Develop", Description = "For development purposes." },
                    new Environment{ Id = 2, Name = "Test", Description = "For testing and quality assurance." },
                });
        }
    }
}
