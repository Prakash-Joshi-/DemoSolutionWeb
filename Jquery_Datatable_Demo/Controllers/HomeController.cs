using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jquery_Datatable_Demo.Models;

namespace Jquery_Datatable_Demo.Controllers
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
        public ActionResult GetCustomerData1()
        {
            return View();
        }
        public ActionResult GetCustomerData()
        {
            return View();
        }
        public ActionResult GetData()
        {
            using (TestDatabaseEntities db = new TestDatabaseEntities())
            {
                var CustomerData = db.CustomerDatas.OrderBy(a => a.Name).ToList();
                //return Json(new { data = CustomerData }, JsonRequestBehavior.AllowGet);
                
                //return new JsonResult { Data = CustomerData, MaxJsonLength = Int32.MaxValue, JsonRequestBehavior=JsonRequestBehavior.AllowGet };

                var jsonResult = Json(new { data = CustomerData }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
        }

        // Uncaught TypeError: Cannot read property 'length' of undefined
        //public ActionResult GetData()
        //{
        //    using (TestDatabaseEntities db= new TestDatabaseEntities())
        //    {
        //        var customerData = db.CustomerDatas.OrderBy(a => a.Name).ToList();
        //        return new ContentResult()
        //        {
        //            Content = Newtonsoft.Json.JsonConvert.SerializeObject(customerData),
        //            ContentType = "application/json"
        //        };
        //    }
        //}

        // Uncaught TypeError: Cannot read property 'length' of undefined
        //public ActionResult GetData()
        //{
        //    using (TestDatabaseEntities db= new TestDatabaseEntities())
        //    {
        //        var data = db.CustomerDatas.OrderBy(a => a.Name).ToList();
        //        return new JsonResult { Data = data, MaxJsonLength = Int32.MaxValue,JsonRequestBehavior=JsonRequestBehavior.AllowGet };
        //        return new JsonResult()
        //        {
        //            Data = data,
        //            MaxJsonLength = int.MaxValue,
        //            JsonRequestBehavior= JsonRequestBehavior.AllowGet
        //        };
        //    }
        //}
    }
}