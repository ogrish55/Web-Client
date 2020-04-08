using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebshopClient.Model;
using WebshopClient.ProductServiceReference;

namespace WebshopClient.Utilities
{
    public class ConvertDataModel : IConvertModel
    {
        public Product ConvertFromServiceProduct(ServiceProduct serviceProduct)
        {
            Product productToReturn = new Product();
            productToReturn.Name = serviceProduct.Name;
            productToReturn.Price = serviceProduct.Price;
            productToReturn.Description = serviceProduct.Description;
            productToReturn.ProductId = serviceProduct.ProductId;
            productToReturn.AmountOnStock = serviceProduct.AmountOnStock;

            return productToReturn;
        }

        public ServiceProduct ConvertToServiceProduct(Product webshopProduct)
        {
            ServiceProduct productToReturn = new ServiceProduct();
            productToReturn.ProductId = webshopProduct.ProductId;
            productToReturn.Name = webshopProduct.Name;
            productToReturn.Price = webshopProduct.Price;
            productToReturn.Description = webshopProduct.Description;
            productToReturn.AmountOnStock = webshopProduct.AmountOnStock;

            return productToReturn;
        }
    }
}