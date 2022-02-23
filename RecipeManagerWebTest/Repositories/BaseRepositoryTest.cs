using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using RecipeManagerWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagerWebTest.Repositories
{
    public class BaseRepositoryTest
    {
        protected readonly DataContext _context;

        public BaseRepositoryTest()
        {
            var dbOptions = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "testDB")
                .Options;

            _context = new DataContext(dbOptions);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _context.Dispose();
        }
    }
}
