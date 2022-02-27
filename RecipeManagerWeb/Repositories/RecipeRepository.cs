using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecipeManagerWeb.Data;
using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public RecipeRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Recipe> AddRecipe(AddRecipeDto newRecipe)
        {
            Recipe recipe = _mapper.Map<Recipe>(newRecipe);

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
            await _context.SaveChangesAsync();

            return recipe;
        }
    }
}
