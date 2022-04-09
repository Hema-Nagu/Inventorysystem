using Microsoft.EntityFrameworkCore;
using InventoryAPI.Data;
using InventoryAPI.Models;

namespace InventoryAPI.Services
{
    public interface ICategoryService
    {
        public Task<Category> Get(int id);
        public Task<Category> Create(Category category);
        public Task Delete(int id);
        public Task<IEnumerable<Category>> Get();
        public Task Update(Category category);



    }
    public class CategoryService : ICategoryService
    {
        private readonly SupplierDBContext _context;
        public CategoryService(SupplierDBContext context)
        {
            _context = context;
        }
        public async Task<Category> Create(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<Category> Get(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            category.Products = _context.Products.Where(p => p.CategoryId == category.CategoryId).ToList();
            foreach (var p in category.Products)
            {
                p.inventory = _context.Inventories.First(i => i.ProductId == p.product_Id);
            }
            if (category != null)
            {
                return category;
            }
            return null;
        }

        public async Task<IEnumerable<Category>> Get()
        {
            var categories = await _context.Categories.ToListAsync();
            foreach (var c in categories)
            {
                c.Products = (from p in _context.Products where p.CategoryId == c.CategoryId select p).ToList();
            }
            categories.ForEach(c =>
            {
                foreach (var p in c.Products)
                {
                    p.inventory = _context.Inventories.First(i => i.ProductId == p.product_Id);
                }
            });
            return categories;

        }

        public async Task Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
