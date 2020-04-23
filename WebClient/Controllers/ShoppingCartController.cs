using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebshopClient.Model;
using WebshopClient.CustomerServiceReference;
using WebshopClient.OrderServiceReference;
using WebshopClient.ProductLineServiceReference;
using WebshopClient.Utilities;

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
            using(CustomerOrderServiceClient proxy = new CustomerOrderServiceClient())
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
                model.ShoppingCart = (List<ProductLine>)Session["shoppingCart"];
                using (CustomerServiceClient customer = new CustomerServiceClient())
                using (CustomerOrderServiceClient order = new CustomerOrderServiceClient())
                using (ProductLineServiceClient productLine = new ProductLineServiceClient())
                {
                    int customerID = customer.InsertCustomer(new ConvertDataModel().ConvertToServiceCustomer(model.Customer));
                    model.Order.CustomerId = customerID;
                    {
                        int orderID = order.InsertOrder(new ConvertDataModel().ConvertToServiceCustomerOrder(model.Order));
                        model.Order.OrderId = orderID;
                        {
                            decimal totalPrice = 0;
                            foreach (var item in model.ShoppingCart)
                            {
                                totalPrice += item.SubTotal;
                                item.OrderId = orderID;
                                productLine.InsertProductLine(new ConvertProductLine().ConvertToServiceProductLine(item));
                            }
                            model.Order.FinalPrice = totalPrice;
                            order.UpdateOrder(new ConvertDataModel().ConvertToServiceCustomerOrder(model.Order));
                        }
                    }
                }

                return RedirectToAction("Index", "Home");
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

    }
}

