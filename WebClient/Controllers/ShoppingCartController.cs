using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebshopClient.ProductServiceReference;

namespace WebshopClient.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            IEnumerable<Product> products;
            using (ProductServiceClient productServiceProxy = new ProductServiceClient())
            {
                products = productServiceProxy.GetAllProducts();
            }
            return View(products);
        }
    }
}