using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebshopClient.Model;
using WebshopClient.ServiceLayer;

namespace WebshopClient.Controllers
{
    public class LoginController : Controller
    {
        CustomerService customerService = new CustomerService();

        public ActionResult NewCustomer()
        {
             return View();
        }


        [HttpPost]
        public ActionResult NewCustomer(CheckoutViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.ShoppingCart = (List<ProductLine>)Session["shoppingCart"];

                model.Customer.CustomerId = customerService.InsertCustomer(model.Customer);
                Session["CustomerID"] = model.Customer.CustomerId;
                return RedirectToAction("CheckOut", "ShoppingCart");
            }
            else
            {
                return View();
            }
        }


        public ActionResult ExistingCustomerLogin(CheckoutViewModel model)
        {
            
            return View("ExistingCustomerLogin");
        }

    }
}