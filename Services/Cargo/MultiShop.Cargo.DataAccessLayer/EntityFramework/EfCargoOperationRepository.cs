using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Repositories;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoOperationRepository : GenericRepository<CargoOperation>, ICargoOperationRepository
    {
        public EfCargoOperationRepository(CargoContext context) : base(context)
        {
        }
    }
}
