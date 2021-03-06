using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Repositories
{
    public interface IRecipeRepository
    {
        public Task<GetRecipeDto> AddRecipe(AddRecipeDto newRecipe);
        public Task<GetRecipeDto?> GetRecipe(int recipeId);
        public Task<List<GetRecipeOverviewDto>> GetRecipes();
        public Task<bool> DeleteRecipe(int recipeId);
        public Task<GetRecipeDto?> UpdateRecipe(UpdateRecipeDto updatedRecipe);

    }
}
