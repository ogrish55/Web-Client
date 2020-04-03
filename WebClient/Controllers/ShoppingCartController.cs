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

            if (Session["shoppingCart"] == null)
            {
                productList = new List<ServiceProduct>();

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
                productList = (List<ServiceProduct>)Session["shoppingCart"];

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

