using Fetch_and_display_data_from_WEBAPI_in_ASP.NET_MVC.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace Fetch_and_display_data_from_WEBAPI_in_ASP.NET_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //http://www.mitechdev.com/2016/08/how-to-fetch-and-display-data-from-webapi.html
            return View();
        }

        public ActionResult HttpClientView()
        {
            List<UserTable> userList = new List<UserTable>();
            HttpClient client = new HttpClient();
            var result = client.GetAsync("http://localhost:53120/api/UserTable").Result;
            if (result.IsSuccessStatusCode)
            {
                userList = result.Content.ReadAsAsync<List<UserTable>>().Result;
            }
            return View(userList);
        }
    }
}