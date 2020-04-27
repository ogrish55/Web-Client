using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebshopClient.Model
{
    public class Order
    {
        public decimal FinalPrice { get; set; }
        public string Status { get; set; }
        public DateTime DateOrder { get; set; }
        public int CustomerId { get; set; }
        public string DiscountCode { get; set; }
        public int PaymentMethod { get; set; }
        public List<ProductLine> ShoppingCart;
        public int OrderId { get; set; }

        public Order()
        {
            DateOrder = DateTime.Now;
            this.Status = "Active";
        }
    }
}