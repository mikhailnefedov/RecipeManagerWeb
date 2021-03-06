using Microsoft.AspNetCore.Mvc;
using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Repositories;

namespace RecipeManagerWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstructionStepController : ControllerBase
    {
        private readonly IInstructionStepRepository _instructionStepRepository;
        public InstructionStepController(IInstructionStepRepository instructionStepRepository)
        {
            _instructionStepRepository = instructionStepRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddInstructionSteps(List<AddInstructionStepDto> newInstructionSteps, int recipeId)
        {
            return Ok(await _instructionStepRepository.AddInstructionSteps(newInstructionSteps, recipeId)); 
        }
    }
}
