using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebshopClient.Model;
using WebshopClient.OrderServiceReference;

namespace WebshopClient.Utilities
{
    public class ConvertProductLine : IConvertProductLine
    {
        public ProductLine ConvertFromServiceProductLine(ServiceProductLine serviceProductLine)
        {
            ProductLine productLineToReturn = new ProductLine();
            productLineToReturn.ProductLineId = serviceProductLine.ProductLineId;
            productLineToReturn.Amount = serviceProductLine.Amount;
            productLineToReturn.SubTotal = serviceProductLine.SubTotal;
            productLineToReturn.OrderId = serviceProductLine.OrderId;
            productLineToReturn.Product = ConvertFromServiceProduct(serviceProductLine.Product);

            return productLineToReturn;
        }

        public ServiceProductLine ConvertToServiceProductLine(ProductLine webshopProductLine)
        {
            ServiceProductLine productLineToReturn = new ServiceProductLine();
            productLineToReturn.ProductLineId = webshopProductLine.ProductLineId;
            productLineToReturn.Amount = webshopProductLine.Amount;
            productLineToReturn.SubTotal = webshopProductLine.SubTotal;
            productLineToReturn.OrderId = webshopProductLine.OrderId;
            productLineToReturn.Product = ConvertToServiceProduct(webshopProductLine.Product);

            return productLineToReturn;
        }

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