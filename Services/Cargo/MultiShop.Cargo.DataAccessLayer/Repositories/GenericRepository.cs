using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        private readonly CargoContext _context;

        public GenericRepository(CargoContext context)
        {
            _context = context;

        }
        DbSet<T> _entity => _context.Set<T>();
        public async Task Delete(int id)
        {
            var values = await _entity.FindAsync(id);
            _entity.Remove(values);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll()
        {
            var values = await _entity.ToListAsync();
            return values;
        }

        public async Task<T> GetById(int id)
        {
            var values = await _entity.FindAsync(id);
            return values;
        }

        public async Task Insert(T entity)
        {
            await _entity.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _entity.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
