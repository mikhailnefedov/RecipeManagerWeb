using Microsoft.AspNetCore.Mvc;
using RecipeManagerWeb.Repositories;

namespace RecipeManagerWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroceryCategoryController : ControllerBase
    {
        private readonly IGroceryCategoryRepository _groceryCategoryRepositoy;

        public GroceryCategoryController(IGroceryCategoryRepository groceryCategoryRepository) 
        { 
            _groceryCategoryRepositoy = groceryCategoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddGroceryCategory(string name)
        {
            return Ok(await _groceryCategoryRepositoy.AddGroceryCategory(name));
        }
    }
}
