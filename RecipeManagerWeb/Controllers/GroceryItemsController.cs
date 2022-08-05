using Microsoft.AspNetCore.Mvc;
using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Repositories;

namespace RecipeManagerWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroceryItemsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GroceryItemsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> AddGroceryItem(AddGroceryItemDto newGroceryItem)
        {
            var result = await _unitOfWork.GroceryItemRepository.AddGroceryItem(newGroceryItem);
            await _unitOfWork.Save();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroceryItem(int id)
        {
            var result = await _unitOfWork.GroceryItemRepository.GetGroceryItem(id);
            return result != null ? Ok(result) : BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetGroceryItems()
        {
            return Ok(await _unitOfWork.GroceryItemRepository.GetGroceryItems());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroceryItem(int id)
        {
            var result = await _unitOfWork.GroceryItemRepository.DeleteGroceryItem(id);
            await _unitOfWork.Save();
            return result ? Ok() : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGroceryItem(UpdateGroceryItemDto updatedItem)
        {
            var result = await _unitOfWork.GroceryItemRepository.UpdateGroceryItem(updatedItem);
            await _unitOfWork.Save();
            return result != null ? Ok(result) : BadRequest();
        }
    }
}
