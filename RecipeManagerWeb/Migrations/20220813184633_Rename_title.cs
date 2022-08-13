using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeManagerWeb.Migrations
{
    public partial class Rename_title : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Recipes",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Recipes",
                newName: "Title");
        }
    }
}
