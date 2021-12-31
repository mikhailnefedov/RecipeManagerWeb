using Microsoft.AspNetCore.Mvc;
using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Repositories;

namespace RecipeManagerWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroceryItemController : ControllerBase
    {
        private readonly IGroceryItemRepository _groceryItemRepository;

        public GroceryItemController(IGroceryItemRepository groceryItemRepository)
        {
            _groceryItemRepository = groceryItemRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddGroceryItem([FromQuery] AddGroceryItemDto newGroceryItem)
        {
            return Ok(await _groceryItemRepository.AddGroceryItem(newGroceryItem));
        }
    }
}
