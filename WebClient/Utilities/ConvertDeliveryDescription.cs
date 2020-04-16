using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebshopClient.OrderServiceReference;
using WebshopClient.Model;

namespace WebshopClient.Utilities
{
    public class ConvertDeliveryDescription : IConvertDeliveryDescription
    {
        public DeliveryDescription ConvertFromServiceDeliveryDescription(ServiceDeliveryDescription serviceDeliveryDescription)
        {
            DeliveryDescription deliveryDescriptionToReturn = new DeliveryDescription();
            deliveryDescriptionToReturn.DeliveryId = serviceDeliveryDescription.DeliveryId;
            deliveryDescriptionToReturn.Name = serviceDeliveryDescription.Name;
            deliveryDescriptionToReturn.Address = serviceDeliveryDescription.Address;
            deliveryDescriptionToReturn.ZipCode = serviceDeliveryDescription.ZipCode;
            deliveryDescriptionToReturn.PhoneNo = serviceDeliveryDescription.PhoneNo;
            deliveryDescriptionToReturn.CustomerId = serviceDeliveryDescription.CustomerId;

            return deliveryDescriptionToReturn;
        }

        public ServiceDeliveryDescription ConvertToServiceDeliveryDescription(DeliveryDescription webshopDeliveryDescription)
        {
            ServiceDeliveryDescription deliveryDescriptionToReturn = new ServiceDeliveryDescription();
            deliveryDescriptionToReturn.DeliveryId = webshopDeliveryDescription.DeliveryId;
            deliveryDescriptionToReturn.Name = webshopDeliveryDescription.Name;
            deliveryDescriptionToReturn.Address = webshopDeliveryDescription.Address;
            deliveryDescriptionToReturn.ZipCode = webshopDeliveryDescription.ZipCode;
            deliveryDescriptionToReturn.PhoneNo = webshopDeliveryDescription.PhoneNo;
            deliveryDescriptionToReturn.CustomerId = webshopDeliveryDescription.CustomerId;

            return deliveryDescriptionToReturn;
        }
    }
}