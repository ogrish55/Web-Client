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

        [HttpPost]
        public ActionResult Add(Product product)
        {
            if (Session["shoppingCart"] == null)
            {
                List<Product> list = new List<Product>();

                list.Add(product);
                Session["shoppingCart"] = list;
            }
            else
            {
                List<Product> list = (List<Product>)Session["shoppingCart"];
                list.Add(product);
                Session["shoppingCart"] = list;
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Order()
        {

            return View((List<Product>)Session["shoppingCart"]);

        }
    }
}