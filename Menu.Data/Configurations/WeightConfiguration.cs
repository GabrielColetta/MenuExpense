using Menu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Menu.Data.Configurations
{
    public class WeightConfiguration : IEntityTypeConfiguration<Weight>
    {
        public void Configure(EntityTypeBuilder<Weight> builder)
        {
            builder.HasQueryFilter(conf => !conf.IsDeleted);

            builder.HasKey(x => x.Id);

            builder.Property(conf => conf.IncludedDate)
                .IsRequired();

            builder.Property(conf => conf.IsDeleted)
                .IsRequired();

            builder.Property(conf => conf.Unit)
                .HasColumnType("decimal(15,2)")
                .IsRequired();

            builder.Property(conf => conf.UnitOfMeasurement)
                .IsRequired();

            builder.Property(conf => conf.UnitOfMeasurementType)
                .IsRequired();

            builder.HasOne(conf => conf.Ingredient)
                .WithOne(conf => conf.Weight)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(conf => conf.Consolidation)
                .WithOne(conf => conf.TotalWeight)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(conf => conf.ProductionInput)
                .WithOne(conf => conf.TotalWeight)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(conf => conf.Recipe)
                .WithOne(conf => conf.TotalWeight)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
