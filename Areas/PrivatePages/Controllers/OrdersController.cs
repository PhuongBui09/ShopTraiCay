using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shoptraicay.Areas.PrivatePages.Controllers
{
    public class OrdersController : Controller
    {
        // GET: PrivatePages/Orders
        public ActionResult Index()
        {
            return View();
        }
    }
}