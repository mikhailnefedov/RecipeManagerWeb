using Microsoft.AspNetCore.Mvc;
using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Repositories;

namespace RecipeManagerWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroceryCategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GroceryCategoriesController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> AddGroceryCategory(string name)
        {
            var result = await _unitOfWork.GroceryCategoryRepository.AddGroceryCategory(name);
            await _unitOfWork.Save();
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroceryCategory(int id)
        {
            var result = await _unitOfWork.GroceryCategoryRepository.GetGroceryCategory(id);
            return result != null ? Ok(result) : BadRequest();
        }

        
        [HttpGet]
        public async Task<IActionResult> GetGroceryCategories()
        {
            return Ok(await _unitOfWork.GroceryCategoryRepository.GetGroceryCategories());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroceryCategory(int id)
        {
            var result = await _unitOfWork.GroceryCategoryRepository.DeleteGroceryCategory(id);
            await _unitOfWork.Save();

            return result ? Ok() : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGroceryCategory(UpdateGroceryCategoryDto dto)
        {
            var result = await _unitOfWork.GroceryCategoryRepository.UpdateGroceryCategory(dto);
            await _unitOfWork.Save();
            
            return result != null ? Ok(result) : BadRequest();
        }

    }
}
