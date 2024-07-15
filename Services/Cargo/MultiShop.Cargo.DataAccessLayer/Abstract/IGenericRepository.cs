namespace MultiShop.Cargo.DataAccessLayer.Abstract
{
    public interface IGenericRepository<T> where T : class,new()
    {
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(int id);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
    }
}
