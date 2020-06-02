using System.ComponentModel.DataAnnotations;

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
        public string PhoneNo { get; set; }

        [Required (ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required (ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string City { get; set; }
    }
}