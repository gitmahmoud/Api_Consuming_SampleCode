using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApi_Front.Models
{
    public abstract class Document
    {
        public abstract string doctype { get; set; }
        public string owner { get; set; }
        public int docstatus { get; set; }
        public string name { get; set; }
        public DateTime? creation { get; set; }
        public string modified { get; set; }
        public string modified_by { get; set; }

    }
}