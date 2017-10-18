using Menu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Menu.Data.Configurations
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasQueryFilter(conf => !conf.IsDeleted);

            builder.ToTable(nameof(Ingredient).ToUpper())
                .HasKey(conf => conf.Id);

            builder.Property(conf => conf.IncludedDate)
                .IsRequired();

            builder.Property(conf => conf.IsDeleted)
                .IsRequired();

            builder.Property(conf => conf.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(conf => conf.LocalStorageCount)
                .IsRequired();

            builder.Property(conf => conf.Brand)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasOne(conf => conf.Weight)
                .WithOne(conf => conf.Ingredient)
                .HasForeignKey<Ingredient>(conf => conf.WeightId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(conf => conf.Consolidation)
                .WithMany(conf => conf.Ingredients)
                .HasForeignKey(conf => conf.ConsolidationId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(conf => conf.Price)
                .WithOne(conf => conf.Ingredient)
                .HasForeignKey<Ingredient>(conf => conf.PriceId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasMany(conf => conf.Distributors)
                .WithOne(conf => conf.Ingredient)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
