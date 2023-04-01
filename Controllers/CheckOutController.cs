using shoptraicay.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shoptraicay.Controllers
{
    public class CheckOutController : Controller
    {
        // GET: CheckOut
        [HttpGet]
        public ActionResult Index()
        {
            KhachHang x = new KhachHang();
            ShoppingCart cart = Session["Cart"] as ShoppingCart;
            ViewData["Cart"] = cart;
            return View(x);
        }
        [HttpPost]
        public ActionResult SaveToDaTaBase(KhachHang x)
        {
            using (var context = new ShoptraicayEntities())
            {
                using(DbContextTransaction trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        //Khách hàng
                        x.maKH = String.Format("{0:yyMMddhhmm}", DateTime.Now);
                        context.KhachHang.Add(x);
                        Session["KhachHang"] = x;
                        context.SaveChanges();
                        //Đơn hàng
                        DonHang d = new DonHang();
                        d.soDH = String.Format("{0:yyMMddhhmm}", DateTime.Now);
                        d.maKH = x.maKH;
                        d.ngayDat = DateTime.Now;
                        d.ngayGH = DateTime.Now.AddDays(5);
                        d.taiKhoan = "admin";
                        d.diaChiGH = x.diaChi;
                        context.DonHang.Add(d);
                        Session["DonHang"] = d;
                        context.SaveChanges();
                        //Chi tiết đơn hàng
                        ShoppingCart gh = Session["Cart"] as ShoppingCart;
                        foreach(CtDonHang i in gh.sanPhamDC.Values)
                        {
                            i.soDH = d.soDH;
                            context.CtDonHang.Add(i);
                        }
                        context.SaveChanges();
                        //Commit
                        trans.Commit();
                        return RedirectToAction("Index", "ShoppingSuccess");
                    }catch(Exception e)
                    {
                        trans.Rollback();
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}