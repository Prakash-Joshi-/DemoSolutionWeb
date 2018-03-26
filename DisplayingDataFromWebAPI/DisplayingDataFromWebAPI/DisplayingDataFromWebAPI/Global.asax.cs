using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace DisplayingDataFromWebAPI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        //protected void Application_BeginRequest()
        //{
        //    string[] allowedorigin = new string[] { "http://localhost:47495" };
        //    var origin = HttpContext.Current.Request.Headers["Origin"];
        //    if (origin != null && allowedorigin.Contains(origin))
        //    {
        //        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", origin);
        //        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET,POST");
        //    }
        //}

    }
}
