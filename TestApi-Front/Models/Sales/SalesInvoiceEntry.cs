using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApi_Front.Models.Sales
{
    public class SalesInvoiceEntry : Document, IChildDocument
    {
        public override string doctype { get { return "Sales Invoice Item"; } set { } }

        public string parent { get; set; }
        public string parentfield { get { return "entries"; } set { } }
        public string parenttype { get { return "Sales Invoice"; } set { } }

        public string item_code { get; set; }
        public string item_name { get; set; }
        public string description { get; set; }
        public string barcode { get; set; }
        public decimal qty { get; set; }
        public string stock_uom { get; set; }
        public decimal amount { get; set; }
        public decimal net_amount_export { get; set; }
        public decimal adj_rate { get; set; }
        public decimal ref_rate { get; set; }
        public string serial_no { get; set; }
        public string item_tax_rate { get; set; }
        public string delivery_note { get; set; }
        public string dn_detail { get; set; }
        public string cost_center { get; set; }
        public string so_detail { get; set; }
        public decimal actual_qty { get; set; }
        public string page_break { get; set; }
        public string income_account { get; set; }
        public string sales_order { get; set; }
        public string return_note { get; set; }
        public string warehouse { get; set; }
        public decimal basic_rate { get; set; }
        public string brand { get; set; }
        public string expense_account { get; set; }
        public decimal buying_amount { get; set; }
        public string time_log_batch { get; set; }
        public decimal delivered_qty { get; set; }
        public decimal export_rate { get; set; }
        public string idx { get; set; }
        public string item_group { get; set; }
        public decimal export_amount { get; set; }
        public string customer_item_code { get; set; }
        public string batch_no { get; set; }
        public decimal net_amount { get; set; }
        public decimal base_ref_rate { get; set; }
    }
}