using Microsoft.AspNetCore.Mvc;
using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Repositories;

namespace RecipeManagerWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstructionStepController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public InstructionStepController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> AddInstructionSteps(List<AddInstructionStepDto> newInstructionSteps, int recipeId)
        {
            var result = await _unitOfWork.InstructionStepRepository.AddInstructionSteps(newInstructionSteps, recipeId);
            await _unitOfWork.Save();
            return Ok(result); 
        }
    }
}
