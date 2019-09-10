using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApi_Front.Models.Sales
{
    public class OtherCharge : Document, IChildDocument
    {
        public string charge_type { get; set; }
        public string item_wise_tax_detail { get; set; }
        public decimal total { get; set; }
        public string parent { get; set; }
        public string included_in_print_rate { get; set; }
        public string description { get; set; }
        public override string doctype { get { return "Sales Taxes and Charges"; } set { } }
        public int idx { get; set; }
        public string parenttype { get { return "Sales Invoice"; } set { } }
        public decimal tax_amount { get; set; }
        public string row_id { get; set; }
        public decimal rate { get; set; }
        public string account_head { get; set; }
        public string cost_center { get; set; }
        public string parentfield { get { return "other_charges"; } set { } }
    }
}