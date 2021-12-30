﻿using Microsoft.EntityFrameworkCore;
using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Data
{
    public class DataContext : DbContext
    {
        public DbSet<GroceryItem> GroceryItems { get; set; }
        public DbSet<GroceryCategory> GroceryCategories { get; set; }
        public DbSet<InstructionStep> InstructionSteps { get; set; } 
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
        public DbSet<RecipeGroceryItem> RecipeGroceryItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=recipemanager.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeGroceryItem>()
                .HasKey(rg => new { rg.RecipeId, rg.GroceryItemId });
        }
    }
}
