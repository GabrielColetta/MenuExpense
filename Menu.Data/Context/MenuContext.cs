using Menu.Data.Configurations;
using Menu.Data.Configurations.Associations;
using Menu.Domain.Contracts.Pattern;
using Menu.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Menu.Data.Context
{
    public class MenuContext : DbContext, IContext
    {
        public MenuContext() { }

        public MenuContext(DbContextOptions<MenuContext> options) : base(options) { }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Consolidation> Consolidations { get; set; }
        public DbSet<Cook> Cooks { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Distributor> Distributors { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<ProductionInput> ProductionInputs { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Weight> Weights { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Server=(local)\SQLEXPRESS01;Database=MENU_EXPENSE;Trusted_Connection=True;");
            base.OnConfiguring(optionBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("MENU");
            modelBuilder.ApplyConfiguration(new IngredientConfiguration());
            modelBuilder.ApplyConfiguration(new IngredientDistributorConfiguration());
            modelBuilder.ApplyConfiguration(new ConsolidationConfiguration());
            modelBuilder.ApplyConfiguration(new CookConfiguration());
            modelBuilder.ApplyConfiguration(new CostConfiguration());
            modelBuilder.ApplyConfiguration(new DistributorConfiguration());
            modelBuilder.ApplyConfiguration(new PriceConfiguration());
            modelBuilder.ApplyConfiguration(new ProductionInputConfiguration());
            modelBuilder.ApplyConfiguration(new RecipeConfiguration());
            modelBuilder.ApplyConfiguration(new WeightConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
