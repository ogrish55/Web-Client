using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebshopClient.CustomerServiceReference;
using WebshopClient.Model;
using WebshopClient.Utilities;

namespace WebshopClient.ServiceLayer
{
    public class CustomerService
    {
        ConvertDataModel Converter = new ConvertDataModel();

        public int InsertCustomer(Customer customer)
        {
            int id;
            using(CustomerServiceClient proxy = new CustomerServiceClient())
            {
                ServiceCustomer customerToInsert = Converter.ConvertToServiceCustomer(customer);
                id = proxy.InsertCustomer(customerToInsert);
            }
            return id;
        }

        public Customer GetCustomer(int id)
        {
            Customer customerToReturn;
            using(CustomerServiceClient proxy = new CustomerServiceClient())
            {
                ServiceCustomer customer = proxy.GetCustomer(id);
                customerToReturn = Converter.ConvertFromServiceCustomer(customer);
            }
            return customerToReturn;
        }

        public int VerifyCustomerLogin(string password, string email)
        {
            int customerID;

            using(CustomerServiceClient proxy = new CustomerServiceClient())
            {
                ServiceCustomer customer =  proxy.VerifyLogin(password, email);
                if(customer != null)
                {
                    customerID = customer.CustomerId;
                }
                else
                {
                    customerID = -1;
                }
            }

            return customerID;
        }
        
    }
}