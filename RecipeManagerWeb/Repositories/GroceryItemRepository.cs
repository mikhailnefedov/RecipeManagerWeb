using Microsoft.EntityFrameworkCore;
using RecipeManagerWeb.Data;
using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Repositories
{
    public class GroceryItemRepository : IGroceryItemRepository
    {
        private readonly DataContext _context;
        public GroceryItemRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<GroceryItem> AddGroceryItem(AddGroceryItemDto newGroceryItem)
        {
            GroceryItem groceryItem = new GroceryItem() { Name = newGroceryItem.Name};
            groceryItem.Category = await _context.GroceryCategories.FirstOrDefaultAsync(c => c.Id == newGroceryItem.GroceryCategoryId);

            await _context.GroceryItems.AddAsync(groceryItem);
            await _context.SaveChangesAsync();

            return groceryItem;
        }
    }
}
