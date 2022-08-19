using Microsoft.EntityFrameworkCore;
using RecipeManagerWeb.Data;
using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Repositories
{
    public class RecipeCategoryRepository : GenericRepository<RecipeCategory>, IRecipeCategoryRepository
    {
        private readonly DataContext _context;

        public RecipeCategoryRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CheckIfCategoryIsUsed(RecipeCategory recipeCategory)
        {
            bool usedInRecipes = await _context.Recipes.AnyAsync(recipe => recipe.RecipeCategoryId == recipeCategory.Id);
            return usedInRecipes;
        }

    }
}
