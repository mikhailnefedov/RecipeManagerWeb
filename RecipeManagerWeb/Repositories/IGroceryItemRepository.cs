using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Repositories
{
    public interface IGroceryItemRepository : IRepository<GroceryItem>
    {
        public Task<bool> CheckIfItemIsUsedInRecipes(GroceryItem item);
    }
}
