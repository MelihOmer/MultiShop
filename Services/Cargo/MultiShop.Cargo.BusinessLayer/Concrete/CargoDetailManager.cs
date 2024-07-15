using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoDetailManager : ICargoDetailService
    {
        private readonly ICargoDetailRepository _repository;

        public CargoDetailManager(ICargoDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<List<CargoDetail>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<CargoDetail> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Insert(CargoDetail entity)
        {
            await _repository.Insert(entity);
        }

        public async Task Update(CargoDetail entity)
        {
            await _repository.Update(entity);
        }
    }
}
