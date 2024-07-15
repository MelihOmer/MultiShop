using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoOperationManager : ICargoOperationService
    {
        private readonly ICargoOperationRepository _repos;

        public CargoOperationManager(ICargoOperationRepository repos)
        {
            _repos = repos;
        }

        public async Task Delete(int id)
        {
          await  _repos.Delete(id);
        }

        public async Task<List<CargoOperation>> GetAll()
        {
            return await _repos.GetAll();
        }

        public Task<CargoOperation> GetById(int id)
        {
            return _repos.GetById(id);
        }

        public async Task Insert(CargoOperation entity)
        {
           await _repos.Insert(entity);
        }

        public async Task Update(CargoOperation entity)
        {
           await _repos.Update(entity);
        }
    }
}
