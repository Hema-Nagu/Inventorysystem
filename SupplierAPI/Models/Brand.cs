using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        public string BrandName { get; set; }   
        public virtual ICollection<Product> Products { get; set; }
    }
}
