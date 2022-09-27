using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

            //// "Board/IndexPaging/{PageNumber}/{PageCount}"에 대한 Route
            //routes.MapRoute(
            //    "IndexPaging",
            //    "Board/IndexPaging/{PageNumber}/{PageCount}",
            //    new { controller = "Board", action = "IndexPaging" }
            //);

            ////"Board/Delete/{No}"에 대한 Route
            //routes.MapRoute(
            //    "Delete",
            //    "Board/Delete/{No}",
            //    new { controller = "Board", action = "Delete" }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "LogIn", id = UrlParameter.Optional }
            );
        }
    }
}
