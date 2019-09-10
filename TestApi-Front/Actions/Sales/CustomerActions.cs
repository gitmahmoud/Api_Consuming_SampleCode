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
    public class CustomerActions : ActionAsync<Customer>, IDocument, ISaveAsync<Customer>
    {
        public string getUri { get { return "document/Customer/"; }}
        public string postUri { get { return URLs.postURI; }}
        public string docType { get { return "Customer"; }}
        
        public override async Task<List<Customer>> GetAll()
        {
            string myUri = URLs.mainURI + getUri;
            myUri = Uri.EscapeUriString(myUri);

            HttpResponseMessage response = await client.GetAsync(myUri);

            List<Customer> lst = JsonConvert.DeserializeObject<List<Customer>>(response.Content.ReadAsStringAsync().Result);
            return lst;
        }

        public async override Task<Customer> Get(string id)
        {
            Customer customer = null;

            if (String.IsNullOrEmpty(id))            
                customer = new Customer();            
            else
            {
                string myUri = URLs.mainURI + getUri + id;
                myUri = Uri.EscapeUriString(myUri);

                HttpResponseMessage response = client.GetAsync(myUri).Result;

                customer = JsonConvert.DeserializeObject<Customer>(response.Content.ReadAsStringAsync().Result);
            }

            await customer.FillLookups();
            return customer;
        }

        public async Task<Customer> Add(Customer customer)
        {
            string myUri = URLs.mainURI + postUri;

            FillRequiredDataForNewCustomer(customer);

            var json = JsonConvert.SerializeObject(customer);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            
            HttpResponseMessage response = await client.PostAsync(myUri, stringContent);

            Customer customerReturned = JsonConvert.DeserializeObject<Customer>(response.Content.ReadAsStringAsync().Result);

            return customerReturned;
        }

        public async Task<Customer> Edit(Customer customer)
        {
            string myUri = URLs.mainURI + postUri;

            //Customer2 customer2 = new Customer2();
            //PropertyCopier<Customer, Customer2>.Copy(customer, customer2);


            var json = JsonConvert.SerializeObject(customer);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(myUri, stringContent);

            Customer customerReturned = JsonConvert.DeserializeObject<Customer>(response.Content.ReadAsStringAsync().Result);

            return customerReturned;
        }

        public HttpStatusCode Delete(string id)
        {
            string myUri = URLs.mainURI + getUri + id;
            myUri = Uri.EscapeUriString(myUri);

            HttpResponseMessage response = client.DeleteAsync(myUri).Result;

            return response.StatusCode;
        }

        private void FillRequiredDataForNewCustomer(Customer customer)
        {
            customer.creation = DateTime.Now;
            customer.owner = "Administrator";
            customer.default_currency = "SAR";
            customer.docstatus = 0;
            customer.company = "شركة الحياة للتجزئة";
            customer.default_price_list = "Standard Selling";            
        }
    }
}