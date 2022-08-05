using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeManagerWeb.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroceryCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Abbreviation = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroceryItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    GroceryCategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroceryItems_GroceryCategories_GroceryCategoryId",
                        column: x => x.GroceryCategoryId,
                        principalTable: "GroceryCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    RecipeCategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<double>(type: "REAL", nullable: true),
                    PortionUnit = table.Column<int>(type: "INTEGER", nullable: true),
                    Time = table.Column<int>(type: "INTEGER", nullable: true),
                    Vegetarian = table.Column<bool>(type: "INTEGER", nullable: true),
                    Source = table.Column<string>(type: "TEXT", nullable: true),
                    Comment = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_RecipeCategories_RecipeCategoryId",
                        column: x => x.RecipeCategoryId,
                        principalTable: "RecipeCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructionSteps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    RecipeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructionSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstructionSteps_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeGroceryItems",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "INTEGER", nullable: false),
                    GroceryItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<double>(type: "REAL", nullable: false),
                    Measurementunit = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeGroceryItems", x => new { x.RecipeId, x.GroceryItemId });
                    table.ForeignKey(
                        name: "FK_RecipeGroceryItems_GroceryItems_GroceryItemId",
                        column: x => x.GroceryItemId,
                        principalTable: "GroceryItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeGroceryItems_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroceryItems_GroceryCategoryId",
                table: "GroceryItems",
                column: "GroceryCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructionSteps_RecipeId",
                table: "InstructionSteps",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeGroceryItems_GroceryItemId",
                table: "RecipeGroceryItems",
                column: "GroceryItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipeCategoryId",
                table: "Recipes",
                column: "RecipeCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstructionSteps");

            migrationBuilder.DropTable(
                name: "RecipeGroceryItems");

            migrationBuilder.DropTable(
                name: "GroceryItems");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "GroceryCategories");

            migrationBuilder.DropTable(
                name: "RecipeCategories");
        }
    }
}
