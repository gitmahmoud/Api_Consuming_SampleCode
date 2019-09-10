using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi_Front.Models
{
    interface IChildDocument
    {
        string parent { get; set; }
        string parentfield { get; set; }
        string parenttype { get; set; }
        
    }
}
