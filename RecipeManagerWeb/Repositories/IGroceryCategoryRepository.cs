using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Repositories
{
    public interface IGroceryCategoryRepository
    {
        public Task<GroceryCategory> AddGroceryCategory(string categoryName);
    }
}
