using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoCompanyManager : ICargoCompanyService
    {
        private readonly ICargoCompanyRepository _companyRepository;

        public CargoCompanyManager(ICargoCompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task Delete(int id)
        {
            await _companyRepository.Delete(id);
        }

        public async Task<List<CargoCompany>> GetAll()
        {
            return await _companyRepository.GetAll();
        }

        public Task<CargoCompany> GetById(int id)
        {
           return _companyRepository.GetById(id);
        }

        public async Task Insert(CargoCompany entity)
        {
            await _companyRepository.Insert(entity);
        }

        public async Task Update(CargoCompany entity)
        {
            await _companyRepository.Update(entity);
        }
    }
}
