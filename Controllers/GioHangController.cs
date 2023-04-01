using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using shoptraicay.Models;

namespace shoptraicay.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        [HttpGet]
        public ActionResult Index()
        {
            ShoppingCart cart = Session["Cart"] as ShoppingCart;
            ViewData["Cart"] = cart;
            return View();
        }
        [HttpPost]
        public ActionResult Increase(string maSP)
        {
            ShoppingCart cart = Session["Cart"] as ShoppingCart;
            cart.addItem(maSP);
            Session["Cart"] = cart;
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Decrease(string maSP)
        {
            ShoppingCart cart = Session["Cart"] as ShoppingCart;
            cart.decrease(maSP);
            Session["Cart"] = cart;
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(string maSP)
        {
            ShoppingCart cart = Session["Cart"] as ShoppingCart;
            cart.deleteItem(maSP);
            Session["Cart"] = cart;
            return RedirectToAction("Index");
        }
    }
}