using RecipeManagerWeb.Data;

namespace RecipeManagerWeb.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public GroceryItemRepository GroceryItemRepository { get; }

        public GroceryCategoryRepository GroceryCategoryRepository { get; }

        public InstructionStepRepository InstructionStepRepository { get; }

        public RecipeCategoryRepository RecipeCategoryRepository { get; }

        public RecipeRepository RecipeRepository { get; }

        public UnitOfWork(DataContext context,
            GroceryItemRepository groceryItemRepository,
            GroceryCategoryRepository groceryCategoryRepository,
            InstructionStepRepository instructionStepRepository,
            RecipeCategoryRepository recipeCategoryRepository,
            RecipeRepository recipeRepository)
        {
            _context = context;
            GroceryItemRepository = groceryItemRepository;
            GroceryCategoryRepository = groceryCategoryRepository;
            InstructionStepRepository = instructionStepRepository;
            RecipeCategoryRepository = recipeCategoryRepository;
            RecipeRepository = recipeRepository;
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
