using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Models;
using RecipeManagerWeb.Repositories;

namespace RecipeManagerWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroceryCategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GroceryCategoriesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<GetGroceryCategoryDto>> AddGroceryCategory(string name)
        {
            GroceryCategory groceryCategory = new GroceryCategory { Name = name };
            await _unitOfWork.GroceryCategoryRepository.Add(groceryCategory);
            await _unitOfWork.Save();
            return Ok(_mapper.Map<GetGroceryCategoryDto>(groceryCategory));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetGroceryCategoryDto>> GetGroceryCategory(int id)
        {
            var groceryCategory = await _unitOfWork.GroceryCategoryRepository.GetById(id);
            return groceryCategory != null ? Ok(_mapper.Map<GetGroceryCategoryDto>(groceryCategory)) : BadRequest();
        }


        [HttpGet]
        public async Task<ActionResult<List<GetGroceryCategoryDto>>> GetGroceryCategories()
        {
            var results = await _unitOfWork.GroceryCategoryRepository.GetAll();
            return Ok(_mapper.Map<List<GetGroceryCategoryDto>>(results));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteGroceryCategory(int id)
        {
            var groceryCategory = await _unitOfWork.GroceryCategoryRepository.GetById(id);
            _unitOfWork.GroceryCategoryRepository.Remove(groceryCategory);
            await _unitOfWork.Save();
            return Ok(true);
        }

        [HttpPut]
        public async Task<ActionResult<GetGroceryCategoryDto>> UpdateGroceryCategory(UpdateGroceryCategoryDto dto)
        {
            var groceryCategory = _mapper.Map<GroceryCategory>(dto);
            _unitOfWork.GroceryCategoryRepository.Update(groceryCategory);
            await _unitOfWork.Save();
            return Ok(_mapper.Map<GetGroceryCategoryDto>(groceryCategory));
        }

    }
}
