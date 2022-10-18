using System.Web.Mvc;
using System.Web.Routing;

namespace BoardRenual
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // "Board/Detail/{No}"에 대한 Route
            routes.MapRoute(
                "Detail",
                "Board/Detail/{No}",
                new { controller = "Board", action = "Detail" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "LogIn", id = UrlParameter.Optional }
            );
        }
    }
}
