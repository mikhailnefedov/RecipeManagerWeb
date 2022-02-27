using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Repositories
{
    public interface IGroceryItemRepository
    {
        public Task<GroceryItem> AddGroceryItem(AddGroceryItemDto newGroceryItem);
        public Task<GetGroceryItemDto?> GetGroceryItem(int groceryItemId);
        public Task<List<GetGroceryItemDto>> GetGroceryItems();
    }
}
