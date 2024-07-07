using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Persistence.Context;
using System.Linq.Expressions;

namespace MultiShop.Order.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly OrderContext _dbContext;

        public Repository(OrderContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
           return await _dbContext.Set<T>().SingleOrDefaultAsync(filter);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
            
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
