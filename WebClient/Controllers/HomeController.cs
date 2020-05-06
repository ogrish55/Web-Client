using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebshopClient.Model;
using WebshopClient.Utilities;
using WebshopClient.ServiceLayer;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        readonly IConvertModel convertModel = new ConvertDataModel();
        readonly ProductService productService = new ProductService();


        public ActionResult Index(List<Product> filteredProducts)
        {
            List<Product> clientProducts;
            clientProducts = productService.GetAllProducts();
            return View(clientProducts);
        }

        public ActionResult ProductsInPriceRange(int min, int max)
        {
            List<Product> productsToReturn = productService.GetAllProductsInPriceRange(min, max);
            return View("Index", productsToReturn);
        }

        public ActionResult ProductsBasedOnBrand(string brandName)
        {
            List<Product> productsToReturn = productService.GetAllProductsBasedOnBrand(brandName);
            return View("Index", productsToReturn);
        }

        public ActionResult ProductsBasedOnCategory(string category)
        {
            List<Product> productsToReturn = productService.GetAllProductsBasedOnCategory(category);
            return View("Index", productsToReturn);
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