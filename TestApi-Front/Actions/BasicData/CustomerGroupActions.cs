using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using TestApi_Front.Helper;
using TestApi_Front.Models.BasicData;

namespace TestApi_Front.Actions.BasicData
{
    public class CustomerGroupActions : ActionAsync<CustomerGroup>, IDocument
    {
        public string getUri { get { return "document/Customer Group/"; }}
        public string postUri { get { return URLs.postURI; } }
        
        public override async Task<List<CustomerGroup>> GetAll()
        {
            string myUri = URLs.mainURI + getUri;
            myUri = Uri.EscapeUriString(myUri);
            
            HttpResponseMessage response = await client.GetAsync(myUri);

            List<CustomerGroup> lst = JsonConvert.DeserializeObject<List<CustomerGroup>>(response.Content.ReadAsStringAsync().Result);
            return lst;
        }

        public override async Task<CustomerGroup> Get(string id)
        {
            string myUri = URLs.mainURI + getUri + id;
            myUri = Uri.EscapeUriString(myUri);
            
            HttpResponseMessage response = await client.GetAsync(myUri);
            
            CustomerGroup customerGroup = JsonConvert.DeserializeObject<CustomerGroup>(response.Content.ReadAsStringAsync().Result);
            return customerGroup;
        }
    }
}