using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autocomplete.Models;

namespace Autocomplete.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult Autocomplete(string term)
        {
            var result = new List<KeyValuePair<string, string>>();

            IList<SelectListItem> List = new List<SelectListItem>();
            List.Add(new SelectListItem { Text = "test1", Value = "0" });
            List.Add(new SelectListItem { Text = "test2", Value = "1" });
            List.Add(new SelectListItem { Text = "test3", Value = "2" });
            List.Add(new SelectListItem { Text = "test4", Value = "3" });

            foreach (var item in List)
            {

                result.Add(new KeyValuePair<string, string>(item.Value.ToString(), item.Text));
             

            }
            var result3 = result.Where(s => s.Value.ToLower().Contains(term.ToLower())).Select(w => w).ToList();
            return Json(result3, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult GetDetail(int id)
        {
            DemoModel model = new DemoModel();
           // select data by id here display static data;
            if (id == 0)
            {
                model.id = 1;
                model.name = "Yogesh Tyagi";
                model.mobile = "9460516787";

            }
            else {
                model.id = 2;
                model.name = "Pratham Tyagi";
                model.mobile = "9460516787";
            
            }

            return Json(model);
            
        }

    }
}
