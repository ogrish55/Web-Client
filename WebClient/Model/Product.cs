﻿
namespace WebshopClient.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int AmountOnStock { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
    }
}