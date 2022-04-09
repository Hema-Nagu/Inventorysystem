using InventoryMVC.Models;

namespace InventoryMVC.Models
{
    public class ProductCreateModel
    {
        public ProductData productData { get; set; }
        public IEnumerable<CategoryData> categories { get; set; }
        public IEnumerable<SupplierData> suppliers { get; set; }
        public IEnumerable<BrandData> brands { get; set; }
    }
}
