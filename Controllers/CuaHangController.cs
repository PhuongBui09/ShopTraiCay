using shoptraicay.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shoptraicay.Controllers
{
    public class CuaHangController : Controller
    {
        // GET: CuaHang
        [HttpGet]
        public ActionResult Index()
        {
            Session["DanhSachSx"] = null;
            Session["GiaTu"] = null;
            Session["GiaDen"] = null;
            Session["Sort"] = null;
            return View();
        }
        /// <summary>
        /// Thêm sản phẩm vào giỏ hàng số lượng là 1
        /// </summary>
        /// <param name="maSP"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddToCart(string maSP)
        {
            ShoppingCart cart = Session["Cart"] as ShoppingCart;
            cart.addItem(maSP);
            Session["Cart"] = cart;
            return View("Index");
        }
        /// <summary>
        /// Thêm sản phẩm với số lượng truyền vào
        /// </summary>
        /// <param name="maSP"></param>
        /// <param name="slThemMoi"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddToCarts(string maSP, int slThemMoi)
        {
            ShoppingCart cart = Session["Cart"] as ShoppingCart;
            cart.addItems(maSP, slThemMoi);
            Session["Cart"] = cart;
            return View("Index");
        }
        /// <summary>
        /// Sắp xếp sản phẩm từ thấp dến cao và theo khoảng giá
        /// </summary>
        /// <param name="fromPrice"></param>
        /// <param name="toPrice"></param>
        /// <param name="by"></param>
        /// <returns></returns>
        public ActionResult Sort(string fromPrice, string toPrice, string by)
        {
            var shop = new DbContext("name=ShoptraicayEntities").Set<SanPham>().Where(x => x.giaBan > 1);

            int? from, to;
            //Sắp xếp khi có giá gửi vào
            if (fromPrice != null && toPrice != null)
            {
                from = int.Parse(fromPrice);
                to = int.Parse(toPrice);
                //Đã có sắp xếp
                if (Session["Sort"] != null)
                {
                    if ((string)Session["Sort"] == "thapDenCao")
                    {
                        shop = shop.Where(sp => sp.giaBan >= from && sp.giaBan <= to).OrderBy(sp => sp.giaBan);
                        Session["Sort"] = "thapDenCao";
                    }
                    if ((string)Session["Sort"] == "caoDenThap")
                    {
                        shop = shop.Where(sp => sp.giaBan >= from && sp.giaBan <= to).OrderByDescending(sp => sp.giaBan);
                        Session["Sort"] = "caoDenThap";
                    }
                }
                else
                {
                    shop = shop.Where(sp => sp.giaBan >= from && sp.giaBan <= to);
                }
                Session["GiaTu"] = from;
                Session["GiaDen"] = to;
            }
            //Sắp xếp khi không có giá tiền gửi vào
            else if(by != null)
            {
                //Nếu có giá tiền trước đó
                if (Session["GiaTu"] != null || Convert.ToInt32(Session["GiaTu"]) != 0)
                {
                    from = Convert.ToInt32(Session["GiaTu"]);
                    to = Convert.ToInt32(Session["GiaDen"]);
                    if (by == "thapDenCao")
                    {
                        shop = shop.Where(x => x.giaBan >= from && x.giaBan <= to).OrderBy(x => x.giaBan);
                        Session["Sort"] = "thapDenCao";
                    }
                    if (by == "caoDenThap")
                    {
                        shop = shop.Where(x => x.giaBan >= from && x.giaBan <= to).OrderByDescending(x => x.giaBan);
                        Session["Sort"] = "caoDenThap";
                    }
                }
                else
                {
                    //nếu không có giá trước đó
                    from = Convert.ToInt32(Session["GiaTu"]);
                    to = Convert.ToInt32(Session["GiaDen"]);
                    if (by == "thapDenCao")
                    {
                        shop = shop.OrderBy(x => x.giaBan);
                        Session["Sort"] = "thapDenCao";
                    }
                    if (by == "caoDenThap")
                    {
                        shop = shop.OrderByDescending(x => x.giaBan);
                        Session["Sort"] = "caoDenThap";
                    }
                }
            }
            Session["DanhSachSx"] = shop.ToList<SanPham>();
            return View("Index");
        }
    }
}