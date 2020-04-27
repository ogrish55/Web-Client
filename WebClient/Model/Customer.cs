using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebshopClient.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Customer {0} is required")]
        [StringLength (100, MinimumLength =3, ErrorMessage ="Name should be minimum 3 characters and a maximum of 100 characters")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [Required(ErrorMessage ="Zip code is required")]
        [DataType(DataType.PostalCode)]
        public int ZipCode { get; set; }

        [Required (ErrorMessage ="Phonenumber is required")]
        [DataType(DataType.PhoneNumber)]
        public int PhoneNo { get; set; }
    }
}