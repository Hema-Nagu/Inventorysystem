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
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _services;
        public SuppliersController(ISupplierService services)
        {
            _services = services;
        }


        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            return await _services.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetSupplier(int id)
        {
            return await _services.Get(id);
        }

        //// PUT: api/Questions/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplier(int id, Supplier supplier)
        {
            if (id != supplier.supplierId)
            {
                return BadRequest();
            }
            await _services.Update(supplier);
            return NoContent();
        }

        //// POST: api/Questions
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostSupplier(Supplier supplier)
        {
            var newSupplier = await _services.Create(supplier);
            return CreatedAtAction(nameof(GetSupplier), new { id = newSupplier.supplierId }, newSupplier);

        }

        //// DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var supplier = await _services.Get(id);
            if (supplier == null)
            {
                return NotFound();
            }
            await _services.Delete(id);
            return NoContent();
        }
    }
}
