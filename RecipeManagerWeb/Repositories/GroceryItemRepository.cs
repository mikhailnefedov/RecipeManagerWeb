using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecipeManagerWeb.Data;
using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Repositories
{
    public class GroceryItemRepository : GenericRepository<GroceryItem>, IGroceryItemRepository
    {
        private readonly DataContext _context;
        public GroceryItemRepository(DataContext context, IMapper mapper) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CheckIfItemIsUsedInRecipes(GroceryItem item)
        {
            return await _context.RecipeGroceryItems.AnyAsync(rc => rc.GroceryItemId == item.Id);
        }

    }
}
