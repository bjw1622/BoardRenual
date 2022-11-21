using System;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BoardRenual
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles); 
            GlobalConfiguration.Configuration.EnableCors();
            //var cors = new EnableCorsAttribute("http://localhost:3000", "*", "GET");
            //cors.SupportsCredentials = true;
        }
        //protected void Application_BeginRequest(Object sender, EventArgs s)
        //{
        //    if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
        //    {
        //        HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache");
        //        HttpContext.Current.Response.AddHeader("Access-Controle-Allow-Methods", "GET, POST");
        //        HttpContext.Current.Response.AddHeader("Access-Controle-Allow-Headers", "Content-Type,Accept,Cache-Control,Authoiriztion");
        //        HttpContext.Current.Response.AddHeader("Access-Controle-Max-Age", "17280000");
        //        HttpContext.Current.Response.End();
        //    }
        //}
        //private void EnableCrossDmainAjaxCall()
        //{
        //    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");

        //    if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
        //    {
        //        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
        //        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
        //        HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
        //        HttpContext.Current.Response.End();
        //    }
        //}
    }
}
