using System.ComponentModel.DataAnnotations;

namespace InventoryMVC.Models
{
    public class BrandData
    {
        [Display(Name ="Brand ID")]
        public int BrandId { get; set; }
        [Display(Name ="Brand Name")]
        public string BrandName { get; set; }   
        public virtual ICollection<ProductData> Products { get; set; }
    }
}
