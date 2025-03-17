using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thunders.TechTest.Domain.Entities;

namespace Thunders.TechTest.Infrastructure.Configuration
{
    public class TollLogConfiguration : IEntityTypeConfiguration<TollLog>
    {
        public void Configure(EntityTypeBuilder<TollLog> modelBuilder)
        {
            modelBuilder.HasKey(t => t.Id);
            modelBuilder.Property(t => t.Id).ValueGeneratedOnAdd();
            modelBuilder.Property(t => t.AmountPaid).HasPrecision(18, 2);
        }
    }
}
