using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Repositories
{
    public interface IRecipeCategoryRepository : IRepository<RecipeCategory>
    {
        Task<bool> CheckIfCategoryIsUsed(RecipeCategory recipeCategory);
    }
}
