namespace RecipeManagerWeb.Repositories
{
    public interface IUnitOfWork
    {
        IGroceryItemRepository GroceryItemRepository { get; }
        IGroceryCategoryRepository GroceryCategoryRepository { get; }
        IRecipeCategoryRepository RecipeCategoryRepository { get; }
        IRecipeRepository RecipeRepository { get; }

        Task<int> Save();
    }
}
