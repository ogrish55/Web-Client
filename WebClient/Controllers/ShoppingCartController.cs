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
        List<Product> productList;

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
                productList = new List<Product>();

                productList.Add(product);
                Session["shoppingCart"] = productList;
            }
            else
            {
                productList = (List<Product>)Session["shoppingCart"];
                productList.Add(product);
                Session["shoppingCart"] = productList;
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Order()
        {
            return View((List<Product>)Session["shoppingCart"]);

        }

        public ActionResult Delete(int id)
        {

            if (Session["shoppingCart"] == null)
            {
                productList = new List<Product>();

                for (int i = 0; i < productList.Count(); i++)
                {
                    if (productList[i].ProductId == id)
                    {
                        productList.Remove(productList[i]);
                    }
                }
                Session["shoppingCart"] = productList;
            }
            else
            {
                productList = (List<Product>)Session["shoppingCart"];

                for (int i = 0; i < productList.Count(); i++)
                {
                    if (productList[i].ProductId == id)
                    {
                        productList.Remove(productList[i]);
                    }
                }
                Session["shoppingCart"] = productList;
            }

            for (int i = 0; i < productList.Count(); i++)
            {
                if (productList[i].ProductId == id)
                {
                    productList.Remove(productList[i]);
                }
            }

            return RedirectToAction("Order");
        }
    }
}

