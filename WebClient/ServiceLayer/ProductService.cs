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
                    if(productToInsert.Price >= min && productToInsert.Price <= max)
                    {
                        listToReturn.Add(productToInsert);
                    }
                }
            }
            return listToReturn;
        }

        public List<Product> GetAllProductsBasedOnBrand(string brand)
        {
            List<Product> listToReturn = new List<Product>();
            using (ProductLineServiceClient proxy = new ProductLineServiceClient())
            {
                foreach (var item in proxy.GetAllProducts().ToList())
                {
                    Product productToInsert = converter.ConvertFromServiceProduct(item);
                    if (productToInsert.Brand.Equals(brand))
                    {
                        listToReturn.Add(productToInsert);
                    }
                }
            }
            return listToReturn;
        }

        public List<Product> GetAllProductsBasedOnCategory(string category)
        {
            List<Product> listToReturn = new List<Product>();
            using (ProductLineServiceClient proxy = new ProductLineServiceClient())
            {
                foreach (var item in proxy.GetAllProducts().ToList())
                {
                    Product productToInsert = converter.ConvertFromServiceProduct(item);
                    if (productToInsert.Category.Equals(category))
                    {
                        listToReturn.Add(productToInsert);
                    }
                }
            }
            return listToReturn;
        }
    }
}