using shoptraicay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shoptraicay.Controllers
{
    public class ChiTietBVController : Controller
    {
        // GET: ChiTietBV
        public ActionResult Index(string id)
        {
            ShoptraicayEntities shopTraicay = new ShoptraicayEntities();
            BaiViet x = shopTraicay.BaiViet.Where(m => m.maBV.Equals(id)).First<BaiViet>();
            return View(x);
        }
    }
}