using Menu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Menu.Data.Configurations
{
    public class CostConfiguration : IEntityTypeConfiguration<Cost>
    {
        public void Configure(EntityTypeBuilder<Cost> builder)
        {
            builder.HasQueryFilter(conf => !conf.IsDeleted);

            builder.ToTable(nameof(Cost).ToUpper())
                .HasKey(conf => conf.Id);

            builder.Property(conf => conf.IncludedDate)
                .IsRequired();

            builder.Property(conf => conf.IsDeleted)
                .IsRequired();

            builder.Property(conf => conf.Total)
                .HasColumnType("decimal(15,6)")
                .IsRequired();

            builder.Property(conf => conf.PerUnit)
                .HasColumnType("decimal(15,6)")
                .IsRequired();

            builder.Property(conf => conf.Magnitude)
                .IsRequired();

            builder.Property(conf => conf.MagnitudeType)
                .IsRequired();

            builder.HasOne(conf => conf.Consolidation)
                .WithOne(conf => conf.Cost)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
