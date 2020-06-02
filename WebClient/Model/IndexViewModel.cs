using System.Collections.Generic;

namespace WebshopClient.Model
{
    public class IndexViewModel
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public List<Brand> Brands { get; set; }
        public IndexViewModel()
        {
            Products = new List<Product>();
            Categories = new List<Category>();
            Brands = new List<Brand>();
        }
    }
}