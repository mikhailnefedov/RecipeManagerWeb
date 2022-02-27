using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Repositories
{
    public interface IRecipeRepository
    {
        public Task<Recipe> AddRecipe(AddRecipeDto newRecipe);
        public Task<GetRecipeDto?> GetRecipe(int recipeId);
        public Task<List<GetRecipeOverviewDto>> GetRecipes();
    }
}
