using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InventoryMVC.Models
{
    public class ProductData
    {
        [Display(Name ="Product ID")]
        public int product_Id { get; set; }
        [Display(Name ="Product Name")]
        public string product_Name { get; set; }
        public int BrandId { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        [Display(Name ="Price")]
        public double product_price { get; set; }

       
        public virtual InventoryData inventory { get; set; }
    }
}
