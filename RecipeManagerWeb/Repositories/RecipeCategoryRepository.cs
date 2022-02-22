using RecipeManagerWeb.Data;
using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Repositories
{
    public class RecipeCategoryRepository : IRecipeCategoryRepository
    {
        private readonly DataContext _context;

        public RecipeCategoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<RecipeCategory> AddRecipeCategory(AddRecipeCategoryDto newRecipeCategory)
        {
            RecipeCategory category = new RecipeCategory()
            {
                Name = newRecipeCategory.Name,
                Abbreviation = newRecipeCategory.Abbreviation,
            };

            await _context.RecipeCategories.AddAsync(category);
            await _context.SaveChangesAsync();

            return category;
        }
    }
}
