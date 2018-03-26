using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autocomplete1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public JsonResult GetServiceNames(string term)
        {
            var results = "";// db.Services.Where(s => term == null || s.ServiceName.ToLower().Contains(term.ToLower())).Select(x => new { id = x.ServiceID, value = x.ServiceName }).Take(5).ToList();

            return Json(results, JsonRequestBehavior.AllowGet);
        }
    }
}