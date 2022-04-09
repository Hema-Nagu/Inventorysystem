using Microsoft.EntityFrameworkCore;
using InventoryAPI.Data;
using InventoryAPI.Models;

namespace InventoryAPI.Services
{
    public interface IBrandService
    {
        public Task<Brand> Get(int id);
        public Task<Brand> Create(Brand brand);
        public Task Delete(int id);
        public Task<IEnumerable<Brand>> Get();
        public Task Update(Brand brand);



    }
    public class BrandService : IBrandService
    {
        private readonly SupplierDBContext _context;
        public BrandService(SupplierDBContext context)
        {
            _context = context;
        }
        public async Task<Brand> Create(Brand brand)
        {
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
            return brand;
        }

        public async Task Delete(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand != null)
            {
                _context.Brands.Remove(brand);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<Brand> Get(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            brand.Products = _context.Products.Where(p => p.BrandId == brand.BrandId).ToList();
            foreach (var p in brand.Products)
            {
                p.inventory=_context.Inventories.First(i => i.ProductId== p.product_Id);
            }
            if (brand != null)
            {
                return brand;
            }
            return null;
        }

        public async Task<IEnumerable<Brand>> Get()
        {
           
            var brands = await _context.Brands.ToListAsync();
            foreach(var b in brands)
            {
                b.Products =  (from p in _context.Products where p.BrandId== b.BrandId select p).ToList();
            }
            brands.ForEach(b =>
            {
                foreach( var p in b.Products)
                {
                    p.inventory=_context.Inventories.First(i => i.ProductId==p.product_Id);
                }
            });
            return brands;

        }

        public async Task Update(Brand brand)
        {
            _context.Entry(brand).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
