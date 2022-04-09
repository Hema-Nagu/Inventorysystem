using Microsoft.AspNetCore.Mvc.Rendering;
using InventoryMVC.Models;

namespace InventoryMVC.Extensions
{
    public static class IEnumerableExtensions
    {

        public static IEnumerable<SelectListItem> ToSelectedListItem<T>(this IEnumerable<T> Items)
        {
            List<SelectListItem> List = new List<SelectListItem>();
            SelectListItem sl_item = new SelectListItem()
            {
                Text = "----Select----",
                Value = "0"
            };
            List.Add(sl_item);
            foreach (var item in Items)
            {
                sl_item = new SelectListItem()
                {
                    Text = item.GetPropertyValue("Name"),
                    Value = item.GetPropertyValue("Id")
                    //Text = item.GetType().GetProperty("Name").GetValue(item, null).ToString(),
                    //Value = item.GetType().GetProperty("Id").GetValue(item, null).ToString(),
                };
                List.Add(sl_item);
            }
            return List;
        }
        public static IEnumerable<SelectListItem> brandItem(IEnumerable<BrandData> items)
        {
            List<SelectListItem> List = new List<SelectListItem>();
            SelectListItem sl_item = new SelectListItem()
            {
                Text = "----Select----",
                Value = "0"
            };
            List.Add(sl_item);
            foreach (var item in items)
            {
                sl_item = new SelectListItem()
                {
                    Text = item.GetPropertyValue("BrandName"),
                    Value = item.GetPropertyValue("BrandId")
                    //Text = item.GetType().GetProperty("Name").GetValue(item, null).ToString(),
                    //Value = item.GetType().GetProperty("Id").GetValue(item, null).ToString(),
                };
                List.Add(sl_item);
            }
            return List;
        }
        public static IEnumerable<SelectListItem> categoryItem(IEnumerable<CategoryData> items)
        {
            List<SelectListItem> List = new List<SelectListItem>();
            SelectListItem sl_item = new SelectListItem()
            {
                Text = "----Select----",
                Value = "0"
            };
            List.Add(sl_item);
            foreach (var item in items)
            {
                sl_item = new SelectListItem()
                {
                    Text = item.GetPropertyValue("CategoryName"),
                    Value = item.GetPropertyValue("CategoryId")
                    //Text = item.GetType().GetProperty("Name").GetValue(item, null).ToString(),
                    //Value = item.GetType().GetProperty("Id").GetValue(item, null).ToString(),
                };
                List.Add(sl_item);
            }
            return List;
        }
        public static IEnumerable<SelectListItem> supplierItem(IEnumerable<SupplierData> items)
        {
            List<SelectListItem> List = new List<SelectListItem>();
            SelectListItem sl_item = new SelectListItem()
            {
                Text = "----Select----",
                Value = "0"
            };
            List.Add(sl_item);
            foreach (var item in items)
            {
                sl_item = new SelectListItem()
                {
                    Text = item.GetPropertyValue("supplierName"),
                    Value = item.GetPropertyValue("supplierId")
                    //Text = item.GetType().GetProperty("Name").GetValue(item, null).ToString(),
                    //Value = item.GetType().GetProperty("Id").GetValue(item, null).ToString(),
                };
                List.Add(sl_item);
            }
            return List;
        }
    }
}
