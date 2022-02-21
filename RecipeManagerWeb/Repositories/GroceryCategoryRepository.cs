using RecipeManagerWeb.Data;
using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Repositories
{
    public class GroceryCategoryRepository : IGroceryCategoryRepository
    {
        private readonly DataContext _context;

        public GroceryCategoryRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<GroceryCategory> AddGroceryCategory(string categoryName)
        {
            GroceryCategory groceryCategory = new GroceryCategory { Name = categoryName};
            
            await _context.GroceryCategories.AddAsync(groceryCategory);
            await _context.SaveChangesAsync();

            return groceryCategory;
        }
    }
}
