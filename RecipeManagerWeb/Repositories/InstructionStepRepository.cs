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

        public async Task<List<InstructionStep>> AddInstructionSteps(List<AddInstructionStepDto> newInstructionSteps)
        {
            Recipe recipe = await  _context.Recipes.FirstOrDefaultAsync(r => r.Id == newInstructionSteps[0].RecipeId);

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
