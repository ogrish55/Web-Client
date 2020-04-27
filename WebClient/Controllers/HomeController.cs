using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebshopClient.Model;
using WebshopClient.ProductLineServiceReference;
using WebshopClient.Utilities;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        IConvertModel convertModel = new ConvertDataModel();
        public ActionResult Index(List<Product> filteredProducts)
        {
            List<Product> clientProducts = new List<Product>();

            using (ProductLineServiceClient productServiceProxy = new ProductLineServiceClient())
            {
                List<ServiceProduct> serviceProducts = new List<ServiceProduct>();
                serviceProducts = productServiceProxy.GetAllProducts().ToList();

                int i = 0;
                while (i < serviceProducts.Count())
                {
                    clientProducts.Add(convertModel.ConvertFromServiceProduct(serviceProducts[i]));
                    i++;
                }
            }
            return View(clientProducts);
        }

        public ActionResult ProductsInPriceRange(int min, int max)
        {
            Debug.WriteLine("min: " + min + " max: " + max);
            List<Product> priceRangeProducts = new List<Product>();

            using (ProductLineServiceClient productServiceProxy = new ProductLineServiceClient())
            {
                List<ServiceProduct> serviceProducts = new List<ServiceProduct>();
                serviceProducts = productServiceProxy.GetAllProducts().ToList();
                int i = 0;
                while (i < serviceProducts.Count())
                {
                    if (serviceProducts[i].Price >= min && serviceProducts[i].Price <= max)
                    {
                        priceRangeProducts.Add(convertModel.ConvertFromServiceProduct(serviceProducts[i]));
                    }
                    i++;
                }
            }
            
            return View("Index",priceRangeProducts);
        }

        public ActionResult ProductsBasedOnBrand(string brandName)
        {
            List<Product> productsBasedOnBrand = new List<Product>();

            using (ProductLineServiceClient productServiceProxy = new ProductLineServiceClient())
            {
                List<ServiceProduct> serviceProducts = new List<ServiceProduct>();
                serviceProducts = productServiceProxy.GetAllProducts().ToList();

                int i = 0;
                while (i < serviceProducts.Count())
                {
                    if (serviceProducts[i].Brand.Equals(brandName))
                    {
                        productsBasedOnBrand.Add(convertModel.ConvertFromServiceProduct(serviceProducts[i]));
                    }
                    i++;
                }
            }

            return View("Index", productsBasedOnBrand);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}