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
        private List<Product> clientProducts;
        private List<Brand> brands;
        private List<Category> categories;
        private IndexViewModel indexViewModel;

        public HomeController()
        {
            clientProducts = productService.GetAllProducts();
            brands = (List<Brand>)productService.GetAllBrands();
            categories = (List<Category>)productService.GetAllCategories();
            indexViewModel = new IndexViewModel() { Products = clientProducts, Brands = brands, Categories = categories };
        }
        public ActionResult Index(List<Product> filteredProducts)
        {
            return View(indexViewModel);
        }

        public ActionResult ProductsInPriceRange(int min, int max)
        {
            List<Product> productsToReturn = productService.GetAllProductsInPriceRange(min, max);
            return View("Index", productsToReturn);
        }

        public ActionResult ProductsBasedOnBrand(int brandId)
        {
            List<Product> productsBasedOnBrand = productService.GetAllProductsBasedOnBrand(brandId);
            indexViewModel.Products = productsBasedOnBrand;
            return View("Index", indexViewModel);
        }

        public ActionResult ProductsBasedOnCategory(int categoryId)
        {
            List<Product> productsBasedOnCategory = productService.GetAllProductsBasedOnCategory(categoryId);
            indexViewModel.Products = productsBasedOnCategory;
            return View("Index", indexViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Markedets bedste priser";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Du er altid velkommen til at kontakte os";

            return View();
        }
    }
}