using WebshopClient.OrderServiceReference;
using WebshopClient.Model;

namespace WebshopClient.Utilities
{
    interface IConvertDeliveryDescription
    {
        DeliveryDescription ConvertFromServiceDeliveryDescription(ServiceDeliveryDescription serviceDeliveryDescription);
        ServiceDeliveryDescription ConvertToServiceDeliveryDescription(DeliveryDescription webshopDeliveryDescription);
    }
}
