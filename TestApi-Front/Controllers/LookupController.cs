using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestApi_Front.Actions.Sales;
using TestApi_Front.Filters;
using TestApi_Front.Models.Sales;

namespace TestApi_Front.Controllers
{
    [AuthenticationAttribute]
    public class LookupController : Controller
    {
        // GET: Lookup
        public async Task<ActionResult> Index()
        {
            CustomerActions action = new CustomerActions();
            List<Customer> customers = await action.GetAll();

            return Json(new { draw = 1, recordsFiltered = customers, recordsTotal = customers.Count, data = customers });
        }

    }
}