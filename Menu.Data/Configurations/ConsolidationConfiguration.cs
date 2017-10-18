using Menu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Menu.Data.Configurations
{
    public class ConsolidationConfiguration : IEntityTypeConfiguration<Consolidation>
    {
        public void Configure(EntityTypeBuilder<Consolidation> builder)
        {
            builder.HasQueryFilter(conf => !conf.IsDeleted);

            builder.ToTable(nameof(Consolidation).ToUpper())
                .HasKey(conf => conf.Id);

            builder.Property(conf => conf.IncludedDate)
                .IsRequired();

            builder.Property(conf => conf.IsDeleted)
                .IsRequired();

            builder.Property(conf => conf.Observations)
                .HasMaxLength(100);

            builder.Property(conf => conf.UnitOfVolume)
                .IsRequired();

            builder.HasOne(conf => conf.Cost)
                .WithOne(conf => conf.Consolidation)
                .HasForeignKey<Consolidation>(conf => conf.CostId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(conf => conf.TotalWeight)
                .WithOne(conf => conf.Consolidation)
                .HasForeignKey<Consolidation>(conf => conf.TotalWeightId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
