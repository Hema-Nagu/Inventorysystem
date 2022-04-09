#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryAPI.Data;
using InventoryAPI.Models;
using InventoryAPI.Services;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _services;
        public ProductsController(IProductService services )
        {
            _services = services;
        }
        

        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _services.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProducts(int id)
        {
            return await _services.Get(id);
        }

        //// PUT: api/Questions/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(int id, Product product)
        {
            if (id != product.product_Id)
            {
                return BadRequest();
            }
            await _services.Update(product);
            return NoContent();
        }

        //// POST: api/Questions
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProducts(Product product)
        {
            var newProduct = await _services.Create(product);
            return CreatedAtAction(nameof(GetProducts), new { id = newProduct.product_Id }, newProduct);

        }

        //// DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducts(int id)
        {
            var product = await _services.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            await _services.Delete(id);
            return NoContent();
        }


    }
}
