using NUnit.Framework;
using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagerWebTest.Repositories
{
    public  class RecipeCategoryRepositoryTest : BaseRepositoryTest
    {

        private readonly RecipeCategoryRepository _recipeCategoryRepository;

        public RecipeCategoryRepositoryTest() : base()
        {
            _recipeCategoryRepository = new RecipeCategoryRepository(_context);
        }

        [Test]
        public void AddRecipeCategory_MinimalRecipeCategory_NoErrors()
        {
            AddRecipeCategoryDto addRecipeCategoryDto = new AddRecipeCategoryDto()
            {
                Name = "category name"
            };

            Assert.DoesNotThrowAsync(async () =>
            {
                await _recipeCategoryRepository.AddRecipeCategory(addRecipeCategoryDto);
            });
        }
    }
}
