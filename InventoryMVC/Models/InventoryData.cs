using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryMVC.Models
{
    public class InventoryData
    {
        
        [Display(Name ="Inventory ID")]
        public int Id { get; set; }
        [Display(Name ="Product ID")]
        public int ProductId { get; set; }
        [Display(Name ="Stocks Available")]
        public int stock_product_quantity { get; set; }
    }
}
