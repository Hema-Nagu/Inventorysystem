using InventoryAPI.Models;

namespace InventoryAPI.Data
{
    public static class DBInitializer
    {
        public static void Initializer(SupplierDBContext context)
        {
            if (!context.Categories.Any())
            {
                List<Category> category = new List<Category>()
                {
                    new Category{CategoryName="Beverages"},
                    new Category{CategoryName="Condiments"},
                    new Category{CategoryName="Congections"},
                    new Category{CategoryName="Dairy Products"},
                    new Category{CategoryName="Grains/Cereals"},
                    new Category{CategoryName="Meat/Poultry"},
                    new Category{CategoryName="Produce"},
                    new Category{CategoryName="Seafood"},
                };
                context.Categories.AddRange(category);
                context.SaveChanges();
            }
            if (!context.Brands.Any())
            {
                List<Brand> brands = new List<Brand>() {
                    new Brand{BrandName="Nestle"},
                    new Brand{BrandName="SunFeast"},
                    new Brand{BrandName="Cadbery"},
                    new Brand{BrandName="HUL"},
                };

                context.Brands.AddRange(brands);
                context.SaveChanges();
            }
            if (!context.Suppliers.Any()) {
                List<Supplier> suppliers = new List<Supplier>() {
                    new Supplier{
                        supplierName="Deepak",
                        supplierEmail="deepakraj@gmail.com",
                        supplierPhone="1234567890",
                        supplierAddress="Madurai",
                        supplierBulstat="118585306",

                    },new Supplier{
                        supplierName="Dharani",
                        supplierEmail="dharani@gmail.com",
                        supplierPhone="1234567890",
                        supplierAddress="Coimbatore",
                        supplierBulstat="118585305",

                    },new Supplier{
                        supplierName="Vinil",
                        supplierEmail="vinil@gmail.com",
                        supplierPhone="1234567890",
                        supplierAddress="Tirunelveli",
                        supplierBulstat="118585303",

                    },new Supplier{
                        supplierName="Sudharshan",
                        supplierEmail="sudharshan@gmail.com",
                        supplierPhone="1234567890",
                        supplierAddress="Theni",
                        supplierBulstat="118585302",

                    },new Supplier{
                        supplierName="Suwathi",
                        supplierEmail="suwathi@gmail.com",
                        supplierPhone="1234567890",
                        supplierAddress="Tirupur",
                        supplierBulstat="118585301",

                    },
                };
                context.Suppliers.AddRange(suppliers);
                context.SaveChanges();
            }


        }

    }
}
