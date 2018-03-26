using Fetch_and_display_data_from_WEBAPI_in_ASP.NET_MVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fetch_and_display_data_from_WEBAPI_in_ASP.NET_MVC.Controllers
{
    public class UserTableController : ApiController
    {
        public HttpResponseMessage Get()
        {
            using (UserDatabaseEntities db = new UserDatabaseEntities())
            {
                List<UserTable> userList = new List<UserTable>();
                userList = db.UserTables.OrderBy(a => a.UserID).ToList();
                HttpResponseMessage responseMessage;
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, userList);
                return responseMessage;

            }
        }
    }
}
