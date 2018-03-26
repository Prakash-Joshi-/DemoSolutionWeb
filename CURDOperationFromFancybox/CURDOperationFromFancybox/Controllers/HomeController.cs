using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CURDOperationFromFancybox.Controllers
{
    [RoutePrefix("")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}