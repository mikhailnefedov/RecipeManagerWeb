using Microsoft.AspNetCore.Mvc;
using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Repositories;

namespace RecipeManagerWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroceryItemsController : ControllerBase
    {
        private readonly IGroceryItemRepository _groceryItemRepository;

        public GroceryItemsController(IGroceryItemRepository groceryItemRepository)
        {
            _groceryItemRepository = groceryItemRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddGroceryItem(AddGroceryItemDto newGroceryItem)
        {
            return Ok(await _groceryItemRepository.AddGroceryItem(newGroceryItem));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroceryItem(int id)
        {
            var result = await _groceryItemRepository.GetGroceryItem(id);
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
        public async Task<IActionResult> GetGroceryItems()
        {
            return Ok(await _groceryItemRepository.GetGroceryItems());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroceryItem(int id)
        {
            var result = await _groceryItemRepository.DeleteGroceryItem(id);

            return result ? Ok() : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGroceryItem(UpdateGroceryItemDto updatedItem)
        {
            var result = await _groceryItemRepository.UpdateGroceryItem(updatedItem);

            return result != null ? Ok(result) : BadRequest();
        }
    }
}
