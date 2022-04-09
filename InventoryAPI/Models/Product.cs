using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InventoryAPI.Models
{
    public class Product
    {
        [Key]
        public int product_Id { get; set; }
        public string product_Name { get; set; }
        public int BrandId { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public double product_price { get; set; }

       
        public virtual Inventory inventory { get; set; }
    }
}
