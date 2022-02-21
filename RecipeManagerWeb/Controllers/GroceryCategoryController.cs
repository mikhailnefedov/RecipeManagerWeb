using Microsoft.AspNetCore.Mvc;
using RecipeManagerWeb.Repositories;

namespace RecipeManagerWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroceryCategoryController : ControllerBase
    {
        private readonly IGroceryCategoryRepository _groceryCategoryRepository;

        public GroceryCategoryController(IGroceryCategoryRepository groceryCategoryRepository) 
        { 
            _groceryCategoryRepository = groceryCategoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddGroceryCategory(string name)
        {
            return Ok(await _groceryCategoryRepository.AddGroceryCategory(name));
        }
    }
}
