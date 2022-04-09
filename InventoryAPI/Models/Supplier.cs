using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.Models
{
    public class Supplier
    {
        [Key]
        public int supplierId { get; set; }
        public string supplierName { get; set; }
        public string supplierBulstat { get; set; }
        public string supplierAddress { get; set; }
        public string supplierEmail { get; set; }
        public string supplierPhone { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
