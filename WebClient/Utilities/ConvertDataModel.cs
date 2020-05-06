using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using WebshopClient.CustomerServiceReference;
using WebshopClient.Model;
using WebshopClient.OrderServiceReference;
using WebshopClient.ProductLineServiceReference;

namespace WebshopClient.Utilities
{
    public class ConvertDataModel : IConvertModel
    {
        public Product ConvertFromServiceProduct(ProductLineServiceReference.ServiceProduct serviceProduct)
        {
            Product productToReturn = new Product();
            productToReturn.Name = serviceProduct.Name;
            productToReturn.Price = serviceProduct.Price;
            productToReturn.Description = serviceProduct.Description;
            productToReturn.ProductId = serviceProduct.ProductId;
            productToReturn.AmountOnStock = serviceProduct.AmountOnStock;
            productToReturn.Brand = serviceProduct.Brand;
            productToReturn.Category = serviceProduct.Category;

            return productToReturn;
        }

        public WebshopClient.ProductLineServiceReference.ServiceProduct ConvertToServiceProduct(Product webshopProduct)
        {
            WebshopClient.ProductLineServiceReference.ServiceProduct productToReturn = new WebshopClient.ProductLineServiceReference.ServiceProduct();
            productToReturn.ProductId = webshopProduct.ProductId;
            productToReturn.Name = webshopProduct.Name;
            productToReturn.Price = webshopProduct.Price;
            productToReturn.Description = webshopProduct.Description;
            productToReturn.AmountOnStock = webshopProduct.AmountOnStock;
            productToReturn.Brand = webshopProduct.Brand;
            productToReturn.Category = webshopProduct.Category;

            return productToReturn;
        }

        public Order ConvertFromServiceOrder(ServiceCustomerOrder serviceOrder)
        {
            Order orderToReturn = new Order();
            orderToReturn.FinalPrice = serviceOrder.FinalPrice;
            orderToReturn.Status = serviceOrder.Status;
            orderToReturn.DateOrder = serviceOrder.DateOrder;
            orderToReturn.CustomerId = serviceOrder.CustomerId;
            orderToReturn.DiscountCode = serviceOrder.DiscountCode;
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
            orderToReturn.DiscountCode = webshopOrder.DiscountCode;
            orderToReturn.PaymentMethod = webshopOrder.PaymentMethod;
            orderToReturn.OrderId = webshopOrder.OrderId;
            orderToReturn.ShoppingCart = new OrderServiceReference.ServiceProductLine[webshopOrder.ShoppingCart.Count];

            for (int i = 0; i < webshopOrder.ShoppingCart.Count; i++)
            {
                orderToReturn.ShoppingCart[i] = new ConvertProductLine().ConvertToServiceProductLine(webshopOrder.ShoppingCart[i]);
            }


            return orderToReturn;
        }

        public Customer ConvertFromServiceCustomer(CustomerServiceReference.ServiceCustomer serviceCustomer)
        {
            Customer customerToReturn = new Customer();
            customerToReturn.CustomerId = serviceCustomer.CustomerId;
            customerToReturn.Name = serviceCustomer.Name;
            customerToReturn.Address = serviceCustomer.Address;
            customerToReturn.ZipCode = serviceCustomer.ZipCode;
            customerToReturn.PhoneNo = serviceCustomer.PhoneNo;

            return customerToReturn;
        }

        //public OrderServiceReference.ServiceCustomer ConvertToServiceCustomer(Customer webshopCustomer)
        //{
        //    OrderServiceReference.ServiceCustomer customerToReturn = new OrderServiceReference.ServiceCustomer();
        //    customerToReturn.CustomerId = webshopCustomer.CustomerId;
        //    customerToReturn.Name = webshopCustomer.Name;
        //    customerToReturn.Address = webshopCustomer.Address;
        //    customerToReturn.ZipCode = webshopCustomer.ZipCode;
        //    customerToReturn.PhoneNo = webshopCustomer.PhoneNo;
        //    customerToReturn.Password = webshopCustomer.Password;
        //    customerToReturn.Email = webshopCustomer.Email;

        //    return customerToReturn;
        //}

        public CustomerServiceReference.ServiceCustomer ConvertToServiceCustomer(Customer webshopCustomer)
        {
            CustomerServiceReference.ServiceCustomer customerToReturn = new CustomerServiceReference.ServiceCustomer();
            customerToReturn.CustomerId = webshopCustomer.CustomerId;
            customerToReturn.Name = webshopCustomer.Name;
            customerToReturn.Address = webshopCustomer.Address;
            customerToReturn.ZipCode = webshopCustomer.ZipCode;
            customerToReturn.PhoneNo = webshopCustomer.PhoneNo;
            customerToReturn.Password = webshopCustomer.Password;
            customerToReturn.Email = webshopCustomer.Email;

            return customerToReturn;
        }

        public PaymentMethod ConvertFromServicePaymentMethodToClient(ServicePaymentMethod servicePaymentMethod)
        {
            PaymentMethod paymentMethod = new PaymentMethod();
            paymentMethod.PaymentMethodValue = servicePaymentMethod.PaymentMethodValue;
            paymentMethod.PMethodId = servicePaymentMethod.PMethodId;

            return paymentMethod;
        }

        public Discount ConvertFromServiceDiscount(ServiceDiscount serviceDiscount)
        {
            Discount discountToReturn = new Discount();
            discountToReturn.DiscountCode = serviceDiscount.DiscountCode;
            discountToReturn.DiscountAmount = serviceDiscount.DiscountAmount;

            return discountToReturn;
        }

        public ServiceDiscount ConvertToServiceDiscount(Discount webshopDiscount)
        {
            ServiceDiscount serviceDiscountToReturn = new ServiceDiscount();
            serviceDiscountToReturn.DiscountCode = webshopDiscount.DiscountCode;
            serviceDiscountToReturn.DiscountAmount = webshopDiscount.DiscountAmount;

            return serviceDiscountToReturn;
        }


        //Remember to uncomment

        //public Review ConvertFromServiceReviewToClient(ServiceReview serviceReview)
        //{
        //    Review review = new Review();
        //    review.Comment = serviceReview.Comment;
        //    review.Rating = serviceReview.Rating;

        //    return review;
        //}

        //public ServiceReview ConvertFromClientReviewToService(Review review)
        //{
        //    ServiceReview serviceReview = new ServiceReview();
        //    serviceReview.Comment = review.Comment;
        //    Service.Rating = review.Rating;

        //    return serviceReview;
        //}
    }
}