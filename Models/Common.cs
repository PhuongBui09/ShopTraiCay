using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shoptraicay.Models
{
    public class Common
    {
        /// <summary>
        /// Lấy sản phẩm từ csdl
        /// </summary>
        /// <returns>Sản phẩm</returns>
        public static List<SanPham> GetSanPhams()
        {
            DbContext db = new DbContext("name=ShoptraicayEntities");
            List<SanPham> sanPhamList = new List<SanPham>();
            sanPhamList = db.Set<SanPham>().ToList<SanPham>();
            return sanPhamList;
        }
        /// <summary>
        /// Lấy sản phẩm theo loại
        /// </summary>
        /// <param name="maLoai">Truyền vào mã loại</param>
        /// <returns>Sản phẩm theo loại truyền vào</returns>
        public static List<SanPham> GetSanPhamTheoLoais(int maLoai)
        {
            //DbContext db = new DbContext("name=ShoptraicayEntities");
            //List<SanPham> sanPhamTheoLoai = new List<SanPham>();
            //sanPhamTheoLoai = db.Set<SanPham>().Where(m => m.maLoai == maLoai).ToList<SanPham>();
            //return sanPhamTheoLoai;
            Random random = new Random();
            int spRd;
            SanPham spTemp;
            List<SanPham> sanPhamTheoLoai = new List<SanPham>();
            List<SanPham> sanPhamsRD = new List<SanPham>();
            DbContext db = new DbContext("name=ShoptraicayEntities");
            foreach (SanPham i in db.Set<SanPham>().Where(m => m.maLoai == maLoai).ToList<SanPham>())
            {
                sanPhamsRD.Add(i);
            }
            int sl = sanPhamsRD.Count;
            for (int i = 0; i < sl; i++)
            {
                spRd = random.Next(sanPhamsRD.Count);
                spTemp = sanPhamsRD.ElementAt(spRd);
                sanPhamTheoLoai.Add(spTemp);
                sanPhamsRD.Remove(spTemp);
            }
            return sanPhamTheoLoai;
        }
        /// <summary>
        /// Lấy ra loại sản phẩm hoặc mã loại
        /// </summary>
        /// <returns>Loại sản phẩm</returns>
        public static List<LoaiSP> GetLoaiSPs()
        {
            DbContext db = new DbContext("name=ShoptraicayEntities");
            List<LoaiSP> loaiSPs = new List<LoaiSP>();
            loaiSPs = db.Set<LoaiSP>().ToList<LoaiSP>();
            return loaiSPs;
        }
        /// <summary>
        /// Lấy ra danh sách bài viết
        /// </summary>
        /// <returns>Trả ra danh sách bài viết</returns>
        public static List<BaiViet> GetBaiViets()
        {
            return new DbContext("name=ShoptraicayEntities").Set<BaiViet>().Where(m => m.daDuyet == true).ToList<BaiViet>();
        }
        /// <summary>
        /// Lấy ra sản phẩm random
        /// </summary>
        /// <returns>Trả ra danh sách sản phẩm đã random</returns>
        public static List<SanPham> GetSanPhamsRandom()
        {
            Random random = new Random();
            int spRd;
            SanPham spTemp;
            List<SanPham> listRd = new List<SanPham>();
            List<SanPham> sanPhamsRD = new List<SanPham>();
            DbContext db = new DbContext("name=ShoptraicayEntities");
            foreach (SanPham i in db.Set<SanPham>().Where(m => m.daDuyet == true).ToList<SanPham>())
            {
                sanPhamsRD.Add(i);
            }
            int sl = sanPhamsRD.Count;
            for(int i = 0; i < sl; i++)
            {
                spRd = random.Next(sanPhamsRD.Count);
                spTemp = sanPhamsRD.ElementAt(spRd);
                listRd.Add(spTemp);
                sanPhamsRD.Remove(spTemp);
            }
            return listRd;
        }
        /// <summary>
        /// Lấy sản phẩm theo mã sản phẩm
        /// </summary>
        /// <param name="maSP"></param>
        /// <returns></returns>
        public static SanPham GetSanPhamById(string maSP)
        {
            return new DbContext("name=ShoptraicayEntities").Set<SanPham>().Find(maSP);
        }
        /// <summary>
        /// Lấy tên sản phẩm từ mã sản phẩm
        /// </summary>
        /// <param name="maSP"></param>
        /// <returns></returns>
        public static string GetTenSPById(string maSP)
        {
            return new DbContext("name=ShoptraicayEntities").Set<SanPham>().Find(maSP).tenSP;
        }
        /// <summary>
        /// Lấy hình sản phẩm từ mã sản phẩm
        /// </summary>
        /// <param name="maSP"></param>
        /// <returns></returns>
        public static string GetHinhSPById(string maSP)
        {
            return new DbContext("name=ShoptraicayEntities").Set<SanPham>().Find(maSP).hinhDD;
        }
        /// <summary>
        /// Tìm sản phẩm theo tên
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public static List<SanPham> SearchProduct(string search)
        {
            List<SanPham> l = new List<SanPham>();
            DbContext cn = new DbContext("name=ShoptraicayEntities");
            l = cn.Set<SanPham>().Where(x => x.tenSP.Contains(search)).ToList<SanPham>();
            return l;
        }
        /// <summary>
        /// Lấy khách hàng theo mã
        /// </summary>
        /// <param name="maKH"></param>
        /// <returns></returns>
        public static string GetTenKhachHang(string maKH)
        {
            return new DbContext("name=ShoptraicayEntities").Set<KhachHang>().Find(maKH).tenKH;
        }
    }
}