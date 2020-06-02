using System.Collections.Generic;
using System.Linq;
using WebshopClient.Model;
using WebshopClient.ProductLineServiceReference;
using WebshopClient.Utilities;

namespace WebshopClient.ServiceLayer
{
    public class ProductService
    {
        readonly ConvertDataModel converter = new ConvertDataModel();

        public List<Product> GetAllProducts()
        {
            List<Product> listToReturn = new List<Product>();
            using (ProductLineServiceClient proxy = new ProductLineServiceClient())
            {
                foreach (var item in proxy.GetAllProducts().ToList())
                {
                    Product productToInsert = converter.ConvertFromServiceProduct(item);
                    listToReturn.Add(productToInsert);
                }
            }
            return listToReturn;
        }

        public List<Product> GetAllProductsInPriceRange(int min, int max)
        {
            List<Product> listToReturn = new List<Product>();
            using (ProductLineServiceClient proxy = new ProductLineServiceClient())
            {
                foreach (var item in proxy.GetAllProducts().ToList())
                {
                    Product productToInsert = converter.ConvertFromServiceProduct(item);
                    if (productToInsert.Price >= min && productToInsert.Price <= max)
                    {
                        listToReturn.Add(productToInsert);
                    }
                }
            }
            return listToReturn;
        }

        public List<Product> GetAllProductsBasedOnBrand(int brandId)
        {
            List<Product> listToReturn = new List<Product>();

            using (ProductLineServiceClient proxy = new ProductLineServiceClient())
            {
                foreach (var item in proxy.GetAllProducts().ToList())
                {
                    if (item.BrandId == brandId)
                    {
                        listToReturn.Add(converter.ConvertFromServiceProduct(item));
                    }
                }
            }
            return listToReturn;
        }

        public List<Product> GetAllProductsBasedOnCategory(int categoryId)
        {
            List<Product> listToReturn = new List<Product>();

            using (ProductLineServiceClient proxy = new ProductLineServiceClient())
            {
                foreach (var item in proxy.GetAllProducts().ToList())
                {
                    if (item.CategoryId == categoryId)
                    {
                        listToReturn.Add(converter.ConvertFromServiceProduct(item));
                    }
                }
            }
            return listToReturn;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            using (ProductLineServiceClient productProxy = new ProductLineServiceClient())
            {
                foreach (var item in productProxy.GetAllCategories().ToList())
                {
                    Category category = converter.ConvertFromServiceCategory(item);
                    categories.Add(category);
                }
            }
            return categories;
        }

        public IEnumerable<Brand> GetAllBrands()
        {
            List<Brand> brands = new List<Brand>();
            using (ProductLineServiceClient productProxy = new ProductLineServiceClient())
            {
                foreach (var item in productProxy.GetAllBrands().ToList())
                {
                    Brand brand = converter.ConvertFromServiceBrand(item);
                    brands.Add(brand);
                }
            }
            return brands;
        }
    }
}