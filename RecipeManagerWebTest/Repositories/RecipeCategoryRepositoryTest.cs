using NUnit.Framework;
using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Repositories;
using RecipeManagerWebTest.Utilities;
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
            var mapper = AutoMapperUtility.GetConfiguration();

            _recipeCategoryRepository = new RecipeCategoryRepository(_context, mapper);
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
