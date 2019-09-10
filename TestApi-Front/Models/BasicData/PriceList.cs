using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApi_Front.Models.BasicData
{
    public class PriceList : Document
    {
        public override string doctype { get { return "Price List"; } set { } }
        public string price_list_name { get; set; }
        public string currency { get; set; }
        public string buying_or_selling { get; set; }
    }

    public enum enum_buying_or_selling
    {
        Buying,
        Selling
    }
}