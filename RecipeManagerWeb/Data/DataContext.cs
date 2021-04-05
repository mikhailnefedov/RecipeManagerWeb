using Microsoft.EntityFrameworkCore;
using RecipeManagerWeb.Models.Groceries;
using RecipeManagerWeb.Models.Recipe;
using RecipeManagerWeb.Models.RecipeCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeManagerWeb.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<GroceryItem> GroceryItems { get; set; }
        public DbSet<GroceryCategory> GroceryCategories { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
        public DbSet<InstructionStep> InstructionSteps { get; set; }
        public DbSet<RecipeGroceryItem> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeGroceryItem>()
                .HasKey(rg => new { rg.RecipeId, rg.GroceryItemId });
        }

    }
}
