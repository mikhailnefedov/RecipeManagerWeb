using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using RecipeManagerWeb.Data;
using RecipeManagerWeb.Repositories;
using RecipeManagerWebTest.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagerWebTest.Repositories
{
    public class GroceryCategoryRepositoryTest : BaseRepositoryTest
    {
        private readonly GroceryCategoryRepository _groceryCategoryRepository;

        public GroceryCategoryRepositoryTest() : base()
        {
            var mapper = AutoMapperUtility.GetConfiguration();

            _groceryCategoryRepository = new GroceryCategoryRepository(_context, mapper);
        }

        [Test]
        public void AddGroceryCategory_MinimalGroceryCategory_NoErrors()
        {
            string categoryName = "category";

            Assert.DoesNotThrowAsync(async () => 
            { 
                await _groceryCategoryRepository.AddGroceryCategory(categoryName);
            });
                       
        }
    }
}
