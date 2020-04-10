using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebshopClient.Model;
using WebshopClient.ProductServiceReference;
using WebshopClient.Utilities;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        IConvertModel convertModel = new ConvertDataModel();
        public ActionResult Index()
        {
            List<Product> clientProducts = new List<Product>();

            using (ProductServiceClient productServiceProxy = new ProductServiceClient())
            {
                List<ServiceProduct> serviceProducts = new List<ServiceProduct>();
                serviceProducts = productServiceProxy.GetAllProducts().ToList();

                int i = 0;
                while (i < serviceProducts.Count())
                {
                    clientProducts.Add(convertModel.ConvertFromServiceProduct(serviceProducts[i]));
                    i++;
                }
            }
            return View(clientProducts);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}