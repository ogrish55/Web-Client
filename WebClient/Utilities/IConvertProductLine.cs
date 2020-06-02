using WebshopClient.Model;
using WebshopClient.OrderServiceReference;

namespace WebshopClient.Utilities
{
    interface IConvertProductLine
    {
        ProductLine ConvertFromServiceProductLine(ServiceProductLine serviceProductLine);
        ServiceProductLine ConvertToServiceProductLine(ProductLine webshopProductLine);
    }
}
