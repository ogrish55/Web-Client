using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebshopClient.CustomerServiceReference;
using WebshopClient.Model;
using WebshopClient.OrderServiceReference;
using WebshopClient.ProductLineServiceReference;

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

        public PaymentMethod ConvertFromServicePaymentMethodToClient(ServicePaymentMethod servicePaymentMethod)
        {
            PaymentMethod paymentMethod = new PaymentMethod();
            paymentMethod.PaymentMethodValue = servicePaymentMethod.PaymentMethodValue;
            paymentMethod.PMethodId = servicePaymentMethod.PMethodId;

            return paymentMethod;
        }
    }
}