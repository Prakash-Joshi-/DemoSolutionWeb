using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIDemoRoute.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        // http://www.c-sharpcorner.com/UploadFile/b1df45/web-api-route-and-route-prefix-part-2/
        //[Route("AllEmployees")]
        //[HttpGet]
        public List<Employee> GetEmployees()
        {
            List<Employee> _list = new List<Employee>();
            _list.Add(new Employee { EmployeeId = 1, EmployeeName = "Prakash" });
            _list.Add(new Employee { EmployeeId = 2, EmployeeName = "Prakash Joshi" });
            return _list;
        }
    }
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }
}
