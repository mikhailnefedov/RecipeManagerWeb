using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Repositories
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        // TODO: Refactor Repositories to use generic repository pattern
        public Task<List<Recipe>> GetRecipes(List<int> recipeIds);
    }
}
