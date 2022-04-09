namespace InventoryMVC.Models
{
    public class ProductViewModel
    {
        public ProductData product { get; set; }
        public SupplierData Supplier { get; set; }
        public BrandData Brand { get; set; }
        public CategoryData Category { get; set; }
        public InventoryData Inventory { get; set; }

    }
}
