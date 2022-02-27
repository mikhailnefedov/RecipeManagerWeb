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
            groceryItem.Category = await _context.GroceryCategories.FirstAsync(c => c.Id == newGroceryItem.GroceryCategoryId);

            await _context.GroceryItems.AddAsync(groceryItem);
            await _context.SaveChangesAsync();

            return groceryItem;
        }

        public async Task<GetGroceryItemDto?> GetGroceryItem(int groceryItemId)
        {
            var groceryItem = await _context.GroceryItems.Include(item => item.Category)
                .FirstAsync(item => item.Id == groceryItemId);

            if (groceryItem is not null)
            {
                GetGroceryItemDto dto = new GetGroceryItemDto()
                {
                    Id = groceryItem.Id,
                    Name = groceryItem.Name,
                    groceryCategoryId = groceryItem.Category.Id,
                    groceryCategoryName = groceryItem.Category.Name,
                };
                return dto;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<GetGroceryItemDto>> GetGroceryItems()
        {
            var groceryItems = await _context.GroceryItems.Include(item => item.Category)
                .ToListAsync();

            return groceryItems.Select(item => new GetGroceryItemDto()
            {
                Id = item.Id,
                Name = item.Name,
                groceryCategoryId = item.Category.Id,
                groceryCategoryName = item.Category.Name,
            }).ToList();
        }
    }
}
