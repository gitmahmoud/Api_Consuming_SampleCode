using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApi_Front.Actions
{
    public interface IDocument
    {        
        string getUri { get; }
        string postUri { get; }        
    }
}