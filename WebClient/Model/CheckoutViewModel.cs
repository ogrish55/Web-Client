﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebshopClient.Model
{
    public class CheckoutViewModel
    {
        public List<ProductLine> ShoppingCart { get; set; }
        public Customer Customer { get; set; }
        public Order Order { get; set; }
        public DeliveryDescription DeliveryDescription { get; set; }
        //public PaymentMethod PaymentMethod { get; set; }


    }
}