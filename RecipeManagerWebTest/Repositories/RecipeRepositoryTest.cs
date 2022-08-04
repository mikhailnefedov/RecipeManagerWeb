using NUnit.Framework;
using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Models;
using RecipeManagerWeb.Repositories;
using RecipeManagerWebTest.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagerWebTest.Repositories
{
    public class RecipeRepositoryTest : BaseRepositoryTest
    {
        private readonly RecipeRepository _recipeRepository;
        private const int RecipeCategoryId = 1;
        private const int GroceryCategoryId = 1;
        private const int GroceryItemId = 1;

        public RecipeRepositoryTest() : base()
        {
            var mapper = AutoMapperUtility.GetConfiguration();

            _recipeRepository = new RecipeRepository(_context, mapper);
        }

        [OneTimeSetUp]
        public void Setup()
        {
            RecipeCategory recipeCategory = new RecipeCategory()
            {
                Name = "category",
                Id = RecipeCategoryId
            };

            GroceryCategory groceryCategory = new GroceryCategory()
            {
                Id = GroceryCategoryId,
                Name = "category",
            };

            GroceryItem groceryItem = new GroceryItem()
            {
                Id= GroceryItemId,
                Name = "item",
                GroceryCategory = groceryCategory
            };

            _context.RecipeCategories.Add(recipeCategory);
            _context.GroceryCategories.Add(groceryCategory);
            _context.GroceryItems.Add(groceryItem);
            _context.SaveChanges();
        }

        [Test]
        public void AddRecipe_MinimalRecipe_NoErrors()
        {
            AddRecipeDto addRecipeDto = new AddRecipeDto()
            {
                Title = "recipe title",
                RecipeCategoryId = RecipeCategoryId,
            };

            Assert.DoesNotThrowAsync(async () =>
            {
                await _recipeRepository.AddRecipe(addRecipeDto);
            });
        }

        [Test]
        public void AddRecipe_MaximalRecipe_NoErrors()
        {
            List<AddRecipeGroceryItemDto> groceryItems = new List<AddRecipeGroceryItemDto>()
            {
                new AddRecipeGroceryItemDto()
                {
                    GroceryItemId = GroceryItemId,
                    Amount = 1.0,
                    Measurementunit = MeasurementUnit.Kg
                }
            };

            List<AddInstructionStepDto> instructionSteps = new List<AddInstructionStepDto>()
            {
                new AddInstructionStepDto()
                {
                    Text = "step 1"
                },
                new AddInstructionStepDto()
                {
                    Text = "step 2"
                }
            };

            AddRecipeDto addRecipeDto = new AddRecipeDto()
            {
                Title = "recipe title",
                RecipeCategoryId = RecipeCategoryId,
                Amount = 1.0,
                PortionUnit = PortionUnit.Bun,
                Time = 1,
                Vegetarian = true,
                Ingredients = groceryItems,
                Instructions = instructionSteps,
                Source = "source link",
                Comment = "comment"
            };

            Assert.DoesNotThrowAsync(async () =>
            {
                await _recipeRepository.AddRecipe(addRecipeDto);
            });
        }
    }
}
