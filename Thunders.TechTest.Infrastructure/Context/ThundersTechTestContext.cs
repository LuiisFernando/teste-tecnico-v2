using Microsoft.EntityFrameworkCore;
using Thunders.TechTest.Domain.Entities;
using Thunders.TechTest.Domain.Models;
using Thunders.TechTest.Infrastructure.Configuration;

namespace Thunders.TechTest.Infrastructure.Context
{
    public class ThundersTechTestContext(DbContextOptions<ThundersTechTestContext> options) : DbContext(options)
    {
        public DbSet<TollLog> TollLogs { get; set; }

        public DbSet<HourlyCityReport> HourlyCityReports { get; set; }

        public DbSet<TopTollPlazasReport> TopTollPlazasReports { get; set; }

        public DbSet<TollLogCountReport> TollLogCountReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new TollLogConfiguration().Configure(modelBuilder.Entity<TollLog>());
            new HourlyCityReportConfiguration().Configure(modelBuilder.Entity<HourlyCityReport>());
            new TollLogCountReportConfiguration().Configure(modelBuilder.Entity<TollLogCountReport>());
            new TopTollPlazasReportConfiguration().Configure(modelBuilder.Entity<TopTollPlazasReport>());
        }
    }
}
