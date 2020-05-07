using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebshopClient.Model
{
    public class PaymentMethod
    {

        public int PMethodId { get; set; }
        public string PaymentMethodValue { get; set; }
    }
}