using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TestApi_Front.Actions;
using TestApi_Front.Actions.BasicData;
using TestApi_Front.Models.BasicData;

namespace TestApi_Front.Models.Sales
{
    public class Customer : Document, IMasterDocument
    {
        public override string doctype { get { return "Customer"; } set { } }
        public string company { get; set; }

        ActionAsync<Territory> territoryActions = new TerritoryActions();
        ActionAsync<CustomerGroup> customerGroupActions = new CustomerGroupActions();
        ActionSync<CustomerType> customerTypeActions = new CustomerTypeActions();

        public string customer_details { get; set; }
        public string naming_series { get; set; }
        public string lead_name { get; set; }

        [Display(Name = "Customer Name")]
        public string customer_name { get; set; }

        [Display(Name = "Currency")]
        public string default_currency { get; set; }

        public string default_sales_partner { get; set; }

        [Display(Name = "Customer Type")]
        public string customer_type { get; set; }

        public string credit_days { get; set; }

        [Display(Name = "Territory")]
        public string territory { get; set; }

        public string website { get; set; }
        public string parent { get; set; }
        public string default_commission_rate { get; set; }
        public string credit_limit { get; set; }
        public string idx { get; set; }

        [Display(Name = "Customer Group")]
        public string customer_group { get; set; }

        public string parenttype { get; set; }

        [Display(Name = "Price List")]
        public string default_price_list { get; set; }

        public string tax_number { get; set; }
        public string parentfield { get; set; }
        
        public List<Territory> territories { get; set; }
        public List<CustomerGroup> customerGroups { get; set; }
        public List<CustomerType> customerTypes { get; set; }
        
        public async Task FillLookups()
        {
            Task<List<Territory>> t = territoryActions.GetAll();
            Task<List<CustomerGroup>> c = customerGroupActions.GetAll();
            this.territories = await t;
            this.customerGroups = await c;
            this.customerTypes = customerTypeActions.GetAll();
        }
    }
}