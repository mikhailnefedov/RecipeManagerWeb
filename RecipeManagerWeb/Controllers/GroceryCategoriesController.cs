using Microsoft.AspNetCore.Mvc;
using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Repositories;

namespace RecipeManagerWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroceryCategoriesController : ControllerBase
    {
        private readonly IGroceryCategoryRepository _groceryCategoryRepository;

        public GroceryCategoriesController(IGroceryCategoryRepository groceryCategoryRepository) 
        { 
            _groceryCategoryRepository = groceryCategoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddGroceryCategory(string name)
        {
            return Ok(await _groceryCategoryRepository.AddGroceryCategory(name));
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroceryCategory(int id)
        {
            var result = await _groceryCategoryRepository.GetGroceryCategory(id);
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
        public async Task<IActionResult> GetGroceryCategories()
        {
            return Ok(await _groceryCategoryRepository.GetGroceryCategories());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroceryCategory(int id)
        {
            var result = await _groceryCategoryRepository.DeleteGroceryCategory(id);

            return result ? Ok() : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGroceryCategory(UpdateGroceryCategoryDto dto)
        {
            var result = await _groceryCategoryRepository.UpdateGroceryCategory(dto);

            return result != null ? Ok(result) : BadRequest();
        }

    }
}
