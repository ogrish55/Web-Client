using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebshopClient.Model;
using WebshopClient.ServiceLayer;

namespace WebshopClient.Controllers
{
    public class ShoppingCartController : Controller
    {
        List<ProductLine> productLineList;
        CheckoutViewModel checkoutViewModel;
        OrderService orderService = new OrderService();
        CustomerService customerService = new CustomerService();

        [HttpPost]
        public ActionResult Add(Product product)
        {
            if (Session["shoppingCart"] == null) // If no shoppingCart has been created, create new shoppingCart and add product to it
            {
                productLineList = new List<ProductLine>();

                ProductLine productLine = new ProductLine
                {
                    Amount = 1,
                    SubTotal = product.Price,
                    Product = product
                };
                productLineList.Add(productLine);

                Session["shoppingCart"] = productLineList;
            }

            else // if shoppingCart has been created previously, add product to shoppingCart
            {
                productLineList = (List<ProductLine>)Session["shoppingCart"];

                bool found = false;

                foreach (ProductLine productLine in productLineList)
                {
                    if (productLine.Product.ProductId == product.ProductId) // if the product is the same as one of the products in the shoppingCart, increment amount by 1 and update Subtotal.
                    {
                        productLine.Amount++;
                        productLine.SubTotal *= productLine.Amount;
                        found = true;
                    }
                }

                if (!found) // if the product is not in the shoppingCart already, add the product to the shoppingCart.
                {
                    ProductLine productLine = new ProductLine
                    {
                        Amount = 1,
                        SubTotal = product.Price,
                        Product = product
                    };

                    productLineList.Add(productLine);
                }

                Session["shoppingCart"] = productLineList;
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Order()
        {
            checkoutViewModel = new CheckoutViewModel();
            checkoutViewModel.ShoppingCart = (List<ProductLine>)Session["shoppingCart"];
            return View(checkoutViewModel);
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
            checkoutViewModel = new CheckoutViewModel
            {
                DeliveryDescription = new DeliveryDescription(),
                ShoppingCart = (List<ProductLine>)Session["shoppingCart"],
                PaymentMethods = orderService.GetPaymentMethods(),
                Customer = customerService.GetCustomer((int)Session["CustomerId"])
            };
            return View(checkoutViewModel);
        }

        [HttpPost]
        public ActionResult CheckOut(CheckoutViewModel model)
        {
            model.Customer.CustomerId = (int)Session["CustomerID"];
            model.Order.ShoppingCart = (List<ProductLine>)Session["shoppingCart"];
            model.ShoppingCart = (List<ProductLine>)Session["shoppingCart"];
            model.Order.CustomerId = (int)Session["CustomerID"];

            bool success;
            {

                if (Session["DiscountCode"] != null)
                {
                    model.Order.DiscountCode = (string)Session["DiscountCode"];
                }
                success = orderService.FinishCheckout(model.Order);
            }
            if (success)
            {
                return RedirectToAction("CheckOutSuccessful", "ShoppingCart");
            }
            else
            {
                return View("ErrorPage");
            }
        }
    




        [HttpPost]
        public ActionResult AddDiscountCode(CheckoutViewModel model)
        {
            model.ShoppingCart = (List<ProductLine>)Session["shoppingCart"];

            if (ModelState.IsValid)
            {
                model.Discount.DiscountAmount = orderService.GetDiscount(model.Discount.DiscountCode); // set discount amount based on the discountCode inserted in paramter.
                if (model.Discount.DiscountAmount != 0 && Session["DiscountCodeAmount"] == null)
                {
                    Session["DiscountCodeAmount"] = model.Discount.DiscountAmount;
                    foreach (var item in model.ShoppingCart)
                    {
                        item.SubTotal = item.SubTotal * model.Discount.DiscountAmount;
                    }
                    Session["DiscountCode"] = model.Discount.DiscountCode;
                }
            }
            return RedirectToAction("CheckOut", "ShoppingCart");
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
                    productLineList[i].SubTotal = productLineList[i].SubTotal + productLineList[i].Product.Price;
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
                    productLineList[i].SubTotal = productLineList[i].SubTotal - productLineList[i].Product.Price;
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


        public ActionResult Login()
        {
            return View("Login");
        }


        public ActionResult CheckOutSuccessful()
        {
            string random = Guid.NewGuid().ToString();
            Session["shoppingCart"] = null;
            return View((object)random);
        }

    }
}

