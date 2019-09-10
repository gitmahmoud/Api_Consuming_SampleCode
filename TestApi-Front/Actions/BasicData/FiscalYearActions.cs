using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using TestApi_Front.Helper;
using TestApi_Front.Models.BasicData;
using TestApi_Front.Models.Sales;

namespace TestApi_Front.Actions.BasicData
{
    public class FiscalYearActions : ActionAsync<FiscalYear>, IDocument
    {
        public string getUri { get { return "document/Fiscal Year/"; } }
        public string postUri { get { return URLs.postURI; }}
        
        public override async Task<List<FiscalYear>> GetAll()
        {
            string myUri = URLs.mainURI + getUri;
            myUri = Uri.EscapeUriString(myUri);
            
            HttpResponseMessage response = await client.GetAsync(myUri);

            List<FiscalYear> lst = JsonConvert.DeserializeObject<List<FiscalYear>> (response.Content.ReadAsStringAsync().Result);
            return lst;
        }

        public override async Task<FiscalYear> Get(string id)
        {
            string myUri = URLs.mainURI + getUri + id;
            myUri = Uri.EscapeUriString(myUri);

            HttpResponseMessage response = await client.GetAsync(myUri);

            FiscalYear record = JsonConvert.DeserializeObject<FiscalYear>(response.Content.ReadAsStringAsync().Result);
            return record;
        }
    }
}