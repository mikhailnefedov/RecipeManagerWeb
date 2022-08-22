using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Models;
using RecipeManagerWeb.Repositories;

namespace RecipeManagerWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeCategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RecipeCategoriesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<GetRecipeCategoryDto>> AddGroceryCategory(AddRecipeCategoryDto newRecipeCategory)
        {
            RecipeCategory recipeCategory = _mapper.Map<RecipeCategory>(newRecipeCategory);
            await _unitOfWork.RecipeCategoryRepository.Add(recipeCategory);
            await _unitOfWork.Save();
            return Ok(_mapper.Map<GetRecipeCategoryDto>(recipeCategory));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetRecipeCategoryDto>> GetRecipeCategory(int id)
        {
            var recipeCategory = await _unitOfWork.RecipeCategoryRepository.GetById(id);
            return recipeCategory != null ? Ok(_mapper.Map<GetRecipeCategoryDto>(recipeCategory)) : BadRequest();
        }


        [HttpGet]
        public async Task<ActionResult<List<GetRecipeCategoryDto>>> GetRecipeCategories()
        {
            var recipeCategories = await _unitOfWork.RecipeCategoryRepository.GetAll();
            return Ok(_mapper.Map<List<GetRecipeCategoryDto>>(recipeCategories));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteRecipeCategory(int id)
        {
            var recipeCategory = await _unitOfWork.RecipeCategoryRepository.GetById(id);
            bool recipeCategoryInUse = await _unitOfWork.RecipeCategoryRepository.CheckIfCategoryIsUsed(recipeCategory);

            if (recipeCategoryInUse)
            {
                return BadRequest();
            }
            else
            {
                _unitOfWork.RecipeCategoryRepository.Remove(recipeCategory);
                await _unitOfWork.Save();
                return Ok(true);
            }
        }

        [HttpPut]
        public async Task<ActionResult<GetRecipeCategoryDto>> UpdateRecipeCategory(UpdateRecipeCategoryDto updatedRecipe)
        {
            var recipeCategory = _mapper.Map<RecipeCategory>(updatedRecipe);
            _unitOfWork.RecipeCategoryRepository.Update(recipeCategory);
            await _unitOfWork.Save();
            return Ok(_mapper.Map<GetRecipeCategoryDto>(recipeCategory));
        }
    }
}
