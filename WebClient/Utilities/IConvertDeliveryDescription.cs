using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
