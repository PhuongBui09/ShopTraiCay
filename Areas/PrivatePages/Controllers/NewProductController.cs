using shoptraicay.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shoptraicay.Areas.PrivatePages.Controllers
{
    public class NewProductController : Controller
    {
        // GET: PrivatePages/NewProduct
        [HttpGet]
        public ActionResult Index()
        {
            SanPham x = new SanPham();
            x.ngayDang = DateTime.Now;
            DangNhap dn = Session["tkDangNhap"] as DangNhap;
            x.taiKhoan = dn.taiKhoan;
            x.daDuyet = false;
            return View(x);
        }
        [HttpPost]
        public ActionResult Index(SanPham x, int loaiSP, HttpPostedFileBase hinhSP)
        {
            try
            {
                ShoptraicayEntities shop = new ShoptraicayEntities();

                x.daDuyet = false;
                x.maSP = string.Format("{0:yyMMddhhmm}", DateTime.Now);
                x.ngayDang = DateTime.Now;
                x.dvt = "kg";
                x.giamGia = 0;
                x.maLoai = loaiSP;
                DangNhap tk = Session["tkDangNhap"] as DangNhap;
                x.taiKhoan = tk.taiKhoan;

                if (hinhSP != null)
                {
                    //Vị trí lưu hình
                    string virPath = "/Assets/Images/spDuocDang/";
                    string phyPath = Server.MapPath("~/" + virPath);
                    string EXT = Path.GetExtension(hinhSP.FileName);
                    string nameF = "HDD" + x.maSP + EXT;
                    hinhSP.SaveAs(phyPath + nameF);
                    x.hinhDD = virPath + nameF;
                    ViewBag.HinhMH = x.hinhDD;
                }
                else
                    x.hinhDD = "";
                shop.SanPham.Add(x);
                shop.SaveChanges();
                return RedirectToAction("Index", "Products");
            }
            catch
            {

            }
            return View(x);
        }
    }
}