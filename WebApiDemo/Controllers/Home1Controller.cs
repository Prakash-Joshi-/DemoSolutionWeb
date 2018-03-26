using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
//using System.Web.Mvc;

namespace WebApiDemo.Controllers
{
    public class Home1Controller : ApiController
    {
        public String Index()
        {
           

            return "";
        }
        [ActionName("Index1")]
        public String Index(string id)
        {
            

            return "";
        }


        // GET api/values
        //[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public IEnumerable<string> Get(string queryString)
        {
            return new string[] { "value3", "value4" };
        }
        public IEnumerable<string> Get(string queryString, string queryString2)
        {
            return new string[] { "value3", "value4" };
        }
        public IEnumerable<string> Get1()
        {
            return new string[] { "value1", "value2" };
        }

        public IEnumerable<string> Get1(string queryString)
        {
            return new string[] { "value3", "value4" };
        }
    }
}
