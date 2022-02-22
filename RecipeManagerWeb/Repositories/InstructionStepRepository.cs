using Microsoft.EntityFrameworkCore;
using RecipeManagerWeb.Data;
using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Repositories
{
    public class InstructionStepRepository : IInstructionStepRepository
    {
        private readonly DataContext _context;

        public InstructionStepRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<InstructionStep>> AddInstructionSteps(List<AddInstructionStepDto> newInstructionSteps, int recipeId)
        {
            Recipe recipe = await  _context.Recipes.FirstAsync(r => r.Id == recipeId);

            List<InstructionStep> instructionSteps = newInstructionSteps.Select(i => new InstructionStep()
            {
                Text = i.Text,
                Recipe = recipe
            }).ToList();

            await _context.InstructionSteps.AddRangeAsync(instructionSteps);
            await _context.SaveChangesAsync();

            return instructionSteps;
        }
    }
}
