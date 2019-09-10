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
    public class TerritoryActions : ActionAsync<Territory>, IDocument
    {
        public string getUri { get { return "document/Territory/"; } }
        public string postUri { get { return URLs.postURI; }}
        
        public override async Task<List<Territory>> GetAll()
        {
            string myUri = URLs.mainURI + getUri;
            myUri = Uri.EscapeUriString(myUri);
            
            HttpResponseMessage response = await client.GetAsync(myUri);

            List<Territory> lst = JsonConvert.DeserializeObject<List<Territory>>(response.Content.ReadAsStringAsync().Result);
            return lst;
        }

        public override async Task<Territory> Get(string id)
        {
            string myUri = URLs.mainURI + getUri + id;
            myUri = Uri.EscapeUriString(myUri);

            HttpResponseMessage response = await client.GetAsync(myUri);

            Territory territory = JsonConvert.DeserializeObject<Territory>(response.Content.ReadAsStringAsync().Result);
            return territory;
        }
    }
}