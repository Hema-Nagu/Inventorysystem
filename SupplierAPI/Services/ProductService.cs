using Microsoft.EntityFrameworkCore;
using InventoryAPI.Data;
using InventoryAPI.Models;
using System.Linq;

namespace InventoryAPI.Services
{
    public interface IProductService
    {
        public Task<Product> Get(int id);
        public Task<Product> Create(Product product);
        public Task Delete(int id);
        public Task<IEnumerable<Product>> Get();
        public Task Update(Product product);

    }
    public class ProductService : IProductService
    {
        private readonly SupplierDBContext _context;
        public ProductService(SupplierDBContext context)
        {
            _context = context;
        }
        public async Task<Product> Create(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<Product> Get(int id)
        {
            var product = await _context.Products.FindAsync(id);
            product.inventory= _context.Inventories.First(i => i.ProductId==product.product_Id);
            if (product != null)
            {
                return product;
            }
            return null;
        }

        public async Task<IEnumerable<Product>> Get()
        {
            //var questions = await _context.Questions.ToListAsync();
            //questions.ForEach(q => q.Answers = (from answer in _context.Answers where q.QuestionID == answer.QuestionID select answer).ToList());
            //return questions;
            var products= await _context.Products.ToListAsync();
            products.ForEach(async product => product.inventory = _context.Inventories.First(i => i.ProductId == product.product_Id));
            return products;
           
        }

        public async Task Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
