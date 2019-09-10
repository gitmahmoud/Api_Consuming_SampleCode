using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TestApi_Front.Actions
{
    public interface ISaveAsync<T>
    {
         Task<T> Add(T t);
    }
}