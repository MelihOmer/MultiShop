using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Persistence.Context
{
    public class OrderContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-964KLOT\\SQLEXPRESS; initial Catalog = MultiShopOrderDb; integrated security = true;TrustServerCertificate=True");
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderDetail> OrderDetails{ get; set; }
        public DbSet<Ordering> Orderings{ get; set; }
    }
}
