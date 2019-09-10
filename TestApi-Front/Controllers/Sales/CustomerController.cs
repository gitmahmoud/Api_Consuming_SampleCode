using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestApi_Front.Actions.BasicData;
using TestApi_Front.Actions.Sales;
using TestApi_Front.Filters;
using TestApi_Front.Models.Sales;
using System.Net;

namespace TestApi_Front.Controllers.Sales
{

    [AuthenticationAttribute]
    public class CustomerController : Controller
    {
        CustomerActions action = new CustomerActions();

        // GET: Customer
        public async Task<ActionResult> Index()
        {
            List<Customer> customers = await action.GetAll();
            return View(customers);
        }

        public async Task<ActionResult> Add()
        {
            Customer customer = new Customer();
            await customer.FillLookups();

            return View("Customer", customer);
        }
        
        [HttpPost]
        public async Task<ActionResult> Add(Customer customer)
        {
            Customer returnedCustomer = null;
            if (customer != null && ModelState.IsValid)
                returnedCustomer = await action.Add(customer);

            return RedirectToAction("Index", "Customer");
        }


        public async Task<ActionResult> Edit(string id)
        {
            Customer customer = null;
            customer = await action.Get(id);
            return View("Customer", customer);            
        }

        
        [HttpPost]
        public async Task<ActionResult> Edit(Customer customer)
        {
            Customer returnedCustomer = null;
            if (customer != null && ModelState.IsValid)
                returnedCustomer = await action.Edit(customer);

            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Delete(string id)
        {
            HttpStatusCode result = action.Delete(id);

            if(result == System.Net.HttpStatusCode.OK)
                return RedirectToAction("Index", "Customer");
            else
                return View("Error");
        }
    }
}