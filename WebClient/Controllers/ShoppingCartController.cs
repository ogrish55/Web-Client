﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebshopClient.Model;
using WebshopClient.CustomerServiceReference;
using WebshopClient.OrderServiceReference;
using WebshopClient.ProductLineServiceReference;
using WebshopClient.Utilities;
using System.Diagnostics;

namespace WebshopClient.Controllers
{
    public class ShoppingCartController : Controller
    {
        List<ProductLine> productLineList;
        CheckoutViewModel checkoutViewModel;

        [HttpPost]
        public ActionResult Add(Product product)
        {
            if (Session["shoppingCart"] == null)
            {
                productLineList = new List<ProductLine>();

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
            checkoutViewModel = new CheckoutViewModel();
            checkoutViewModel.DeliveryDescription = new DeliveryDescription();
            checkoutViewModel.ShoppingCart = (List<ProductLine>)Session["shoppingCart"];
            using (CustomerOrderServiceClient proxy = new CustomerOrderServiceClient())
            {
                List<PaymentMethod> listToAdd = new List<PaymentMethod>();
                foreach (var item in proxy.GetPaymentMethods())
                {
                    listToAdd.Add(new ConvertDataModel().ConvertFromServicePaymentMethodToClient(item));
                }
                checkoutViewModel.PaymentMethods = listToAdd;
            }
            return View(checkoutViewModel);
        }

        [HttpPost]
        public ActionResult CheckOut(CheckoutViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool success = false;
                model.Order.ShoppingCart = (List<ProductLine>)Session["shoppingCart"];
                model.ShoppingCart = (List<ProductLine>)Session["shoppingCart"];
                using (CustomerOrderServiceClient order = new CustomerOrderServiceClient())
                {
                    OrderServiceReference.ServiceCustomer customerToInsert = new ConvertDataModel().ConvertToServiceCustomer(model.Customer);
                    ServiceCustomerOrder orderToInsert = new ConvertDataModel().ConvertToServiceCustomerOrder(model.Order);
                    if (Session["DiscountCode"] != null)
                    {
                        orderToInsert.DiscountCode = (string)Session["DiscountCode"];
                    }
                    success = order.FinishCheckout(customerToInsert, orderToInsert);
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
            else
            {
                using (CustomerOrderServiceClient proxy = new CustomerOrderServiceClient())
                {
                    List<PaymentMethod> listToAdd = new List<PaymentMethod>();
                    foreach (var item in proxy.GetPaymentMethods())
                    {
                        listToAdd.Add(new ConvertDataModel().ConvertFromServicePaymentMethodToClient(item));
                    }
                    model.PaymentMethods = listToAdd;
                }
                model.ShoppingCart = (List<ProductLine>)Session["shoppingCart"];
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult AddDiscountCode(CheckoutViewModel model)
        {
            model.ShoppingCart = (List<ProductLine>)Session["shoppingCart"];
            string code = model.Discount.DiscountCode;

            if (ModelState.IsValid)
            {
                using (CustomerOrderServiceClient order = new CustomerOrderServiceClient())
                {
                    decimal discountAmount = order.GetDiscountByCode(code);
                    model.Discount.DiscountAmount = discountAmount;
                }
                if (model.Discount.DiscountAmount != 0 && Session["DiscountCodeAmount"] == null)
                {
                    //model.Order.DiscountCode = code;
                    Session["DiscountCodeAmount"] = model.Discount.DiscountAmount;
                    using (ProductLineServiceClient productline = new ProductLineServiceClient())
                    {
                        foreach (var item in model.ShoppingCart)
                        {
                            item.SubTotal *= model.Discount.DiscountAmount;
                        }
                    }
                    Session["DiscountCode"] = code;
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

        public ActionResult CheckOutSuccessful()
        {
            string random = Guid.NewGuid().ToString();
            Session["shoppingCart"] = null;
            return View((object)random);
        }
    }
}

