using WebshopClient.Model;
using WebshopClient.OrderServiceReference;


namespace WebshopClient.Utilities
{
    interface IConvertModel
    {
        Product ConvertFromServiceProduct(ProductLineServiceReference.ServiceProduct serviceProduct);
        ProductLineServiceReference.ServiceProduct ConvertToServiceProduct(Product webshopProduct);
        Order ConvertFromServiceOrder(ServiceCustomerOrder serviceOrder);
        ServiceCustomerOrder ConvertToServiceCustomerOrder(Order webshopOrder);
        Customer ConvertFromServiceCustomer(CustomerServiceReference.ServiceCustomer serviceCustomer);
        CustomerServiceReference.ServiceCustomer ConvertToServiceCustomer(Customer webshopCustomer);
        Discount ConvertFromServiceDiscount(ServiceDiscount serviceDiscount);
        ServiceDiscount ConvertToServiceDiscount(Discount webshopDiscount);
    }
}
