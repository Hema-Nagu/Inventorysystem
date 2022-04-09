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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _services;
        public CategoriesController(ICategoryService services)
        {
            _services = services;
        }


        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<Category>> GetCategory()
        {
            return await _services.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            return await _services.Get(id);
        }

        //// PUT: api/Questions/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest();
            }
            await _services.Update(category);
            return NoContent();
        }

        //// POST: api/Questions
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            var newCategory = await _services.Create(category);
            return CreatedAtAction(nameof(GetCategory), new { id = newCategory.CategoryId }, newCategory);

        }

        //// DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _services.Get(id);
            if (category == null)
            {
                return NotFound();
            }
            await _services.Delete(id);
            return NoContent();
        }
    }
}
