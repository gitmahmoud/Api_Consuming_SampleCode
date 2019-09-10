using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestApi_Front.Models.BasicData
{
    public class CustomerType : Document
    {
        public override string doctype { get { return "CustomerType"; } set { } }

        [Display(Name = "Customer Type")]
        public string customer_type { get; set; }
    }
}