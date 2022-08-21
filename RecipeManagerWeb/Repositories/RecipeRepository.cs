using Microsoft.EntityFrameworkCore;
using RecipeManagerWeb.Data;
using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Repositories
{
    public class RecipeRepository : GenericRepository<Recipe>, IRecipeRepository
    {
        private readonly DataContext _context;

        public RecipeRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Recipe>> GetRecipes(List<int> recipeIds)
        {
            return await _context.Recipes.Include(r => r.Ingredients)
                .Where(r => recipeIds.Contains(r.Id)).ToListAsync();
        }
    }
}
