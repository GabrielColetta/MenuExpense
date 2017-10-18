using Menu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Menu.Data.Configurations
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasQueryFilter(conf => !conf.IsDeleted);

            builder.ToTable(nameof(Recipe).ToUpper())
                .HasKey(conf => conf.Id);

            builder.Property(conf => conf.IncludedDate)
                .IsRequired();

            builder.Property(conf => conf.IsDeleted)
                .IsRequired();

            builder.Property(conf => conf.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(conf => conf.Observations)
                .HasMaxLength(1000);

            builder.HasOne(conf => conf.TotalWeight)
                .WithOne(conf => conf.Recipe)
                .HasForeignKey<Recipe>(conf => conf.TotalWeightId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(conf => conf.TotalCost)
                .WithOne(conf => conf.Recipe)
                .HasForeignKey<Recipe>(conf => conf.TotalCostId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(conf => conf.SalePrice)
                .WithOne(conf => conf.Recipe)
                .HasForeignKey<Recipe>(conf => conf.SalePriceId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(conf => conf.Cook)
                .WithMany(conf => conf.Recipes)
                .HasForeignKey(conf => conf.CookId)
                .IsRequired();
        }
    }
}
