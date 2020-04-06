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
        List<ServiceProduct> productList;

        // GET: ShoppingCart
        public ActionResult Index()
        {
            IEnumerable<ServiceProduct> products;
            using (ProductServiceClient productServiceProxy = new ProductServiceClient())
            {
                products = productServiceProxy.GetAllProducts();
            }
            return View(products);
        }

        [HttpPost]
        public ActionResult Add(ServiceProduct product)
        {
            if (Session["shoppingCart"] == null)
            {
                productList = new List<ServiceProduct>();

                productList.Add(product);
                Session["shoppingCart"] = productList;
            }
            else
            {
                productList = (List<ServiceProduct>)Session["shoppingCart"];
                productList.Add(product);
                Session["shoppingCart"] = productList;
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Order()
        {
            return View((List<ServiceProduct>)Session["shoppingCart"]);
        }

        public ActionResult Delete(int id)
        {
            productList = (List<ServiceProduct>)Session["shoppingCart"];

            bool found = false;
            int i = 0;

            while (!found)
            {
                if (productList[i].ProductId == id)
                {
                    productList.Remove(productList[i]);
                    found = true;
                }

                i++;
            }

            Session["shoppingCart"] = productList;

            return RedirectToAction("Order");
        }
    }
}


