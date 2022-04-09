using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using InventoryMVC.Helper;
using InventoryMVC.Models;
using InventoryMVC.Services;

namespace InventoryMVC.Controllers
{
    public class SupplierController : Controller
    {
        private readonly IClientService _services;
        public SupplierController(IClientService services)
        {
            _services = services;


        }
        public async Task<IActionResult> Index()
        {
            
            return View(await _services.GetSupplierData());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SupplierData supplier)
        {
            supplier.Products = new List<ProductData>();
            var result = _services.CreateSupplierData(supplier);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var suppliers = await _services.GetSupplierData(id);
            return View(suppliers);
        }

       

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            
            return View(await _services.GetSupplierData(id));

        }

        [HttpPost]
        public IActionResult Edit(SupplierData supplier)
        {
           
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            bool res = await _services.DeleteSupplierData(id);
            if (res)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
