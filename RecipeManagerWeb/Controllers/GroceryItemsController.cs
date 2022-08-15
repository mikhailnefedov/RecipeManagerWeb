using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Models;
using RecipeManagerWeb.Repositories;

namespace RecipeManagerWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroceryItemsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GroceryItemsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<GetGroceryItemDto>> AddGroceryItem(AddGroceryItemDto newGroceryItem)
        {
            GroceryItem groceryItem = _mapper.Map<GroceryItem>(newGroceryItem);
            await _unitOfWork.GroceryItemRepository.Add(groceryItem);
            await _unitOfWork.Save();
            return Ok(_mapper.Map<GetGroceryItemDto>(groceryItem));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetGroceryItemDto>> GetGroceryItem(int id)
        {
            var groceryItem = await _unitOfWork.GroceryItemRepository.GetById(id);
            return groceryItem != null ? Ok(_mapper.Map<GetGroceryItemDto>(groceryItem)) : BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<List<GetGroceryItemDto>>> GetGroceryItems()
        {
            var groceryItems = await _unitOfWork.GroceryItemRepository.GetAll();
            return Ok(_mapper.Map<List<GetGroceryItemDto>>(groceryItems));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteGroceryItem(int id)
        {
            var groceryItem = await _unitOfWork.GroceryItemRepository.GetById(id);
            if (groceryItem is null) return BadRequest();

            var isGroceryItemInRecipes =
                await _unitOfWork.GroceryItemRepository.CheckIfItemIsUsedInRecipes(groceryItem);

            if (isGroceryItemInRecipes)
            {
                return BadRequest();
            }
            else
            {
                _unitOfWork.GroceryItemRepository.Remove(groceryItem);
                await _unitOfWork.Save();
                return Ok(true);
            }
        }

        [HttpPut]
        public async Task<ActionResult<GetGroceryItemDto>> UpdateGroceryItem(UpdateGroceryItemDto updatedItem)
        {
            var groceryItem = _mapper.Map<GroceryItem>(updatedItem);
            _unitOfWork.GroceryItemRepository.Update(groceryItem);
            await _unitOfWork.Save();
            return Ok(_mapper.Map<GetGroceryItemDto>(groceryItem));
        }
    }
}
