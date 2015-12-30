using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Web.Api.Controllers
{
    public class HomeController : Controller
    {
        public HttpResponseMessage Index()
        {
            return new HttpResponseMessage() { StatusCode = HttpStatusCode.MethodNotAllowed };
        }
    }
}
