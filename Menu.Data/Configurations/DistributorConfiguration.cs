using Menu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Menu.Data.Configurations
{
    public class DistributorConfiguration : IEntityTypeConfiguration<Distributor>
    {
        public void Configure(EntityTypeBuilder<Distributor> builder)
        {
            builder.HasQueryFilter(conf => !conf.IsDeleted);

            builder.ToTable(nameof(Distributor).ToUpper())
                .HasKey(conf => conf.Id);

            builder.Property(conf => conf.IncludedDate)
                .IsRequired();

            builder.Property(conf => conf.IsDeleted)
                .IsRequired();

            builder.Property(conf => conf.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(conf => conf.Cnpj)
                .HasMaxLength(18);

            builder.Property(conf => conf.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(conf => conf.Adress)
                .HasMaxLength(50);

            builder.Property(conf => conf.Telephone)
                .HasMaxLength(20);

            builder.HasMany(conf => conf.Ingredients)
                .WithOne(conf => conf.Distributor)
                .HasForeignKey(conf => conf.IngredientId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
