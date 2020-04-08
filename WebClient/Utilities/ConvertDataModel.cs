using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebshopClient.CustomerServiceReference;
using WebshopClient.Model;
using WebshopClient.OrderServiceReference;
using WebshopClient.ProductLineServiceReference;
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

        public ProductLine ConvertFromServiceProductLine(ServiceProductLine serviceProductLine)
        {
            ProductLine productLineToReturn = new ProductLine();
            productLineToReturn.ProductLineId = serviceProductLine.ProductLineId;
            productLineToReturn.Amount = serviceProductLine.Amount;
            productLineToReturn.SubTotal = serviceProductLine.SubTotal;
            productLineToReturn.OrderId = serviceProductLine.OrderId;
            productLineToReturn.ProductId = serviceProductLine.ProductId;

            return productLineToReturn;
        }

        public ServiceProductLine ConvertToServiceProductLine(ProductLine webshopProductLine)
        {
            ServiceProductLine productLineToReturn = new ServiceProductLine();
            productLineToReturn.ProductLineId = webshopProductLine.ProductLineId;
            productLineToReturn.Amount = webshopProductLine.Amount;
            productLineToReturn.SubTotal = webshopProductLine.SubTotal;
            productLineToReturn.OrderId = webshopProductLine.OrderId;
            productLineToReturn.ProductId = webshopProductLine.ProductId;

            return productLineToReturn;
        }

        public Order ConvertFromServiceOrder(ServiceCustomerOrder serviceOrder)
        {
            Order orderToReturn = new Order();
            orderToReturn.FinalPrice = serviceOrder.FinalPrice;
            orderToReturn.Status = serviceOrder.Status;
            orderToReturn.DateOrder = serviceOrder.DateOrder;
            orderToReturn.CustomerId = serviceOrder.CustomerId;
            orderToReturn.DiscountId = serviceOrder.DiscountId;
            orderToReturn.PaymentMethod = serviceOrder.PaymentMethod;

            return orderToReturn;
        }

        public ServiceCustomerOrder ConvertToServiceCustomerOrder(Order webshopOrder)
        {
            ServiceCustomerOrder orderToReturn = new ServiceCustomerOrder();
            orderToReturn.FinalPrice = webshopOrder.FinalPrice;
            orderToReturn.Status = webshopOrder.Status;
            orderToReturn.DateOrder = webshopOrder.DateOrder;
            orderToReturn.CustomerId = webshopOrder.CustomerId;
            orderToReturn.DiscountId = webshopOrder.DiscountId;
            orderToReturn.PaymentMethod = webshopOrder.PaymentMethod;

            return orderToReturn;
        }

        public Customer ConvertFromServiceCustomer(ServiceCustomer serviceCustomer)
        {
            Customer customerToReturn = new Customer();
            customerToReturn.CustomerId = serviceCustomer.CustomerId;
            customerToReturn.Name = serviceCustomer.Name;
            customerToReturn.Address = serviceCustomer.Address;
            customerToReturn.ZipCode = serviceCustomer.ZipCode;
            customerToReturn.PhoneNo = serviceCustomer.PhoneNo;

            return customerToReturn;
        }

        public ServiceCustomer ConvertToServiceCustomer(Customer webshopCustomer)
        {
            ServiceCustomer customerToReturn = new ServiceCustomer();
            customerToReturn.CustomerId = webshopCustomer.CustomerId;
            customerToReturn.Name = webshopCustomer.Name;
            customerToReturn.Address = webshopCustomer.Address;
            customerToReturn.ZipCode = webshopCustomer.ZipCode;
            customerToReturn.PhoneNo = webshopCustomer.PhoneNo;

            return customerToReturn;
        }
    }
}