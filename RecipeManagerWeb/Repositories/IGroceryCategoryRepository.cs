using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Repositories
{
    public interface IGroceryCategoryRepository
    {
        public Task<GroceryCategory> AddGroceryCategory(string categoryName);
        public Task<GetGroceryCategoryDto?> GetGroceryCategory(int groceryCategoryId);
        public Task<List<GetGroceryCategoryDto>> GetGroceryCategories();
        public Task<bool> DeleteGroceryCategory(int groceryCategoryId);
        public Task<GetGroceryCategoryDto?> UpdateGroceryCategory(UpdateGroceryCategoryDto updatedGroceryCategory);
    }
}
