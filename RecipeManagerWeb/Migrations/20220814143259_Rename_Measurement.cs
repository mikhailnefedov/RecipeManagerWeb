using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeManagerWeb.Migrations
{
    public partial class Rename_Measurement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Measurementunit",
                table: "RecipeGroceryItems",
                newName: "Measurement");

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "Recipes",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "RecipeGroceryItems",
                columns: new[] { "GroceryItemId", "RecipeId", "Amount", "Measurement" },
                values: new object[] { 3, 2, 10.0, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RecipeGroceryItems",
                keyColumns: new[] { "GroceryItemId", "RecipeId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.RenameColumn(
                name: "Measurement",
                table: "RecipeGroceryItems",
                newName: "Measurementunit");

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "Recipes",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL");
        }
    }
}
