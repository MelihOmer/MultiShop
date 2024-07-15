using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoCustomerManager : ICargoCustomerService
    {
        private readonly ICargoCustomerRepository _repos;

        public CargoCustomerManager(ICargoCustomerRepository repos)
        {
            _repos = repos;
        }

        public async Task Delete(int id)
        {
            await _repos.Delete(id);
        }

        public async Task<List<CargoCustomer>> GetAll()
        {
            return await _repos.GetAll();
        }

        public Task<CargoCustomer> GetById(int id)
        {
            return _repos.GetById(id);
        }

        public async Task Insert(CargoCustomer entity)
        {
            await _repos.Insert(entity);
        }

        public async Task Update(CargoCustomer entity)
        {
           await _repos.Update(entity);
        }
    }
}
