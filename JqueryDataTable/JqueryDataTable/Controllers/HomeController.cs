using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JqueryDataTable.Models;
namespace JqueryDataTable.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        //It fetches Customer data from server
        public ActionResult GetData()
        {
            using(DatabaseEntities db=new DatabaseEntities())
            {
                var CustomerData = db.CustomerDatas.OrderBy(a=>a.Name).ToList();
                return Json(new { data=CustomerData },JsonRequestBehavior.AllowGet);
            }
        }
    }
}