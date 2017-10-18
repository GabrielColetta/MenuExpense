using Menu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Menu.Data.Configurations
{
    public class ProductionInputConfiguration : IEntityTypeConfiguration<ProductionInput>
    {
        public void Configure(EntityTypeBuilder<ProductionInput> builder)
        {
            builder.HasQueryFilter(conf => !conf.IsDeleted);

            builder.ToTable(nameof(ProductionInput).ToUpper())
                .HasKey(conf => conf.Id);

            builder.Property(conf => conf.IncludedDate)
                .IsRequired();

            builder.Property(conf => conf.IsDeleted)
                .IsRequired();

            builder.Property(conf => conf.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(conf => conf.TotalWeight)
                .WithOne(conf => conf.ProductionInput)
                .HasForeignKey<ProductionInput>(conf => conf.TotalWeightId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasMany(conf => conf.Consolidations)
                .WithOne(conf => conf.ProductionInput)
                .HasForeignKey(conf => conf.ProductInputId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
