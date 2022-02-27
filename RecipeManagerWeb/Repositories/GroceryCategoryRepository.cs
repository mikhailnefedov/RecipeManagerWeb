using Microsoft.EntityFrameworkCore;
using RecipeManagerWeb.Data;
using RecipeManagerWeb.Dtos;
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

        public async Task<GetGroceryCategoryDto?> GetGroceryCategory(int groceryCategoryId)
        {
            var groceryCategory = await _context.GroceryCategories.FindAsync(groceryCategoryId);

            if (groceryCategory is not null)
            {
                GetGroceryCategoryDto dto = new GetGroceryCategoryDto()
                {
                    Id = groceryCategory.Id,
                    Name = groceryCategory.Name,
                };
                return dto;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<GetGroceryCategoryDto>> GetGroceryCategories()
        {
            var groceryCategories = await _context.GroceryCategories.ToListAsync();

            return groceryCategories.Select(c => new GetGroceryCategoryDto()
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();     
        }
    }
}
