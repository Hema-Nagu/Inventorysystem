using Microsoft.AspNetCore.Mvc;
using InventoryMVC.Models;
using InventoryMVC.Services;

namespace InventoryMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IClientService _services;
        public CategoryController(IClientService services)
        {
            _services = services;


        }
        public async Task<IActionResult> Index()
        {
            return View(await _services.GetCategoryData());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryData category)
        {
            category.Products = new List<ProductData>();
            var result = _services.CreateCategoryData(category);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var category = await _services.GetCategoryData(id);
            return View(category);
        }

        public async Task<IActionResult> Delete(int id)
        {
            bool res = await _services.DeleteCategoryData(id);
            if (res)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
