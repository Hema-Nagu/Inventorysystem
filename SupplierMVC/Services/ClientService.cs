
using Newtonsoft.Json;
using InventoryMVC.Helper;
using InventoryMVC.Models;

namespace InventoryMVC.Services
{
    public interface IClientService
    {
        #region GetAllMethods
        public Task<List<ProductData>> GetProduct();
        public Task<List<CategoryData>> GetCategoryData();

        public Task<List<BrandData>> GetBrandData();
        public  Task<List<SupplierData>> GetSupplierData();
        #endregion

        #region GetOneMethod
        public Task<ProductData> GetProductData(int id);
        public  Task<SupplierData> GetSupplierData(int id);
        public  Task<BrandData> GetBrandData(int id);
        public Task<CategoryData> GetCategoryData(int id);
        #endregion

        #region CreateOrPostData
        public bool CreateBrandData(BrandData brand);
        public bool CreateSupplierData(SupplierData supplier);
        public bool CreateCategoryData(CategoryData category);
        public bool CreateProductData(ProductData product);

        #endregion

        #region EditPostData
        public bool EditBrandData(BrandData brand);
        public bool EditSupplierData(SupplierData supplier);
        public bool EditCategoryData(CategoryData category);
        public bool EditProductData(ProductData product);
        #endregion

        #region DeleteData
        public Task<bool> DeleteProductData(int id);
        public Task<bool> DeleteSupplierData(int id);
        public Task<bool> DeleteBrandData(int id);
        public Task<bool> DeleteCategoryData(int id);
        #endregion

    }
    public class ClientService : IClientService
    {
        private string _productApi = "api/products";
        private string _InventoryAPI = "api/suppliers";
        private string _brandApi = "api/brands";
        private string _categoryApi = "api/categories";
        Supplier_API _api =new Supplier_API();


        #region GetAllData

        //Get All Product Data
        public async Task<List<ProductData>> GetProduct()
        {
            List<ProductData> product = new List<ProductData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync(_productApi);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<List<ProductData>>(result);
            }
            return product;
        }

        //Get All Supplier Data
        public async Task<List<SupplierData>> GetSupplierData()
        {
            List<SupplierData> suppliers = new List<SupplierData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync(_InventoryAPI);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                suppliers = JsonConvert.DeserializeObject<List<SupplierData>>(result);
            }
            return suppliers;
        }

        //Get All Brand Data
        public async Task<List<BrandData>> GetBrandData()
        {
            List<BrandData> brand = new List<BrandData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync(_brandApi);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                brand = JsonConvert.DeserializeObject<List<BrandData>>(result);
            }
            return brand;
        }

        //Get All Categories
        public async Task<List<CategoryData>> GetCategoryData()
        {
            List<CategoryData> category = new List<CategoryData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync(_categoryApi);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                category = JsonConvert.DeserializeObject<List<CategoryData>>(result);
            }
            return category;
        }

        #endregion

        #region GetParticularData

        //Get Particular Product Data
        public async Task<ProductData> GetProductData(int id)
        {
            ProductData product=new ProductData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync(_productApi);
            if (res.IsSuccessStatusCode)
            {
                var result=res.Content.ReadAsStringAsync().Result;
                product=JsonConvert.DeserializeObject<ProductData>(result);
            }
            return product;
        }

        //Get Particular Supplier Data
        public async Task<SupplierData> GetSupplierData(int id)
        {
            SupplierData supplier = new SupplierData();
            HttpClient client = _api.Initial();
            string sd = $"{_InventoryAPI}/{id}";
            HttpResponseMessage res = await client.GetAsync($"{_InventoryAPI}/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                supplier = JsonConvert.DeserializeObject<SupplierData>(result);
            }
            return supplier;
        }

        //Get Particular Brand Data
        public async Task<BrandData> GetBrandData(int id)
        {
            BrandData brand = new BrandData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"{_brandApi}/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                brand = JsonConvert.DeserializeObject<BrandData>(result);
            }
            return brand;
        }

       

        //Get Particular Category Data
        public async Task<CategoryData> GetCategoryData(int id)
        {
            CategoryData category = new CategoryData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"{_categoryApi}/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                category = JsonConvert.DeserializeObject<CategoryData>(result);
            }
            return category;
        }

        #endregion

        #region CreateData

        public bool CreateProductData(ProductData product)
        {
            HttpClient client = _api.Initial();

            var postTask = client.PostAsJsonAsync<ProductData>(_productApi, product);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public bool CreateBrandData(BrandData brand)
        {
            HttpClient client = _api.Initial();

            var postTask = client.PostAsJsonAsync<BrandData>(_brandApi, brand);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public bool CreateCategoryData(CategoryData category)
        {
            HttpClient client = _api.Initial();

            var postTask = client.PostAsJsonAsync<CategoryData>(_categoryApi, category);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public bool CreateSupplierData(SupplierData supplier)
        {
            HttpClient client = _api.Initial();

            var postTask = client.PostAsJsonAsync<SupplierData>(_InventoryAPI, supplier);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region Edit Data

        public bool EditBrandData(BrandData brand)
        {
            HttpClient client = _api.Initial();

            var postTask = client.PutAsJsonAsync<BrandData>($"{_brandApi}/{brand.BrandId}", brand);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public bool EditSupplierData(SupplierData supplier)
        {
            HttpClient client = _api.Initial();

            var postTask = client.PutAsJsonAsync<SupplierData>($"{_InventoryAPI}/{supplier.supplierId}", supplier);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public bool EditCategoryData(CategoryData category)
        {
            HttpClient client = _api.Initial();

            var postTask = client.PutAsJsonAsync<CategoryData>($"{_categoryApi}/{category.CategoryId}", category);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public bool EditProductData(ProductData product)
        {
            HttpClient client = _api.Initial();

            var postTask = client.PutAsJsonAsync<ProductData>($"{_productApi}/{product.product_Id}", product);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region Delete Data
        public async Task<bool> DeleteProductData(int id)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"{_productApi}/{id}");
            if (res.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteSupplierData(int id)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"{_InventoryAPI}/{id}");
            if (res.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteBrandData(int id)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"{_brandApi}/{id}");
            if (res.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteCategoryData(int id)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"{_categoryApi}/{id}");
            if (res.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        #endregion

    }

}
