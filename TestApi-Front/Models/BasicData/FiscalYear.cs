using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApi_Front.Models.BasicData
{
    public class FiscalYear : Document
    {
        public override string doctype { get { return "Fiscal Year"; } set { } }
        public string year { get; set; }
        public DateTime year_start_date { get; set; }
        public string is_fiscal_year_closed { get; set; }
    }
}