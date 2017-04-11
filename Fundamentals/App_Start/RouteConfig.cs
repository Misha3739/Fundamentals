using System.Web.Mvc;
using System.Web.Routing;

namespace Fundamentals
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                 "Customers",
                 "{controller}/{action}/{id}",
                 new { controller = "Customers", action = "GetCustomer"},
                 new { id = @"\d"}
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
