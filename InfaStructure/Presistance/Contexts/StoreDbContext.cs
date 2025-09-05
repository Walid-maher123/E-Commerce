using DomainLayer.Entities.OrderModels;
using DomainLayer.Entities.ProductsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Presistance.Contexts
{
    public class StoreDbContext :DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> option):base(option) { }
       
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductBrand> Brands { get; set; }
        public DbSet<ProductType> Types  { get; set; }
        public DbSet<Order> Orders  { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
        public DbSet<ItemOfOrders> ItemOfOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
