using NUnit.Framework;
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
    public class GroceryItemRepositoryTest : BaseRepositoryTest
    {
        private readonly GroceryItemRepository _groceryItemRepository;
        private const int CategoryId = 1;

        public GroceryItemRepositoryTest() : base()
        {
            _groceryItemRepository = new GroceryItemRepository(_context);
        }

        [OneTimeSetUp]
        public void Setup()
        {
            GroceryCategory category = new GroceryCategory()
            {
                Name = "category name",
                Id = CategoryId
            };

            _context.GroceryCategories.Add(category);
            _context.SaveChanges();
        }

        [Test]
        public void AddGroceryItem_MinimalGroceryItem_NoErrors()
        {
            AddGroceryItemDto groceryItemDto = new AddGroceryItemDto()
            {
                GroceryCategoryId = CategoryId,
                Name = "item name"
            };

            Assert.DoesNotThrowAsync(async () =>
            {
                await _groceryItemRepository.AddGroceryItem(groceryItemDto);
            });

        }
    }
}
