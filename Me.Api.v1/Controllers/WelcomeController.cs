using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Me.Api.v1.Controllers
{
    [RoutePrefix("")]
    public class WelcomeController : ApiController
    {
        [Route("")]
        [HttpGet]
        public HttpResponseMessage Welcome()
        {
            var res = Request.CreateResponse(HttpStatusCode.OK);
            res.Content = new StringContent("<h1>Welcome, who are you?</h1>", Encoding.UTF8, "text/html");
            return res;
        }
    }
}
