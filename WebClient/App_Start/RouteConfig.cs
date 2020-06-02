using System.Web.Mvc;
using System.Web.Routing;

namespace WebClient
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "Order",
                url: "ShoppingCart/{action}/{id}",
                defaults: new { controller = "ShoppingCart", action = "Order", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Add",
                url: "ShoppingCart/{action}/{id}",
                defaults: new { controller = "ShoppingCart", action = "Add", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EmptyShoppingCart",
                url: "ShoppingCart/EmptyShoppingCart",
                defaults: new { controller = "ShoppingCart", action = "EmptyShoppingCart", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Delete",
                url: "ShoppingCart/Delete",
                defaults: new { controller = "ShoppingCart", action = "Delete", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "PriceRange",
                url: "Home/ProductsInPriceRange",
                defaults: new { controller = "Home", action = "ProductsInPriceRange" }
            );

        }
    }
}
