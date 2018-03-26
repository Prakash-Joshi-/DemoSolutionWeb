using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApiDemo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
        }
        /*
         * http://stackoverflow.com/questions/14881828/how-to-prevent-multiple-asp-net-mvc-route-mappings
         
          
          
          
          
          
         * http://stackoverflow.com/questions/16691566/whats-the-difference-between-routecollection-and-route-table
         he RouteTable is a class that stores the URL routes for your application.

A RouteCollection provides a collection of route information to be used when mapping a URI to a controller action.

The RouteTable contains a property called Routes that will return a RouteCollection. The RouteTable uses a RouteCollection in order to store all the URL routing information it needs to accurately direct URI's to the correct controller action.
         
         * http://www.c-sharpcorner.com/interview-question/how-route-table-creates-in-mvc
         The RouteTable is a class that stores the URL routes for your application.A RouteCollection provides a collection of route information to be used when mapping a URI to a controller action.The RouteTable contains a property called Routes that will return a RouteCollection. The RouteTable uses a RouteCollection in order to store all the URL routing information it needs to accurately direct URI's to the correct controller action.In your global.asax you will register the routes that will map to various controller actions by specifying the following:///
/// Executed when the application starts. ///
protected void Application_Start() {RegisterRoutes(RouteTable.Routes); } Then a route will be added to the RouteCollection in the following way:///
/// Registers the routes used by the application. ///
/// Routes to register. public static void RegisterRoutes(RouteCollection routes) {routes.MapRoute("Error", "Error", new { controller = "Error", action = "Error" }); } This shows how the actual route information is stored in a RouteCollection, which in turn is referenced via the RouteTable.
         */
    }
}
