﻿// <auto-generated />
using Menu.Data.Context;
using Menu.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Menu.Data.Migrations
{
    [DbContext(typeof(MenuContext))]
    partial class MenuContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("MENU")
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Menu.Domain.Entities.Associations.IngredientDistributor", b =>
                {
                    b.Property<long>("DistributorId");

                    b.Property<long>("IngredientId");

                    b.HasKey("DistributorId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("INGREDIENT_HAS_DISTRIBUTOR");
                });

            modelBuilder.Entity("Menu.Domain.Entities.Consolidation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CostId");

                    b.Property<DateTime>("IncludedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Observations")
                        .HasMaxLength(100);

                    b.Property<long>("ProductInputId");

                    b.Property<long>("TotalWeightId");

                    b.Property<int>("UnitOfVolume");

                    b.HasKey("Id");

                    b.HasIndex("CostId")
                        .IsUnique();

                    b.HasIndex("ProductInputId");

                    b.HasIndex("TotalWeightId")
                        .IsUnique();

                    b.ToTable("CONSOLIDATION");
                });

            modelBuilder.Entity("Menu.Domain.Entities.Cook", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(16);

                    b.Property<DateTime>("IncludedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("COOK");
                });

            modelBuilder.Entity("Menu.Domain.Entities.Cost", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("IncludedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("Magnitude");

                    b.Property<int>("MagnitudeType");

                    b.Property<decimal>("PerUnit")
                        .HasColumnType("decimal(15,6)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(15,6)");

                    b.HasKey("Id");

                    b.ToTable("COST");
                });

            modelBuilder.Entity("Menu.Domain.Entities.Distributor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adress")
                        .HasMaxLength(50);

                    b.Property<string>("Cnpj")
                        .HasMaxLength(18);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("IncludedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Telephone")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("DISTRIBUTOR");
                });

            modelBuilder.Entity("Menu.Domain.Entities.Ingredient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<long?>("ConsolidationId");

                    b.Property<DateTime>("IncludedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<long>("LocalStorageCount");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<long>("PriceId");

                    b.Property<long?>("WeightId");

                    b.HasKey("Id");

                    b.HasIndex("ConsolidationId");

                    b.HasIndex("PriceId")
                        .IsUnique();

                    b.HasIndex("WeightId")
                        .IsUnique()
                        .HasFilter("[WeightId] IS NOT NULL");

                    b.ToTable("INGREDIENT");
                });

            modelBuilder.Entity("Menu.Domain.Entities.Price", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("IncludedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<decimal>("PricePerGramsOrMilliliters")
                        .HasColumnType("decimal(15,6)");

                    b.Property<decimal>("PricePerkilogramOrLiter")
                        .HasColumnType("decimal(15,6)");

                    b.Property<decimal>("PriceValue")
                        .HasColumnType("decimal(15,6)");

                    b.HasKey("Id");

                    b.ToTable("PRICE");
                });

            modelBuilder.Entity("Menu.Domain.Entities.ProductionInput", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("IncludedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<long?>("RecipeId");

                    b.Property<long>("TotalWeightId");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.HasIndex("TotalWeightId")
                        .IsUnique();

                    b.ToTable("PRODUCTIONINPUT");
                });

            modelBuilder.Entity("Menu.Domain.Entities.Recipe", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CookId");

                    b.Property<DateTime>("IncludedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Observations")
                        .HasMaxLength(1000);

                    b.Property<long?>("SalePriceId");

                    b.Property<long?>("TotalCostId");

                    b.Property<long?>("TotalWeightId");

                    b.HasKey("Id");

                    b.HasIndex("CookId");

                    b.HasIndex("SalePriceId")
                        .IsUnique()
                        .HasFilter("[SalePriceId] IS NOT NULL");

                    b.HasIndex("TotalCostId")
                        .IsUnique()
                        .HasFilter("[TotalCostId] IS NOT NULL");

                    b.HasIndex("TotalWeightId")
                        .IsUnique()
                        .HasFilter("[TotalWeightId] IS NOT NULL");

                    b.ToTable("RECIPE");
                });

            modelBuilder.Entity("Menu.Domain.Entities.Weight", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("IncludedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<decimal>("Unit")
                        .HasColumnType("decimal(15,2)");

                    b.Property<int>("UnitOfMeasurement");

                    b.Property<int>("UnitOfMeasurementType");

                    b.HasKey("Id");

                    b.ToTable("Weights");
                });

            modelBuilder.Entity("Menu.Domain.Entities.Associations.IngredientDistributor", b =>
                {
                    b.HasOne("Menu.Domain.Entities.Distributor", "Distributor")
                        .WithMany("Ingredients")
                        .HasForeignKey("IngredientId");

                    b.HasOne("Menu.Domain.Entities.Ingredient", "Ingredient")
                        .WithMany("Distributors")
                        .HasForeignKey("IngredientId");
                });

            modelBuilder.Entity("Menu.Domain.Entities.Consolidation", b =>
                {
                    b.HasOne("Menu.Domain.Entities.Cost", "Cost")
                        .WithOne("Consolidation")
                        .HasForeignKey("Menu.Domain.Entities.Consolidation", "CostId");

                    b.HasOne("Menu.Domain.Entities.ProductionInput", "ProductionInput")
                        .WithMany("Consolidations")
                        .HasForeignKey("ProductInputId");

                    b.HasOne("Menu.Domain.Entities.Weight", "TotalWeight")
                        .WithOne("Consolidation")
                        .HasForeignKey("Menu.Domain.Entities.Consolidation", "TotalWeightId");
                });

            modelBuilder.Entity("Menu.Domain.Entities.Ingredient", b =>
                {
                    b.HasOne("Menu.Domain.Entities.Consolidation", "Consolidation")
                        .WithMany("Ingredients")
                        .HasForeignKey("ConsolidationId");

                    b.HasOne("Menu.Domain.Entities.Price", "Price")
                        .WithOne("Ingredient")
                        .HasForeignKey("Menu.Domain.Entities.Ingredient", "PriceId");

                    b.HasOne("Menu.Domain.Entities.Weight", "Weight")
                        .WithOne("Ingredient")
                        .HasForeignKey("Menu.Domain.Entities.Ingredient", "WeightId");
                });

            modelBuilder.Entity("Menu.Domain.Entities.ProductionInput", b =>
                {
                    b.HasOne("Menu.Domain.Entities.Recipe")
                        .WithMany("ProductionInputs")
                        .HasForeignKey("RecipeId");

                    b.HasOne("Menu.Domain.Entities.Weight", "TotalWeight")
                        .WithOne("ProductionInput")
                        .HasForeignKey("Menu.Domain.Entities.ProductionInput", "TotalWeightId");
                });

            modelBuilder.Entity("Menu.Domain.Entities.Recipe", b =>
                {
                    b.HasOne("Menu.Domain.Entities.Cook", "Cook")
                        .WithMany("Recipes")
                        .HasForeignKey("CookId");

                    b.HasOne("Menu.Domain.Entities.Price", "SalePrice")
                        .WithOne("Recipe")
                        .HasForeignKey("Menu.Domain.Entities.Recipe", "SalePriceId");

                    b.HasOne("Menu.Domain.Entities.Cost", "TotalCost")
                        .WithOne("Recipe")
                        .HasForeignKey("Menu.Domain.Entities.Recipe", "TotalCostId");

                    b.HasOne("Menu.Domain.Entities.Weight", "TotalWeight")
                        .WithOne("Recipe")
                        .HasForeignKey("Menu.Domain.Entities.Recipe", "TotalWeightId");
                });
#pragma warning restore 612, 618
        }
    }
}
