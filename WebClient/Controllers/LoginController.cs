using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebshopClient.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult NewCustomer()
        {
            return View("NewCustomer");
        }

        public ActionResult ExistingCustomerLogin()
        {
            return View("ExistingCustomerLogin");
        }

    }
}