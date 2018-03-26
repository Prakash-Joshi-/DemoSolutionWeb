using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApiDemo.Controllers
{
    public class HomeController : Controller
    {
        /*
        The current request for action 'Index' on controller type 'HomeController' is ambiguous between the following action methods:
System.Web.Mvc.ActionResult Index() on type WebApiDemo.Controllers.HomeController
System.Web.Mvc.ActionResult Index(System.String) on type WebApiDemo.Controllers.HomeController


        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Index(string id)
        {
            ViewBag.Title = "Home Page";

            return View();
        }
         
        */
        [NonAction]
        public ActionResult Index2()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [ActionName("Index1")] // home/index1
        public ActionResult Index(string id)
        {
            string str = null;
            int str2 = str.Length;
            string str1 = str.Length > 32 ? str.Substring(0, 32) : str;
            ViewBag.Title = "Home Page";

            return View();
        }
        [Authorize]
        public ActionResult Index(int? id)
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Index3()
        {
            Int16 X = 10;
            //System.ValueType = new System.ValueType();
            int? x = null;
            int y = x ?? 0;
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    int ? z = GetNullableInt();
                    if (z == null)
                        throw new Exception();
                    int j = GetNullableInt() ?? default(int);
                    string s = GetStringNullValue();
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
            ViewBag.Title = "Home Page";

            return View();
        }
        static int? GetNullableInt()
        {
            return null;
        }
        static string GetStringNullValue()
        {
            return null;
        }

        [ActionName("Index3")]
        public ActionResult Index4()
        {
            return View();
        }

        [ActionName("blah")]
        public ActionResult Index5()
        {
            return View();
        }

        [Route("users/about")] //route" /users/about
        public ActionResult Index6()
        {
            return View();
        }
    }
}
