using System.Collections.Generic;
using WebshopClient.Model;
using WebshopClient.OrderServiceReference;
using WebshopClient.Utilities;

namespace WebshopClient.ServiceLayer
{
    public class OrderService
    {
        readonly ConvertDataModel Converter = new ConvertDataModel();

        public List<PaymentMethod> GetPaymentMethods()
        {
            List<PaymentMethod> listToReturn = new List<PaymentMethod>();
            using(CustomerOrderServiceClient proxy = new CustomerOrderServiceClient())
            {
                foreach (var item in proxy.GetPaymentMethods())
                {
                    listToReturn.Add(Converter.ConvertFromServicePaymentMethodToClient(item));
                }
            }

            return listToReturn;
        }

        public bool FinishCheckout(Order order)
        {
            bool success = false;
            using (CustomerOrderServiceClient proxy = new CustomerOrderServiceClient())
            {
                ServiceCustomerOrder orderToInsert = Converter.ConvertToServiceCustomerOrder(order);
                success = proxy.FinishCheckout(orderToInsert);
            }

            return success;
        }

        public decimal GetDiscount(string code)
        {
            decimal decimalToReturn;
            using (CustomerOrderServiceClient proxy = new CustomerOrderServiceClient()) {
                decimalToReturn = proxy.GetDiscountByCode(code);
            }
            return decimalToReturn;
        }




    }
}