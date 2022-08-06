using Microsoft.AspNetCore.Mvc;
using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Repositories;

namespace RecipeManagerWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeCategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RecipeCategoriesController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> AddGroceryCategory(AddRecipeCategoryDto newRecipeCategory)
        {
            var result = await _unitOfWork.RecipeCategoryRepository.AddRecipeCategory(newRecipeCategory);
            await _unitOfWork.Save();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipeCategory(int id)
        {
            var result = await _unitOfWork.RecipeCategoryRepository.GetRecipeCategory(id);
            return result != null ? Ok(result) : BadRequest();
        }


        [HttpGet]
        public async Task<IActionResult> GetRecipeCategories()
        {
            return Ok(await _unitOfWork.RecipeCategoryRepository.GetRecipeCategories());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipeCategory(int id)
        {
            var result = await _unitOfWork.RecipeCategoryRepository.DeleteRecipeCategory(id);
            await _unitOfWork.Save();
            return result ? Ok() : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRecipeCategory(UpdateRecipeCategoryDto updatedRecipe)
        {
            var result = await _unitOfWork.RecipeCategoryRepository.UpdateRecipeCategory(updatedRecipe);
            await _unitOfWork.Save();
            return result != null ? Ok(result) : BadRequest();
        }
    }
}
