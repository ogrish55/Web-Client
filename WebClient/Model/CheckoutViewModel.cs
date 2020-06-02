using System.Collections.Generic;

namespace WebshopClient.Model
{
    public class CheckoutViewModel
    {
        public List<ProductLine> ShoppingCart { get; set; }
        public Customer Customer { get; set; }
        public Order Order { get; set; }
        public DeliveryDescription DeliveryDescription { get; set; }
        public List<PaymentMethod> PaymentMethods { get; set; }
        public Discount Discount { get; set; }

        public CheckoutViewModel()
        {
            Customer = new Customer();
            Order = new Order();
        }
    }

}