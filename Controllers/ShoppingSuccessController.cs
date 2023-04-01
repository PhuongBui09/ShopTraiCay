using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using shoptraicay.Models;

namespace shoptraicay.Controllers
{
    public class ShoppingSuccessController : Controller
    {
        // GET: ShoppingSuccess
        public ActionResult Index()
        {
            ShoppingCart gh = Session["Cart"] as ShoppingCart;
            KhachHang kh = Session["KhachHang"] as KhachHang;
            ViewData["Cart"] = gh;
            ViewData["KhachHang"] = kh;
            Session["KhachHang"] = new KhachHang();
            Session["Cart"] = new ShoppingCart();
            return View();
        }
    }
}