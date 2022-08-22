using Microsoft.EntityFrameworkCore;
using RecipeManagerWeb.Data;

namespace RecipeManagerWeb.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> entities;

        public GenericRepository(DataContext context)
        {
            entities = context.Set<T>();
        }

        public async Task Add(T entity)
        {
            await entities.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await entities.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await entities.FindAsync(id);
        }

        public void Remove(T entity)
        {
            entities.Remove(entity);
        }

        public void Update(T entity)
        {
            entities.Update(entity);
        }
    }
}
