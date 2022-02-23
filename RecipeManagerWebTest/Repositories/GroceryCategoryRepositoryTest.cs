using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using RecipeManagerWeb.Data;
using RecipeManagerWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagerWebTest.Repositories
{
    public class GroceryCategoryRepositoryTest
    {
        private readonly GroceryCategoryRepository _groceryCategoryRepository;

        public GroceryCategoryRepositoryTest()
        {
            var dbOptions = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "testDB")
                .Options;

            var context = new DataContext(dbOptions);

            _groceryCategoryRepository = new GroceryCategoryRepository(context);
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
