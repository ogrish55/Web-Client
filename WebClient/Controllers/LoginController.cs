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
                Session["LoggedIn"] = true;
                return RedirectToAction("CheckOut", "ShoppingCart");
            }
            else
            {
                return View();
            }
        }


        public ActionResult ExistingCustomerLogin()
        {
            Customer customer = new Customer();
            return View(customer);
        }

        [HttpPost]
        public ActionResult ExistingCustomerLogin(Customer customer)
        {
            ModelState.Remove("Name");
            ModelState.Remove("Address");
            ModelState.Remove("PhoneNo");
            if (ModelState.IsValid)
            {
                int customerID = customerService.VerifyCustomerLogin(customer.Password, customer.Email);
                if(customerID > 0)
                {
                    Session["LoggedIn"] = true;
                    Session["CustomerID"] = customerID;
                    return RedirectToAction("Checkout", "ShoppingCart");
                }

                else
                {
                    ModelState.AddModelError(string.Empty, "Adgangskode eller Email er forkert");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

    }
}