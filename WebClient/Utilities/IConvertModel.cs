using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopClient.CustomerServiceReference;
using WebshopClient.Model;
using WebshopClient.OrderServiceReference;
using WebshopClient.ProductLineServiceReference;

namespace WebshopClient.Utilities
{
    interface IConvertModel
    {
        Product ConvertFromServiceProduct(ProductLineServiceReference.ServiceProduct serviceProduct);
        ProductLineServiceReference.ServiceProduct ConvertToServiceProduct(Product webshopProduct);
        Order ConvertFromServiceOrder(ServiceCustomerOrder serviceOrder);
        ServiceCustomerOrder ConvertToServiceCustomerOrder(Order webshopOrder);
        Customer ConvertFromServiceCustomer(CustomerServiceReference.ServiceCustomer serviceCustomer);
        OrderServiceReference.ServiceCustomer ConvertToServiceCustomer(Customer webshopCustomer);
        Discount ConvertFromServiceDiscount(ServiceDiscount serviceDiscount);
        ServiceDiscount ConvertToServiceDiscount(Discount webshopDiscount);
    }
}
