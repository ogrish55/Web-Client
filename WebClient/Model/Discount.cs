
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebshopClient.Model
{
    public class Discount
    {
        [Required(ErrorMessage = "Den intastede rabat kode er ikke gyldig.")]
        [DataType(DataType.Text)]
        public string DiscountCode { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}