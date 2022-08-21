using Microsoft.AspNetCore.Mvc;
using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Repositories;

namespace RecipeManagerWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RecipesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> AddRecipe(AddRecipeDto newRecipe)
        {
            var result = await _unitOfWork.RecipeRepository.AddRecipe(newRecipe);
            await _unitOfWork.Save();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipe(int id)
        {
            var result = await _unitOfWork.RecipeRepository.GetRecipe(id);
            return result != null ? Ok(result) : BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetRecipes()
        {
            return Ok(await _unitOfWork.RecipeRepository.GetRecipes());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            var result = await _unitOfWork.RecipeRepository.DeleteRecipe(id);
            await _unitOfWork.Save();
            return result ? Ok() : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRecipe(UpdateRecipeDto updatedRecipe)
        {
            var result = await _unitOfWork.RecipeRepository.UpdateRecipe(updatedRecipe);
            await _unitOfWork.Save();
            return result != null ? Ok(result) : BadRequest();
        }
    }
}
