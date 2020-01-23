using Microsoft.EntityFrameworkCore;
using ProjectHub.Domain.Environment;

namespace ProjectHub.Data
{
    public class HubContext : DbContext
    {
        public DbSet<Environment> Environments { get; set; }
        public DbSet<SiteLink> SiteLinks { get; set; }

        public HubContext(DbContextOptions<HubContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO: add relations logic here if needed. MR
            base.OnModelCreating(modelBuilder);
        }
    }
}
