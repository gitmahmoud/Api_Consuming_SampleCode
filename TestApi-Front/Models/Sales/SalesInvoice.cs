using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TestApi_Front.Actions;
using TestApi_Front.Actions.BasicData;
using TestApi_Front.Actions.Sales;
using TestApi_Front.Models.BasicData;

namespace TestApi_Front.Models.Sales
{
    public class SalesInvoice : Document, IMasterDocument
    {
        public override string doctype { get { return "Sales Invoice"; } set { } }
        public string company { get; set; }
        public string naming_series { get; set; }
        public string fiscal_year { get; set; }
        public DateTime posting_date { get; set; }
        public DateTime posting_time { get; set; }
        public DateTime due_date { get; set; }
        public string customer { get; set; }
        public string selling_price_list { get; set; }
        public string currency { get; set; }

        public decimal rounded_total_export { get; set; }
        public string cash_bank_account { get; set; }
        public string gross_profit_percent { get; set; }
        public string convert_into_recurring_invoice { get; set; }
        public string tc_name { get; set; }
        public string source { get; set; }
        public string charge { get; set; }
        public string address_display { get; set; }
        public string write_off_cost_center { get; set; }
        public string invoice_period_to_date { get; set; }
        public string write_off_outstanding_amount_automatically { get; set; }
        public string select_print_heading { get; set; }
        public string is_pos { get; set; }
        public string parentfield { get; set; }
        public decimal net_total_export { get; set; }
        public decimal write_off_amount { get; set; }
        public string pos_reference { get; set; }
        public string mode_of_payment { get; set; }
        public string price_list_currency { get; set; }
        public string contact_display { get; set; }
        public string next_date { get; set; }
        public string terms { get; set; }
        public string parent { get; set; }
        public decimal additional_discount_amount { get; set; }
        public decimal other_charges_total_export { get; set; }
        public DateTime aging_date { get; set; }
        public string customer_address { get; set; }
        public decimal total_commission { get; set; }
        public string contact_mobile { get; set; }
        public string _user_tags { get; set; }
        public string c_form_applicable { get; set; }
        public string idx { get; set; }
        public decimal rounded_total { get; set; }
        public string customer_group { get; set; }
        public string gross_profit { get; set; }
        public string repeat_on_day_of_month { get; set; }
        public string contact_person { get; set; }
        public string in_words { get; set; }
        public decimal additional_discount_percentage { get; set; }
        public string campaign { get; set; }
        public decimal conversion_rate { get; set; }
        public string against_income_account { get; set; }
        public decimal total_advance { get; set; }
        public string customer_name { get; set; }
        public decimal commission_rate { get; set; }
        public string update_stock { get; set; }
        public string account_for_change_amount { get; set; }
        public string territory { get; set; }
        public string sales_partner { get; set; }
        public string project_name { get; set; }
        public string end_date { get; set; }
        public string contact_email { get; set; }
        public decimal grand_total { get; set; }
        public string notification_email_address { get; set; }
        public string is_opening { get; set; }
        public string debit_to { get; set; }
        public string other_charges_total { get; set; }
        public string letter_head { get; set; }
        public string recurring_id { get; set; }
        public string shipping_rule { get; set; }
        public string apply_additional_discount_on { get; set; }
        public decimal paid_amount { get; set; }
        public string amended_from { get; set; }
        public string recurring_type { get; set; }
        public decimal grand_total_export { get; set; }
        public string write_off_account { get; set; }
        public decimal outstanding_amount { get; set; }
        public decimal change_amount { get; set; }
        public string in_words_export { get; set; }
        public string remarks { get; set; }
        public string invoice_period_from_date { get; set; }
        public string sync_submit_error { get; set; }
        public string c_form_no { get; set; }
        public decimal plc_conversion_rate { get; set; }
        public string parenttype { get; set; }
        public decimal net_total { get; set; }
        

        public List<FiscalYear> FiscalYears { get; set;}
        public List<Customer> customers { get; set;}
        public List<PriceList> priceLists { get; set; }

        public List<SalesInvoiceEntry> entries { get; set; }
        public List<OtherCharge> other_charges { get; set; }
        
        ActionAsync<FiscalYear> fiscalYearActions = new FiscalYearActions();
        ActionAsync<Customer> customerActions = new CustomerActions();
        PriceListActions priceListActions = new PriceListActions();
        
        public async Task FillLookups()
        {
            Task<List<FiscalYear>> t = fiscalYearActions.GetAll();            
            Task<List<Customer>> c = customerActions.GetAll();    
            Task<List<PriceList>> p = priceListActions.GetAllFiltered(enum_buying_or_selling.Selling);
                                
            this.FiscalYears = await t;            
            this.customers = await c;
            this.priceLists = await p;
        }
    }
}

/*

"other_charges": [
{
"charge_type": "On Net Total",
"item_wise_tax_detail": "{\"10264\": [5.0, 25.0]}",
"total": 525,
"modified_by": "Administrator",
"name": "INVTD000006",
"parent": "INV00005",
"included_in_print_rate": null,
"description": "ضريبة القيمة المضافة VAT (5%)",
"creation": "2019-07-10 10:28:54",
"doctype": "Sales Taxes and Charges",
"modified": "2019-07-10 10:28:55",
"idx": 1,
"parenttype": "Sales Invoice",
"tax_amount": 25,
"owner": "Administrator",
"docstatus": 0,
"row_id": null,
"rate": 5,
"account_head": "4406 ضريبة القيمه المضافه على المخرجات - H",
"cost_center": "مركز التكلفة الأساسي - H",
"parentfield": "other_charges"
}
]
}

        */
