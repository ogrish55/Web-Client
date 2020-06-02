
namespace WebshopClient.Model
{
    public class ProductLine
    {
        public int ProductLineId { get; set; }
        public int Amount { get; set; }
        public decimal SubTotal { get; set; }
        public int OrderId { get; set; }
        public Product Product { get; set; }
    }
}