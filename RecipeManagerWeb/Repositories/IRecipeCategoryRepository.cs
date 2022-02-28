using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Repositories
{
    public interface IRecipeCategoryRepository
    {
        public Task<RecipeCategory> AddRecipeCategory(AddRecipeCategoryDto newRecipeCategory);
        public Task<GetRecipeCategoryDto?> GetRecipeCategory(int categoryId);
        public Task<List<GetRecipeCategoryDto>> GetRecipeCategories();
    }
}
