using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApi_Front.Filters;
using TestApi_Front.Helper;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using TestApi_Front.Models.Sales;
using Newtonsoft.Json;

namespace TestApi_Front.Controllers
{
    [AuthenticationAttribute]
    public class HomeController : Controller
    {

        public ActionResult Index()
        {

            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}