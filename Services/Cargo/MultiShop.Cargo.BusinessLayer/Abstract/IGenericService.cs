namespace MultiShop.Cargo.BusinessLayer.Abstract
{
    public interface IGenericService <T> where T : class
    {
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(int id);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
    }
}
