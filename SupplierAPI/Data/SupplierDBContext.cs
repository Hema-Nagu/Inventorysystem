using Microsoft.EntityFrameworkCore;
using InventoryAPI.Models;

namespace InventoryAPI.Data
{
    public class SupplierDBContext:DbContext
    {
        public SupplierDBContext(DbContextOptions<SupplierDBContext> options):base(options)
        {
            Database.EnsureCreated();

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // I had removed this
            
        }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Brand> Brands { get; set; }

    }
}
