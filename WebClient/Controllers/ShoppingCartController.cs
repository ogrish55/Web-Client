using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebshopClient.Model;
using WebshopClient.ProductLineServiceReference;

namespace WebshopClient.Controllers
{
    public class ShoppingCartController : Controller
    {
        List<ProductLine> productLineList = new List<ProductLine>();

        [HttpPost]
        public ActionResult Add(Product product)
        {
            if (Session["shoppingCart"] == null)
            {
               // productLineList = new List<ProductLine>();

                ProductLine productLine = new ProductLine();
                productLine.Amount = 1;
                productLine.SubTotal = product.Price;
                productLine.Product = product;
                productLineList.Add(productLine);

                Session["shoppingCart"] = productLineList;
            }
            else
            {
                productLineList = (List<ProductLine>)Session["shoppingCart"];

                bool found = false;

                foreach (ProductLine productLine in productLineList)
                {
                    if (productLine.Product.ProductId == product.ProductId)
                    {
                        productLine.Amount = productLine.Amount + 1;
                        productLine.SubTotal = productLine.SubTotal * productLine.Amount;
                        found = true;
                    }
                }

                if (productLineList.Count() == 0 || !found)
                {
                    ProductLine productLine = new ProductLine();
                    productLine.Amount = 1;
                    productLine.SubTotal = product.Price;
                    productLine.Product = product;
                    productLineList.Add(productLine);
                }

                Session["shoppingCart"] = productLineList;
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Order()
        {
            return View((List<ProductLine>)Session["shoppingCart"]);
        }

        public ActionResult Delete(int id)
        {
            productLineList = (List<ProductLine>)Session["shoppingCart"];


            bool found = false;
            int i = 0;

            while (!found)
            {
                if (productLineList[i].Product.ProductId == id)
                {
                    productLineList.Remove(productLineList[i]);
                    found = true;
                }

                i++;
            }


            Session["shoppingCart"] = productLineList;

            return RedirectToAction("Order");
        }

        public ActionResult EmptyShoppingCart()
        {
            Session["shoppingCart"] = null;
            return RedirectToAction("Order", "ShoppingCart");
        }

        public ActionResult CheckOut()
        {
            return View((List<ProductLine>)Session["shoppingCart"]);
        }

        public ActionResult IncreaseAmount(int id)
        {
            productLineList = (List<ProductLine>)Session["shoppingCart"];

            bool found = false;
            int i = 0;

            while (!found)
            {
                if (productLineList[i].Product.ProductId == id)
                {
                    found = true;
                    productLineList[i].Amount += 1;
                }
                if (!found)
                {
                    i++;
                }
            }

            Session["shoppingCart"] = productLineList;
            return RedirectToAction("Order");
        }

        public ActionResult DecreaseAmount(int id)
        {
            productLineList = (List<ProductLine>)Session["shoppingCart"];

            bool found = false;
            int i = 0;
            ProductLine foundProductLine = null;

            while (!found)
            {
                if (productLineList[i].Product.ProductId == id)
                {
                    found = true;
                    productLineList[i].Amount -= 1;
                    foundProductLine = productLineList[i];
                }
                if (!found)
                {
                    i++;
                }
            }

            if (foundProductLine.Amount == 0)
            {
                productLineList.Remove(foundProductLine);
            }

            Session["shoppingCart"] = productLineList;
            return RedirectToAction("Order");
        }


    }
}

