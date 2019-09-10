using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using TestApi_Front.Helper;
using TestApi_Front.Models.Sales;
using TestApi_Front.Actions.BasicData;
using System.Text;
using TestApi_Front.Actions;
using TestApi_Front.Models.BasicData;
using System.Net;

namespace TestApi_Front.Actions.Sales
{
    public class SalesInvoiceActions : ActionAsync<SalesInvoice>, IDocument//, ISaveAsync<SalesInvoice>
    {
        public string getUri { get { return "document/Sales Invoice/"; }}
        public string postUri { get { return URLs.postURI; }}
        //public string docType { get { return "Customer"; }}
        
        public override async Task<List<SalesInvoice>> GetAll()
        {
            string myUri = URLs.mainURI + getUri;
            myUri = Uri.EscapeUriString(myUri);

            HttpResponseMessage response = await client.GetAsync(myUri);

            List<SalesInvoice> lst = JsonConvert.DeserializeObject<List<SalesInvoice>>(response.Content.ReadAsStringAsync().Result);
            return lst;
        }

        public async override Task<SalesInvoice> Get(string id)
        {
            SalesInvoice record = null;

            if (String.IsNullOrEmpty(id))            
                record = new SalesInvoice();            
            else
            {
                string myUri = URLs.mainURI + getUri + id;
                myUri = Uri.EscapeUriString(myUri);

                HttpResponseMessage response = client.GetAsync(myUri).Result;

                record = JsonConvert.DeserializeObject<SalesInvoice>(response.Content.ReadAsStringAsync().Result);
            }

            await record.FillLookups();
            return record;
        }

        public async Task<SalesInvoice> Add(SalesInvoice record)
        {
            record.customer_name = record.customer;
            
            string myUri = URLs.mainURI + postUri;

            FillRequiredDataForNewSalesInvoice(record);

            var json = JsonConvert.SerializeObject(record);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(myUri, stringContent);

            SalesInvoice salesInvoiceReturned = JsonConvert.DeserializeObject<SalesInvoice>(response.Content.ReadAsStringAsync().Result);

            return salesInvoiceReturned;
        }

        public async Task<SalesInvoice> Edit(SalesInvoice record)
        {
            record.customer_name = record.customer;

            string myUri = URLs.mainURI + postUri;

            var json = JsonConvert.SerializeObject(record);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(myUri, stringContent);

            SalesInvoice recordReturned = JsonConvert.DeserializeObject<SalesInvoice>(response.Content.ReadAsStringAsync().Result);

            return recordReturned;
        }

        public HttpStatusCode Delete(string id)
        {
            string myUri = URLs.mainURI + getUri + id;
            myUri = Uri.EscapeUriString(myUri);

            HttpResponseMessage response = client.DeleteAsync(myUri).Result;

            return response.StatusCode;            
        }

        private void FillRequiredDataForNewSalesInvoice(SalesInvoice record)
        {
            record.creation = DateTime.Now;
            record.owner = "Administrator";            
            record.docstatus = 0;
            record.company = "شركة الحياة للتجزئة";
            
        }
    }
}