using Microsoft.AspNetCore.Mvc;
using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Repositories;

namespace RecipeManagerWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeCategoryController : ControllerBase
    {
        private readonly IRecipeCategoryRepository _recipeCategoryRepository;

        public RecipeCategoryController(IRecipeCategoryRepository recipeCategoryRepository) 
        {
            _recipeCategoryRepository = recipeCategoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddGroceryCategory([FromQuery] AddRecipeCategoryDto newRecipeCategory)
        {
            return Ok(await _recipeCategoryRepository.AddRecipeCategory(newRecipeCategory));
        }
    }
}
