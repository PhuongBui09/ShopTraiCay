using shoptraicay.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shoptraicay.Areas.PrivatePages.Controllers
{
    public class ProductsController : Controller
    {
        // GET: PrivatePages/Products
        public ActionResult Index()
        {
            ShoptraicayEntities shop = new ShoptraicayEntities();
            List<SanPham> sp = shop.SanPham.OrderByDescending(m=>m.ngayDang).ToList<SanPham>();
            ViewData["DanhSachSP"] = sp;
            return View();
        }
        public ActionResult Delete(string loaiCanXoa)
        {
            ShoptraicayEntities shop = new ShoptraicayEntities();
            SanPham x = shop.SanPham.Find(loaiCanXoa);
            shop.SanPham.Remove(x);
            shop.SaveChanges();
            ViewData["DanhSachSP"] = shop.SanPham.OrderByDescending(m => m.ngayDang).ToList<SanPham>();
            return View("Index");
        }
        public ActionResult Active(string loaiCanAt)
        {
            ShoptraicayEntities shop = new ShoptraicayEntities();
            SanPham x = shop.SanPham.Find(loaiCanAt);
            if (x.daDuyet == true)
            {
                x.daDuyet = false;
            }
            else
            {
                x.daDuyet = true;
            }
            shop.SaveChanges();
            ViewData["DanhSachSP"] = shop.SanPham.OrderByDescending(m => m.ngayDang).ToList<SanPham>();
            return View("Index");
        }
        [HttpGet]
        public ActionResult UpdateSP(string maSP)
        {
            ShoptraicayEntities db = new ShoptraicayEntities();
            SanPham sp = db.SanPham.Where(m => m.maSP.Equals(maSP)).FirstOrDefault();
            return View(sp);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UpdateSP(SanPham x, int loaiSP, HttpPostedFileBase hinhSP)
        {
            ShoptraicayEntities db = new ShoptraicayEntities();
            SanPham y = db.SanPham.Find(x.maSP);
            y.maSP = x.maSP;
            y.tenSP = x.tenSP;
            y.ndTomTat = x.ndTomTat;
            y.noiDung = x.noiDung;
            y.ngayDang = x.ngayDang;
            y.daDuyet = x.daDuyet;
            y.taiKhoan = x.taiKhoan;
            y.maLoai = loaiSP;
            if (hinhSP != null)
            {
                //Vị trí lưu hình
                string virPath = "/Assets/Images/spDuocDang/";
                string phyPath = Server.MapPath("~/" + virPath);
                string EXT = Path.GetExtension(hinhSP.FileName);
                string nameF = "HDD" + x.maSP + EXT;
                hinhSP.SaveAs(phyPath + nameF);
                y.hinhDD = virPath + nameF;
            }
            else
                y.hinhDD = "";
            db.SaveChanges();
            if (ModelState.IsValid)
                ModelState.Clear();
            return RedirectToAction("Index");
        }
    }
}