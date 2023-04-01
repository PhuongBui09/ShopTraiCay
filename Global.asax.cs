using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using shoptraicay.Models;

namespace shoptraicay
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Session_Start(Object sender, EventArgs e)
        {
            Session["tkDangNhap"] = null;
            Session["Cart"] = new ShoppingCart();
        }
    }
}
