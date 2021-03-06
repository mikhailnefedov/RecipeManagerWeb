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

        public async Task<GetRecipeDto> AddRecipe(AddRecipeDto newRecipe)
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

            return _mapper.Map<GetRecipeDto>(recipe);
        }

        public async Task<bool> DeleteRecipe(int recipeId)
        {
            try
            {
                var recipe = await _context.Recipes.Include(r => r.Ingredients)
                    .Include(r => r.Instructions)
                    .FirstAsync(r => r.Id == recipeId);
                if (recipe is null) return false;

                _context.Recipes.Remove(recipe);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<GetRecipeDto?> GetRecipe(int recipeId)
        {
            var recipe = await _context.Recipes.Include(r => r.RecipeCategory)
                .Include(r => r.Instructions)
                .Include(r => r.Ingredients).ThenInclude(i => i.GroceryItem)
                .FirstAsync(r => r.Id == recipeId);

            var dto = _mapper.Map<GetRecipeDto>(recipe);

            return dto;
        }

        public async Task<List<GetRecipeOverviewDto>> GetRecipes()
        {
            var recipes = await _context.Recipes.Include(r => r.RecipeCategory)
                .ToListAsync();

            return recipes.Select(r => _mapper.Map<GetRecipeOverviewDto>(r)).ToList();
        }

        public async Task<GetRecipeDto?> UpdateRecipe(UpdateRecipeDto updatedRecipe)
        {
            try
            {
                Recipe? recipe = await _context.Recipes.FindAsync(updatedRecipe.Id);
                RecipeCategory? category = await _context.RecipeCategories.FindAsync(updatedRecipe.recipeCategoryId);

                if (recipe is null || category is null) return null;

                _mapper.Map(updatedRecipe, recipe);
                recipe.RecipeCategory = category;

                await _context.SaveChangesAsync();

                return _mapper.Map<GetRecipeDto>(recipe);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
