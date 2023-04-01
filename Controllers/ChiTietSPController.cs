using shoptraicay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shoptraicay.Controllers
{
    public class ChiTietSPController : Controller
    {
        public ActionResult Index(string id)
        {
            ShoptraicayEntities shopTraicay = new ShoptraicayEntities();
            SanPham x = shopTraicay.SanPham.Where(m => m.maSP.Equals(id)).First<SanPham>();
            return View(x);
        }
    }
}