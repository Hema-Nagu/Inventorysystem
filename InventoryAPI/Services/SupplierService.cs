using Microsoft.EntityFrameworkCore;
using InventoryAPI.Data;
using InventoryAPI.Models;

namespace InventoryAPI.Services
{
    public interface ISupplierService
    {
        public Task<Supplier> Get(int id);
        public Task<Supplier> Create(Supplier supplier);
        public Task Delete(int id);
        public Task<IEnumerable<Supplier>> Get();
        public Task Update(Supplier supplier);

    }
    public class SupplierService : ISupplierService
    {
        private readonly SupplierDBContext _context;
        public SupplierService(SupplierDBContext context)
        {
            _context = context;
        }
        public async Task<Supplier> Create(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task Delete(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<Supplier> Get(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            supplier.Products = _context.Products.Where(p => p.SupplierId == supplier.supplierId).ToList();
            foreach (var p in supplier.Products)
            {
                p.inventory = _context.Inventories.First(i => i.ProductId == p.product_Id);
            }
            if (supplier != null)
            {
                return supplier;
            }
            return null;
        }

        public async Task<IEnumerable<Supplier>> Get()
        {
            var suppliers = await _context.Suppliers.ToListAsync();
            foreach (var s in suppliers)
            {
                s.Products = (from p in _context.Products where p.SupplierId == s.supplierId select p).ToList();
            }
            suppliers.ForEach(s =>
            {
                foreach (var p in s.Products)
                {
                    p.inventory = _context.Inventories.First(i => i.ProductId == p.product_Id);
                }
            });
            return suppliers;

        }

        public async Task Update(Supplier supplier)
        {
            _context.Entry(supplier).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
