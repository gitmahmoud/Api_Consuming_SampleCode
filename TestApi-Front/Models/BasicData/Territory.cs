using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestApi_Front.Models.BasicData
{
    public class Territory : Document
    {
        public override string doctype { get { return "Territory"; } set { } }

        [Display(Name = "Territory Name")]
        public string territory_name { get; set; }

        [Display(Name = "Parent Territory")]
        public string parent_territory { get; set; }
    }
}