using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shoptraicay.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SearchSP(string search)
        {
            ViewBag.Search = search;
            return View("Index");
        }
    }
}