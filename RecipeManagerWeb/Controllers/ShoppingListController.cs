using Microsoft.AspNetCore.Mvc;
using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Models;
using RecipeManagerWeb.Repositories;

namespace RecipeManagerWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingListController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShoppingListController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Creates the shopping list for given recipes
        /// </summary>
        /// <param name="recipeSelection"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ShoppingList>> PostShoppingList([FromBody] List<RecipeSelectionDto> recipeSelection)
        {
            recipeSelection = CleanInput(recipeSelection);

            var shoppingList = await ComputeShoppingList(recipeSelection);

            var resultDto = ShoppingListDto.ConvertFromShoppingList(shoppingList);
            return Ok(resultDto);
        }

        private List<RecipeSelectionDto> CleanInput(List<RecipeSelectionDto> recipeSelection)
        {
            Dictionary<int, double> recipeAmountPairs = new Dictionary<int, double>();
            recipeSelection.ForEach(recipe =>
            {
                if (recipeAmountPairs.ContainsKey(recipe.RecipeId))
                {
                    double currentAmount = recipeAmountPairs[recipe.RecipeId];
                    recipeAmountPairs[recipe.RecipeId] = currentAmount + recipe.RequestedAmount;
                }
                else
                {
                    recipeAmountPairs[recipe.RecipeId] = recipe.RequestedAmount;
                }

            });
            return recipeAmountPairs.Select(pair => new RecipeSelectionDto()
            {
                RecipeId = pair.Key,
                RequestedAmount = pair.Value,
            }).ToList();
        }

        private List<int> GetRecipeIds(List<RecipeSelectionDto> recipeSelection)
        {
            return recipeSelection.Select(r => r.RecipeId).ToList();
        }

        private async Task<ShoppingList> ComputeShoppingList(List<RecipeSelectionDto> recipeSelection)
        {
            var recipeIds = GetRecipeIds(recipeSelection);
            var recipes = await _unitOfWork.RecipeRepository.GetRecipes(recipeIds);

            var orderedRecipes = recipes.OrderBy(r => r.Id);
            var orderedRecipeSelection = recipeSelection.OrderBy(r => r.RecipeId);

            ShoppingList shoppingList = new ShoppingList();

            var ingredientsList = orderedRecipes.Zip(orderedRecipeSelection,
                (recipe, recipeSelection) => recipe.GetIngredientsForRequestedAmount(recipeSelection.RequestedAmount)).ToList();
            ingredientsList.ForEach(list => shoppingList.AddGroceryItems(list));

            return shoppingList;
        }

    }
}
