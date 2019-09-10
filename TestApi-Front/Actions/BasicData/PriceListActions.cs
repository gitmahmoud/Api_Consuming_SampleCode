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
    public class PriceListActions : ActionAsync<PriceList>, IDocument
    {
        public string getUri { get { return "document/Price List/"; } }
        public string postUri { get { return URLs.postURI; }}
        
        public override async Task<List<PriceList>> GetAll()
        {
            string myUri = URLs.mainURI + getUri;
            myUri = Uri.EscapeUriString(myUri);
            
            HttpResponseMessage response = await client.GetAsync(myUri);

            List<PriceList> lst = JsonConvert.DeserializeObject<List<PriceList>> (response.Content.ReadAsStringAsync().Result);
            return lst;
        }

        public async Task<List<PriceList>> GetAllFiltered(enum_buying_or_selling buying_or_selling)
        {
            string myUri = URLs.mainURI + getUri;
            myUri = Uri.EscapeUriString(myUri);

            HttpResponseMessage response = await client.GetAsync(myUri);

            List<PriceList> lst = JsonConvert.DeserializeObject<List<PriceList>>(response.Content.ReadAsStringAsync().Result);
            lst = lst.Where(x => x.buying_or_selling == buying_or_selling.ToString()).ToList();
            return lst;
        }

        public override async Task<PriceList> Get(string id)
        {
            string myUri = URLs.mainURI + getUri + id;
            myUri = Uri.EscapeUriString(myUri);

            HttpResponseMessage response = await client.GetAsync(myUri);

            PriceList record = JsonConvert.DeserializeObject<PriceList>(response.Content.ReadAsStringAsync().Result);
            return record;
        }
    }
}