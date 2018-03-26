using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApiDemo.Controllers
{
    [RoutePrefix("foo")]
    [Route("{action=index}")] //default action 
    public class DefaultController : Controller
    {
        // GET: Default
        //new route: /foo/Index
        public ActionResult Index()
        {
            return View();
        }
        //new route: /foo/Index1
        public ActionResult Index1()
        {
            return View();
        }
        //new route: /foo/Index2
        public ActionResult Index2()
        {
            return View();
        }
    }
}