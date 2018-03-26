using DisplayingDataFromWebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DisplayingDataFromWebAPI.Controllers
{
    public class WebAPIController : ApiController
    {
        public HttpResponseMessage Get()
        {
            using (WebAPIDBEntities db = new WebAPIDBEntities())
            {
                List<UserTable> userlist = new List<UserTable>();
                userlist = db.UserTables.OrderBy(a => a.UserID).ToList();
                HttpResponseMessage response;
                response = Request.CreateResponse(HttpStatusCode.OK,userlist);
                return response;
            }
        }

    }
}
