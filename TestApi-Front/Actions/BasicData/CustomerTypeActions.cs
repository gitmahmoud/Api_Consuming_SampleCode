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
    public class CustomerTypeActions : ActionSync<CustomerType>
    {
        public override List<CustomerType> GetAll()
        {
            List<CustomerType> lst = LoadAll();
            return lst;
        }

        public override CustomerType Get(string id)
        {
            List<CustomerType> lst = LoadAll();
            return lst.Where(x=> x.customer_type == id).FirstOrDefault();
        }

        private static List<CustomerType> LoadAll()
        {
            List<CustomerType> lst = new List<CustomerType>();
            lst.Add(new Models.BasicData.CustomerType { customer_type = "Company", name = "شركة" });
            lst.Add(new Models.BasicData.CustomerType { customer_type = "Individual", name = "فرد" });
            return lst;
        }
    }
}