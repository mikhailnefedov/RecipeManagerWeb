namespace RecipeManagerWeb.Repositories
{
    public interface IUnitOfWork
    {
        GroceryItemRepository GroceryItemRepository { get; }
        GroceryCategoryRepository GroceryCategoryRepository { get; }
        InstructionStepRepository InstructionStepRepository { get; }
        RecipeCategoryRepository RecipeCategoryRepository { get; }
        RecipeRepository RecipeRepository { get; }

        Task<int> Save();
    }
}
