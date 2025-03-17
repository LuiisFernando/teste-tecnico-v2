using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thunders.TechTest.Domain.Models;

namespace Thunders.TechTest.Infrastructure.Configuration
{
    public class TopTollPlazasReportConfiguration : IEntityTypeConfiguration<TopTollPlazasReport>
    {
        public void Configure(EntityTypeBuilder<TopTollPlazasReport> modelBuilder)
        {
            modelBuilder.HasNoKey();
            modelBuilder.Property(t => t.TotalAmount).HasPrecision(18, 2);
        }
    }
}
