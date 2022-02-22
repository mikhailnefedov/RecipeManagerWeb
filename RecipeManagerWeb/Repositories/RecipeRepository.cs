using Microsoft.EntityFrameworkCore;
using RecipeManagerWeb.Data;
using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly DataContext _context;

        public RecipeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Recipe> AddRecipe(AddRecipeDto newRecipe)
        {
            Recipe recipe = new Recipe()
            {
                Title = newRecipe.Title,
                Amount = newRecipe.Amount,
                Comment = newRecipe.Comment,
                PortionUnit = newRecipe.PortionUnit,
                Source = newRecipe.Source,
                Time = newRecipe.Time,
                Vegetarian = newRecipe.Vegetarian,   
            };

            recipe.Instructions = newRecipe.Instructions.Select(i => new InstructionStep() { 
                Recipe = recipe, 
                Text = i.Text 
            }
            ).ToList();
            
            recipe.Ingredients = newRecipe.Ingredients.Select(i => new RecipeGroceryItem() { 
                Amount = i.Amount,
                Measurementunit = i.Measurementunit,
                GroceryItemId = i.GroceryItemId,
                Recipe = recipe
            }
            ).ToList();

            recipe.RecipeCategory = await _context.RecipeCategories.FirstAsync(c => c.Id == newRecipe.RecipeCategoryId);

            await _context.Recipes.AddAsync(recipe);
            await _context.InstructionSteps.AddRangeAsync(recipe.Instructions);
            await _context.RecipeGroceryItems.AddRangeAsync(recipe.Ingredients);
            await _context.SaveChangesAsync();

            return recipe;
        }
    }
}
