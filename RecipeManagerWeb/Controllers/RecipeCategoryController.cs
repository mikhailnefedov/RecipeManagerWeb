using Microsoft.AspNetCore.Mvc;
using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Repositories;

namespace RecipeManagerWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeCategoriesController : ControllerBase
    {
        private readonly IRecipeCategoryRepository _recipeCategoryRepository;

        public RecipeCategoriesController(IRecipeCategoryRepository recipeCategoryRepository) 
        {
            _recipeCategoryRepository = recipeCategoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddGroceryCategory(AddRecipeCategoryDto newRecipeCategory)
        {
            return Ok(await _recipeCategoryRepository.AddRecipeCategory(newRecipeCategory));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipeCategory(int id)
        {
            var result = await _recipeCategoryRepository.GetRecipeCategory(id);
            if (result is not null)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetRecipeCategories()
        {
            return Ok(await _recipeCategoryRepository.GetRecipeCategories());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipeCategory(int id)
        {
            var result = await _recipeCategoryRepository.DeleteRecipeCategory(id);

            return result ? Ok() : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRecipeCategory(UpdateRecipeCategoryDto updatedRecipe)
        {
            var result = await _recipeCategoryRepository.UpdateRecipeCategory(updatedRecipe);

            return result != null ? Ok(result) : BadRequest();
        }
    }
}
