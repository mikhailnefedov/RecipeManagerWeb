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
        /// <response code="400">If given recipe list contains duplicates</response> 
        [HttpPost]
        public async Task<IActionResult> PostShoppingList([FromBody] List<RecipeSelectionDto> recipeSelection)
        {
            var recipeIds = GetRecipeIds(recipeSelection);
            if (ListContainsDuplicates(recipeIds)) return BadRequest();

            var shoppingList = await ComputeShoppingList(recipeSelection);

            var resultDto = ShoppingListDto.ConvertFromShoppingList(shoppingList);
            return Ok(resultDto);
        }

        private List<int> GetRecipeIds(List<RecipeSelectionDto> recipeSelection)
        {
            return recipeSelection.Select(r => r.RecipeId).ToList();
        }

        private bool ListContainsDuplicates(List<int> list)
        {
            return list.Count != list.Distinct().Count();
        }

        private async Task<ShoppingList> ComputeShoppingList(List<RecipeSelectionDto> recipeSelection)
        {
            var recipeIds = GetRecipeIds(recipeSelection);
            var recipes = await _unitOfWork.RecipeRepository.GetRecipes(recipeIds);

            var orderedRecipes = recipes.OrderBy(r => r.Id);
            var orderedRecipeSelection = recipeSelection.OrderBy(r => r.RecipeId);

            ShoppingList shoppingList = new ShoppingList();
            for (int i = 0; i < orderedRecipes.Count(); i++)
            {
                var ingredients = orderedRecipes.ElementAt(i).GetIngredientsForRequestedAmount(
                    orderedRecipeSelection.ElementAt(i).RequestedAmount);
                ingredients.ForEach(i => shoppingList.AddGroceryItem(i));
            }
            return shoppingList;
        }

    }
}
