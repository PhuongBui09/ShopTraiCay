using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shoptraicay.Models;

namespace shoptraicay.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string Acc, string Pass)
        {
            string mk = Security.maHoaSHA256(Pass);
            DangNhap tkdn = new ShoptraicayEntities()
                            .DangNhap.Where(x => x.taiKhoan.Equals(Acc.ToLower().Trim()) && x.matKhau.Equals(mk))
                            .FirstOrDefault<DangNhap>();
            bool checkTK = tkdn != null && tkdn.taiKhoan.Equals(Acc.ToLower().Trim()) && tkdn.matKhau.Equals(mk);
            if (checkTK)
            {
                Session["tkDangNhap"] = tkdn;
                Session["img"] = tkdn.hinhDD;
                Session["FullName"] = tkdn.hoDem + " " +  tkdn.tenTV;
                return Redirect("PrivatePages/Dashboard/Index");
            }
            return View();
        }
    }
}