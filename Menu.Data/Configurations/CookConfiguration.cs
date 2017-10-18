using Menu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Menu.Data.Configurations
{
    public class CookConfiguration : IEntityTypeConfiguration<Cook>
    {
        public void Configure(EntityTypeBuilder<Cook> builder)
        {
            builder.HasQueryFilter(conf => !conf.IsDeleted);

            builder.ToTable(nameof(Cook).ToUpper())
                .HasKey(conf => conf.Id);

            builder.Property(conf => conf.IncludedDate)
                .IsRequired();

            builder.Property(conf => conf.IsDeleted)
                .IsRequired();

            builder.Property(conf => conf.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(conf => conf.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(conf => conf.Cpf)
                .HasMaxLength(16)
                .IsRequired();

            builder.HasMany(conf => conf.Recipes)
                .WithOne(conf => conf.Cook)
                .HasForeignKey(conf => conf.CookId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
