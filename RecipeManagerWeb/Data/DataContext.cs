using Microsoft.EntityFrameworkCore;
using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<GroceryItem> GroceryItems { get; set; } = null!;
        public DbSet<GroceryCategory> GroceryCategories { get; set; } = null!;
        public DbSet<InstructionStep> InstructionSteps { get; set; } = null!;
        public DbSet<Recipe> Recipes { get; set; } = null!;
        public DbSet<RecipeCategory> RecipeCategories { get; set; } = null!;
        public DbSet<RecipeGroceryItem> RecipeGroceryItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeGroceryItem>()
                .HasKey(rg => new { rg.RecipeId, rg.GroceryItemId });
        }
    }
}
