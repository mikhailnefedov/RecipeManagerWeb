using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Repositories
{
    public interface IGroceryItemRepository
    {
        public Task<GroceryItem> AddGroceryItem(AddGroceryItemDto newGroceryItem);
    }
}
