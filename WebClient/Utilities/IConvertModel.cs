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
        Product ConvertFromServiceProduct(ServiceProduct serviceProduct);
        ServiceProduct ConvertToServiceProduct(Product webshopProduct);
        Order ConvertFromServiceOrder(ServiceCustomerOrder serviceOrder);
        ServiceCustomerOrder ConvertToServiceCustomerOrder(Order webshopOrder);
        Customer ConvertFromServiceCustomer(ServiceCustomer serviceCustomer);
        ServiceCustomer ConvertToServiceCustomer(Customer webshopCustomer);
    }
}
