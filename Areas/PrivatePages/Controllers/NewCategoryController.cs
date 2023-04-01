using shoptraicay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shoptraicay.Areas.PrivatePages.Controllers
{
    public class NewCategoryController : Controller
    {
        private static bool isUpdate = false;
        // GET: PrivatePages/NewCategory
        [HttpGet]
        public ActionResult Index()
        {
            List<LoaiSP> l = new ShoptraicayEntities().LoaiSP.OrderBy(x => x.tenLoai).ToList<LoaiSP>();
            ViewData["DsLoai"] = l;
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoaiSP x)
        {
            ShoptraicayEntities shop = new ShoptraicayEntities();
            if (!isUpdate)
                shop.LoaiSP.Add(x);
            else
            {
                LoaiSP y = shop.LoaiSP.Find(x.maLoai);
                y.tenLoai = x.tenLoai;
                y.ghiChu = x.ghiChu;
                isUpdate = false;
            }
            shop.SaveChanges();
            if (ModelState.IsValid)
                ModelState.Clear();
            ViewData["DsLoai"] = shop.LoaiSP.OrderBy(z => z.tenLoai).ToList<LoaiSP>();
            return View("Index");
        }
        [HttpPost]
        public ActionResult Delete(string loaiCanXoa)
        {
            ShoptraicayEntities shop = new ShoptraicayEntities();
            int ma = int.Parse(loaiCanXoa);
            LoaiSP x = shop.LoaiSP.Find(ma);
            shop.LoaiSP.Remove(x);
            shop.SaveChanges();
            ViewData["DsLoai"] = shop.LoaiSP.OrderBy(z => z.tenLoai).ToList<LoaiSP>();
            return View("Index");
        }
        [HttpPost]
        public ActionResult Update(string loaiCanSua)
        {
            ShoptraicayEntities shop = new ShoptraicayEntities();
            int ma = int.Parse(loaiCanSua);
            LoaiSP x = shop.LoaiSP.Find(ma);
            isUpdate = true;
            ViewData["DsLoai"] = shop.LoaiSP.OrderBy(z => z.tenLoai).ToList<LoaiSP>();
            return View("Index", x);
        }
    }
}