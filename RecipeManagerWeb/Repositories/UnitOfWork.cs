using RecipeManagerWeb.Data;

namespace RecipeManagerWeb.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public IGroceryItemRepository GroceryItemRepository { get; }

        public IGroceryCategoryRepository GroceryCategoryRepository { get; }

        public IRecipeCategoryRepository RecipeCategoryRepository { get; }

        public IRecipeRepository RecipeRepository { get; }

        public UnitOfWork(DataContext context,
            IGroceryItemRepository groceryItemRepository,
            IGroceryCategoryRepository groceryCategoryRepository,
            IRecipeCategoryRepository recipeCategoryRepository,
            IRecipeRepository recipeRepository)
        {
            _context = context;
            GroceryItemRepository = groceryItemRepository;
            GroceryCategoryRepository = groceryCategoryRepository;
            RecipeCategoryRepository = recipeCategoryRepository;
            RecipeRepository = recipeRepository;
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
