using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thunders.TechTest.Domain.Models;

namespace Thunders.TechTest.Infrastructure.Configuration
{
    public class HourlyCityReportConfiguration : IEntityTypeConfiguration<HourlyCityReport>
    {
        public void Configure(EntityTypeBuilder<HourlyCityReport> modelBuilder)
        {
            modelBuilder.HasNoKey();
            modelBuilder.Property(t => t.TotalAmount).HasPrecision(18, 2);
        }
    }
}
