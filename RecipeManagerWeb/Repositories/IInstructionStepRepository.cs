using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Repositories
{
    public interface IInstructionStepRepository
    {
        public Task<List<InstructionStep>> AddInstructionSteps(List<AddInstructionStepDto> newInstructionSteps);
    }
}
