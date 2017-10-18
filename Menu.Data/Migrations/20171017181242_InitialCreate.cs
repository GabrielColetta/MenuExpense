using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Menu.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "MENU");

            migrationBuilder.CreateTable(
                name: "COOK",
                schema: "MENU",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cpf = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    IncludedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COOK", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "COST",
                schema: "MENU",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IncludedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Magnitude = table.Column<int>(type: "int", nullable: false),
                    MagnitudeType = table.Column<int>(type: "int", nullable: false),
                    PerUnit = table.Column<decimal>(type: "decimal(15,6)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(15,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COST", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DISTRIBUTOR",
                schema: "MENU",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cnpj = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IncludedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DISTRIBUTOR", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PRICE",
                schema: "MENU",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IncludedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PricePerGramsOrMilliliters = table.Column<decimal>(type: "decimal(15,6)", nullable: false),
                    PricePerkilogramOrLiter = table.Column<decimal>(type: "decimal(15,6)", nullable: false),
                    PriceValue = table.Column<decimal>(type: "decimal(15,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRICE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weights",
                schema: "MENU",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IncludedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Unit = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    UnitOfMeasurement = table.Column<int>(type: "int", nullable: false),
                    UnitOfMeasurementType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RECIPE",
                schema: "MENU",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CookId = table.Column<long>(type: "bigint", nullable: false),
                    IncludedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SalePriceId = table.Column<long>(type: "bigint", nullable: true),
                    TotalCostId = table.Column<long>(type: "bigint", nullable: true),
                    TotalWeightId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RECIPE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RECIPE_COOK_CookId",
                        column: x => x.CookId,
                        principalSchema: "MENU",
                        principalTable: "COOK",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RECIPE_PRICE_SalePriceId",
                        column: x => x.SalePriceId,
                        principalSchema: "MENU",
                        principalTable: "PRICE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RECIPE_COST_TotalCostId",
                        column: x => x.TotalCostId,
                        principalSchema: "MENU",
                        principalTable: "COST",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RECIPE_Weights_TotalWeightId",
                        column: x => x.TotalWeightId,
                        principalSchema: "MENU",
                        principalTable: "Weights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTIONINPUT",
                schema: "MENU",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IncludedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RecipeId = table.Column<long>(type: "bigint", nullable: true),
                    TotalWeightId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTIONINPUT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRODUCTIONINPUT_RECIPE_RecipeId",
                        column: x => x.RecipeId,
                        principalSchema: "MENU",
                        principalTable: "RECIPE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRODUCTIONINPUT_Weights_TotalWeightId",
                        column: x => x.TotalWeightId,
                        principalSchema: "MENU",
                        principalTable: "Weights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CONSOLIDATION",
                schema: "MENU",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CostId = table.Column<long>(type: "bigint", nullable: false),
                    IncludedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProductInputId = table.Column<long>(type: "bigint", nullable: false),
                    TotalWeightId = table.Column<long>(type: "bigint", nullable: false),
                    UnitOfVolume = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONSOLIDATION", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CONSOLIDATION_COST_CostId",
                        column: x => x.CostId,
                        principalSchema: "MENU",
                        principalTable: "COST",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CONSOLIDATION_PRODUCTIONINPUT_ProductInputId",
                        column: x => x.ProductInputId,
                        principalSchema: "MENU",
                        principalTable: "PRODUCTIONINPUT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CONSOLIDATION_Weights_TotalWeightId",
                        column: x => x.TotalWeightId,
                        principalSchema: "MENU",
                        principalTable: "Weights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INGREDIENT",
                schema: "MENU",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ConsolidationId = table.Column<long>(type: "bigint", nullable: true),
                    IncludedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LocalStorageCount = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PriceId = table.Column<long>(type: "bigint", nullable: false),
                    WeightId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INGREDIENT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_INGREDIENT_CONSOLIDATION_ConsolidationId",
                        column: x => x.ConsolidationId,
                        principalSchema: "MENU",
                        principalTable: "CONSOLIDATION",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INGREDIENT_PRICE_PriceId",
                        column: x => x.PriceId,
                        principalSchema: "MENU",
                        principalTable: "PRICE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INGREDIENT_Weights_WeightId",
                        column: x => x.WeightId,
                        principalSchema: "MENU",
                        principalTable: "Weights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INGREDIENT_HAS_DISTRIBUTOR",
                schema: "MENU",
                columns: table => new
                {
                    DistributorId = table.Column<long>(type: "bigint", nullable: false),
                    IngredientId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INGREDIENT_HAS_DISTRIBUTOR", x => new { x.DistributorId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_INGREDIENT_HAS_DISTRIBUTOR_DISTRIBUTOR_IngredientId",
                        column: x => x.IngredientId,
                        principalSchema: "MENU",
                        principalTable: "DISTRIBUTOR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INGREDIENT_HAS_DISTRIBUTOR_INGREDIENT_IngredientId",
                        column: x => x.IngredientId,
                        principalSchema: "MENU",
                        principalTable: "INGREDIENT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CONSOLIDATION_CostId",
                schema: "MENU",
                table: "CONSOLIDATION",
                column: "CostId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CONSOLIDATION_ProductInputId",
                schema: "MENU",
                table: "CONSOLIDATION",
                column: "ProductInputId");

            migrationBuilder.CreateIndex(
                name: "IX_CONSOLIDATION_TotalWeightId",
                schema: "MENU",
                table: "CONSOLIDATION",
                column: "TotalWeightId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_INGREDIENT_ConsolidationId",
                schema: "MENU",
                table: "INGREDIENT",
                column: "ConsolidationId");

            migrationBuilder.CreateIndex(
                name: "IX_INGREDIENT_PriceId",
                schema: "MENU",
                table: "INGREDIENT",
                column: "PriceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_INGREDIENT_WeightId",
                schema: "MENU",
                table: "INGREDIENT",
                column: "WeightId",
                unique: true,
                filter: "[WeightId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_INGREDIENT_HAS_DISTRIBUTOR_IngredientId",
                schema: "MENU",
                table: "INGREDIENT_HAS_DISTRIBUTOR",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTIONINPUT_RecipeId",
                schema: "MENU",
                table: "PRODUCTIONINPUT",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTIONINPUT_TotalWeightId",
                schema: "MENU",
                table: "PRODUCTIONINPUT",
                column: "TotalWeightId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RECIPE_CookId",
                schema: "MENU",
                table: "RECIPE",
                column: "CookId");

            migrationBuilder.CreateIndex(
                name: "IX_RECIPE_SalePriceId",
                schema: "MENU",
                table: "RECIPE",
                column: "SalePriceId",
                unique: true,
                filter: "[SalePriceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RECIPE_TotalCostId",
                schema: "MENU",
                table: "RECIPE",
                column: "TotalCostId",
                unique: true,
                filter: "[TotalCostId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RECIPE_TotalWeightId",
                schema: "MENU",
                table: "RECIPE",
                column: "TotalWeightId",
                unique: true,
                filter: "[TotalWeightId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "INGREDIENT_HAS_DISTRIBUTOR",
                schema: "MENU");

            migrationBuilder.DropTable(
                name: "DISTRIBUTOR",
                schema: "MENU");

            migrationBuilder.DropTable(
                name: "INGREDIENT",
                schema: "MENU");

            migrationBuilder.DropTable(
                name: "CONSOLIDATION",
                schema: "MENU");

            migrationBuilder.DropTable(
                name: "PRODUCTIONINPUT",
                schema: "MENU");

            migrationBuilder.DropTable(
                name: "RECIPE",
                schema: "MENU");

            migrationBuilder.DropTable(
                name: "COOK",
                schema: "MENU");

            migrationBuilder.DropTable(
                name: "PRICE",
                schema: "MENU");

            migrationBuilder.DropTable(
                name: "COST",
                schema: "MENU");

            migrationBuilder.DropTable(
                name: "Weights",
                schema: "MENU");
        }
    }
}
