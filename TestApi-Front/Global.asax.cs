using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TestApi_Front.Helper;

namespace TestApi_Front
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
        }

        public void Session_Start(object sender, EventArgs e)
        {
            Session["Token"] = OAuth.Authenticate("apitest", "12345678");
        }
    }
}
