using System.Web.Mvc;
using System.Web.Routing;

namespace FirstWebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{lang}/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "AllRegistratedOnGameUsers", lang = "ru", id = UrlParameter.Optional },
                constraints: new {lang = @"^[a-zA-Z]{2}$"}

            );
        }
    }
}