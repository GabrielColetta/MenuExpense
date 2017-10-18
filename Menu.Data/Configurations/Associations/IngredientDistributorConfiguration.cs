using Menu.Domain.Entities.Associations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Menu.Data.Configurations.Associations
{
    public class IngredientDistributorConfiguration : IEntityTypeConfiguration<IngredientDistributor>
    {
        public void Configure(EntityTypeBuilder<IngredientDistributor> builder)
        {
            builder.ToTable("INGREDIENT_HAS_DISTRIBUTOR")
                .HasKey(conf => new { conf.DistributorId, conf.IngredientId });

            builder.HasOne(conf => conf.Ingredient)
                .WithMany(conf => conf.Distributors)
                .HasForeignKey(conf => conf.IngredientId)
                .IsRequired();

            builder.HasOne(conf => conf.Distributor)
                .WithMany(conf => conf.Ingredients)
                .HasForeignKey(conf => conf.DistributorId)
                .IsRequired();
        }
    }
}
