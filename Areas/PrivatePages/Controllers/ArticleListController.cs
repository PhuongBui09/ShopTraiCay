using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using shoptraicay.Models;

namespace shoptraicay.Areas.PrivatePages.Controllers
{
    public class ArticleListController : Controller
    {
        private ShoptraicayEntities db = new ShoptraicayEntities();
        // GET: PrivatePages/ArticleList
        [HttpGet]
        public ActionResult Index()
        {
            capNhatGiaoDien();
            return View();
        }
        [HttpPost]
        public ActionResult Delete(string maBV)
        {
            BaiViet bv = db.BaiViet.Find(maBV);
            db.BaiViet.Remove(bv);
            db.SaveChanges();
            capNhatGiaoDien();
            return View("Index");
        }
        [HttpPost]
        public ActionResult Active(string maBV)
        {
            BaiViet bv = db.BaiViet.Find(maBV);
            if(bv.daDuyet == true)
            {
                bv.daDuyet = false;
            }else
            {
                bv.daDuyet = true;
            }
            db.SaveChanges();
            capNhatGiaoDien();
            return View("Index");
        }
        [HttpGet]
        public ActionResult UpdateBV(string maBV)
        {
            BaiViet bv = db.BaiViet.Where(m => m.maBV.Equals(maBV)).FirstOrDefault();
            return View(bv);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UpdateBV(BaiViet x, HttpPostedFileBase hinhDaiDien)
        {
            BaiViet y = db.BaiViet.Find(x.maBV);
            y.maBV = x.maBV;
            y.tenBV = x.tenBV;
            y.ndTomTat = x.ndTomTat;
            y.noiDung = x.noiDung;
            y.ngayDang = x.ngayDang;
            y.daDuyet = x.daDuyet;
            y.taiKhoan = x.taiKhoan;
            if(hinhDaiDien != null)
            {
                //Vị trí lưu hình
                string virPath = "/Assets/Images/tintuc/";
                string phyPath = Server.MapPath("~/" + virPath);
                string EXT = Path.GetExtension(hinhDaiDien.FileName);
                string nameF = "HDD" + x.maBV + EXT;
                hinhDaiDien.SaveAs(phyPath + nameF);
                y.hinhDD = virPath + nameF;
            }
            db.SaveChanges();
            if (ModelState.IsValid)
                ModelState.Clear();
            return RedirectToAction("Index");
        }
        private void capNhatGiaoDien()
        {
            List<BaiViet> bv = db.BaiViet.OrderByDescending(m => m.ngayDang).ToList<BaiViet>();
            ViewData["DanhSachBV"] = bv;
        }
    }
}