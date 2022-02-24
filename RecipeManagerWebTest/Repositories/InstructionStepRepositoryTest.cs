using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using RecipeManagerWeb.Data;
using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Models;
using RecipeManagerWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagerWebTest.Repositories
{
    public class InstructionStepRepositoryTest : BaseRepositoryTest
    {
        private readonly InstructionStepRepository _instructionStepRepository;
        private const int RecipeId = 1;

        public InstructionStepRepositoryTest() : base()
        {
            _instructionStepRepository = new InstructionStepRepository(_context);
        }

        [OneTimeSetUp]
        public void Setup()
        {
            RecipeCategory category = new RecipeCategory()
            {
                Name = "category",
                Id = 1
            };

            Recipe recipe = new Recipe()
            {
                Id = RecipeId,
                Title = "Recipe title",
                RecipeCategory = category,
            };

            _context.RecipeCategories.Add(category);
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
        }

        [Test]
        public void AddInstructionSteps_EmptyInstructionStepList_NoErrors()
        {
            List<AddInstructionStepDto> newInstructions = new List<AddInstructionStepDto>();


            Assert.DoesNotThrowAsync(async () =>
            {
                await _instructionStepRepository.AddInstructionSteps(newInstructions, RecipeId);
            });
        }

        [Test]
        public void AddInstructionSteps_MinimalInstructionSteps_NoErrors()
        {
            List<AddInstructionStepDto> newInstructions = new List<AddInstructionStepDto>();

            newInstructions.Add(new AddInstructionStepDto() { Text = "text" });


            Assert.DoesNotThrowAsync(async () =>
            {
                await _instructionStepRepository.AddInstructionSteps(newInstructions, RecipeId);
            });

        }
    }
}
