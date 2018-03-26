using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WEB_API_Cache_Demo.Controllers
{
    [RoutePrefix("samples")]
    public class SampleController : ApiController
    {
        [HttpGet]
        [Route("date")]
        public IHttpActionResult GetDateAndNumber()
        {
            return Ok(new DateNumberObject());
        }
    }
}
