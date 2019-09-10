using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestApi_Front.Actions.BasicData;
using TestApi_Front.Actions.Sales;
using TestApi_Front.Filters;
using TestApi_Front.Models.Sales;

namespace TestApi_Front.Controllers.Sales
{

    [AuthenticationAttribute]
    public class SalesInvoiceController : Controller
    {
        public SalesInvoiceActions action = new SalesInvoiceActions();

        
        public async Task<ActionResult> Index()
        {
            List<SalesInvoice> records = await action.GetAll();
            return View(records);
        }

        public async Task<ActionResult> Add()
        {
            //SalesInvoice record = new SalesInvoice();
            //await record.FillLookups();

            SalesInvoice salesInvoice = null;
            salesInvoice = await action.Get("INV00001");

            return View("SalesInvoice", salesInvoice);
        }

        [HttpPost]
        public async Task<ActionResult> Add(SalesInvoice salesInvoice)
        {
            SalesInvoice returnedSalesInvoice = null;
            if (salesInvoice != null && ModelState.IsValid)
                returnedSalesInvoice = await action.Add(salesInvoice);

            return RedirectToAction("Index", "SalesInvoice");
        }


        public async Task<ActionResult> Edit(string id)
        {
            SalesInvoice salesInvoice = null;
            salesInvoice = await action.Get(id);
            return View("SalesInvoice", salesInvoice);            
        }


        [HttpPost]
        public async Task<ActionResult> Edit(SalesInvoice record)
        {
            SalesInvoice returnedRecord = null;
            if (record != null && ModelState.IsValid)
                returnedRecord = await action.Edit(record);

            if(returnedRecord != null)
                return RedirectToAction("Index", "SalesInvoice");
            else
                return View("Error");

        }

        public ActionResult Delete(string id)
        {
            HttpStatusCode result = action.Delete(id);

            if (result == System.Net.HttpStatusCode.OK)
                return RedirectToAction("Index", "SalesInvoice");
            else
                return View("Error");            
        }
    }
}