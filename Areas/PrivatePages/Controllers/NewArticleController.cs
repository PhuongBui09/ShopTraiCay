using shoptraicay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace shoptraicay.Areas.PrivatePages.Controllers
{
    public class NewArticleController : Controller
    {
        // GET: PrivatePages/NewArticle
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.HinhMH = "~/imgadmin/admin1.png";
            return View();
        }
        [HttpPost]

        public ActionResult Index(BaiViet x, HttpPostedFileBase hinhDaiDien)
        {
            try
            {
                ShoptraicayEntities shop = new ShoptraicayEntities();

                x.daDuyet = false;
                x.maBV = string.Format("{0:yyMMddhhmm}", DateTime.Now);
                x.ngayDang = DateTime.Now;
                DangNhap tk = Session["tkDangNhap"] as DangNhap;
                x.taiKhoan = tk.taiKhoan;

                if (hinhDaiDien != null)
                {
                    //Vị trí lưu hình
                    string virPath = "/Assets/Images/tintuc/";
                    string phyPath = Server.MapPath("~/" + virPath);
                    string EXT = Path.GetExtension(hinhDaiDien.FileName);
                    string nameF = "HDD" + x.maBV + EXT;
                    hinhDaiDien.SaveAs(phyPath + nameF);
                    x.hinhDD = virPath + nameF;
                    ViewBag.HinhMH = x.hinhDD;
                    shop.BaiViet.Add(x);
                }
                else
                    x.hinhDD = "";
                shop.SaveChanges();
                return RedirectToAction("Index", "ArticleList");
            }
            catch
            {

            }
            return View(x);
        }
    }
}