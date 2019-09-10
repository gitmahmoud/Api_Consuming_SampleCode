using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestApi_Front.Models.BasicData
{
    public class CustomerGroup : Document
    {
        public override string doctype { get { return "CustomerGroup"; } set { } }

        [Display(Name = "Customer Group")]
        public string customer_group_name { get; set; }

        [Display(Name = "Parent Customer Group")]
        public string parent_customer_group { get; set; }
    }
}