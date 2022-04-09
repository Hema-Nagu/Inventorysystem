using Microsoft.AspNetCore.Mvc;

using InventoryMVC.Models;
using InventoryMVC.Services;

namespace InventoryMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IClientService _services;
        private  List<ProductViewModel> _productCreateModels { get; set; }
        public ProductController(IClientService services)
        {
            _services = services;
            

        }
        public async Task<IActionResult> Index()
        {
            _productCreateModels = new List<ProductViewModel>();
            List<ProductData> product = new List<ProductData>();
            product = await _services.GetProduct();
            //var data = await _services.GetProductData();

            foreach(var p in product)
            {
                ProductViewModel pvModel=new ProductViewModel();
                pvModel.product = p;
                pvModel.Supplier= await _services.GetSupplierData(p.SupplierId);
                pvModel.Brand= await _services.GetBrandData(p.BrandId);
                pvModel.Category= await _services.GetCategoryData(p.CategoryId);
                _productCreateModels.Add(pvModel);
            }

            return View(_productCreateModels);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ProductCreateModel model= new ProductCreateModel();
            model.productData=new ProductData();
            model.brands= await _services.GetBrandData();
            model.categories = await _services.GetCategoryData();
            model.suppliers= await _services.GetSupplierData(); 
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {

            return View(await _services.GetSupplierData(id));
        }

        [HttpPost]
        public IActionResult Create(ProductCreateModel product)
        {
          
            var result = _services.CreateProductData(product.productData);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View(_productCreateModels);
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
            bool res = await _services.DeleteProductData(id);
            if (res)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
