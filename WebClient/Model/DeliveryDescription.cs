
namespace WebshopClient.Model
{
    public class DeliveryDescription
    {
        public int DeliveryId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public string PhoneNo { get; set; }
        public int CustomerId { get; set; }
    }
}