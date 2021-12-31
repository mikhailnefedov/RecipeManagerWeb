using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Repositories
{
    public interface IRecipeCategoryRepository
    {
        public Task<RecipeCategory> AddRecipeCategory(AddRecipeCategoryDto newRecipeCategory);
    }
}
