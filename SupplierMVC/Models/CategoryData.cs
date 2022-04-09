using System.ComponentModel.DataAnnotations;

namespace InventoryMVC.Models
{
    public class CategoryData
    {
        [Display(Name ="Category ID")]
        public int CategoryId { get; set; }
        [Display(Name ="Category Name")]
        public string CategoryName { get; set; }

        public virtual ICollection<ProductData> Products { get; set; }
    }
}
