using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Models;
using RecipeManagerWeb.Repositories;

namespace RecipeManagerWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RecipesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<GetRecipeDto>> AddRecipe(AddRecipeDto newRecipe)
        {
            Recipe recipe = _mapper.Map<Recipe>(newRecipe);
            recipe.Ingredients.ForEach(i => i.Recipe = recipe);
            recipe.Instructions.ForEach(i => i.Recipe = recipe);
            await _unitOfWork.RecipeRepository.Add(recipe);
            await _unitOfWork.Save();
            return Ok(_mapper.Map<GetRecipeDto>(recipe));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetRecipeDto>> GetRecipe(int id)
        {
            Recipe recipe = await _unitOfWork.RecipeRepository.GetById(id);
            return recipe != null ? Ok(_mapper.Map<GetRecipeDto>(recipe)) : BadRequest();
        }

        [HttpGet("smallrecipes")]
        public async Task<ActionResult<List<GetSmallRecipeDto>>> GetSmallRecipes()
        {
            var recipes = await _unitOfWork.RecipeRepository.GetAll();
            return Ok(_mapper.Map<List<GetSmallRecipeDto>>(recipes));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteRecipe(int id)
        {
            Recipe recipe = await _unitOfWork.RecipeRepository.GetById(id);
            _unitOfWork.RecipeRepository.Remove(recipe);
            await _unitOfWork.Save();
            return Ok(true);
        }

        [HttpPut]
        public async Task<ActionResult<GetRecipeDto>> UpdateRecipe(UpdateRecipeDto updatedRecipe)
        {
            Recipe recipe = await _unitOfWork.RecipeRepository.GetById(updatedRecipe.Id);
            recipe = _mapper.Map(updatedRecipe, recipe);
            _unitOfWork.RecipeRepository.Update(recipe);
            await _unitOfWork.Save();
            return Ok(_mapper.Map<GetRecipeDto>(recipe));
        }
    }
}
