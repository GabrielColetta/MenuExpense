using Menu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Menu.Data.Configurations
{
    public class PriceConfiguration : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.HasQueryFilter(conf => !conf.IsDeleted);

            builder.ToTable(nameof(Price).ToUpper())
                .HasKey(conf => conf.Id);

            builder.Property(conf => conf.IncludedDate)
                .IsRequired();

            builder.Property(conf => conf.IsDeleted)
                .IsRequired();

            builder.Property(conf => conf.PriceValue)
                .HasColumnType("decimal(15,6)")
                .IsRequired();

            builder.Property(conf => conf.PricePerGramsOrMilliliters)
                .HasColumnType("decimal(15,6)")
                .IsRequired();

            builder.Property(conf => conf.PricePerkilogramOrLiter)
                .HasColumnType("decimal(15,6)")
                .IsRequired();

            builder.HasOne(conf => conf.Ingredient)
                .WithOne(conf => conf.Price)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
