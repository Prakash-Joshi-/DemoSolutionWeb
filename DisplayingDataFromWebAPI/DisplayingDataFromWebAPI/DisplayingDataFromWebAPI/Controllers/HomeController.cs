using DisplayingDataFromWebAPI.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace DisplayingDataFromWebAPI.Controllers
{
    public class HomeController : Controller
    {
        //Using Jquery
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult HttpClientView()
        {
            List<UserTable> lstUser = new List<UserTable>();
            HttpClient client = new HttpClient();
            var result = client.GetAsync("http://localhost:47495/api/WebAPI").Result;
            if (result.IsSuccessStatusCode)
            {
                lstUser = result.Content.ReadAsAsync<List<UserTable>>().Result;
            }
            return View(lstUser);
        }
    }
}