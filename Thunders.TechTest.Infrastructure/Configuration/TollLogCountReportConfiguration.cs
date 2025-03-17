using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thunders.TechTest.Domain.Models;

namespace Thunders.TechTest.Infrastructure.Configuration
{
    public class TollLogCountReportConfiguration : IEntityTypeConfiguration<TollLogCountReport>
    {
        public void Configure(EntityTypeBuilder<TollLogCountReport> modelBuilder)
        {
            modelBuilder.HasNoKey();
        }
    }
}
