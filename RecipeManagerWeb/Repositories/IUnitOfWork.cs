namespace RecipeManagerWeb.Repositories
{
    public interface IUnitOfWork
    {
        IGroceryItemRepository GroceryItemRepository { get; }
        IGroceryCategoryRepository GroceryCategoryRepository { get; }
        IInstructionStepRepository InstructionStepRepository { get; }
        IRecipeCategoryRepository RecipeCategoryRepository { get; }
        IRecipeRepository RecipeRepository { get; }

        Task<int> Save();
    }
}
