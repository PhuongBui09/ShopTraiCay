using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shoptraicay.Models
{
    public class ShoppingCart
    {
        public string MaKH { get; set; }
        public string TaiKhoan { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime NgayGiao { get; set; }
        public string DiaChi { get; set; }

        /// <summary>
        /// Contructor mặc định
        /// </summary>
        public ShoppingCart()
        {
            this.MaKH = ""; this.TaiKhoan = "";
            this.NgayDat = DateTime.Now;
            this.NgayGiao = DateTime.Now.AddDays(2);
            this.DiaChi = "";
            this.sanPhamDC = new SortedList<string, CtDonHang>();
        }

        public SortedList<string, CtDonHang> sanPhamDC { get; set; }
        /// <summary>
        /// Kiểm tra giỏ hàng trống
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return sanPhamDC.Keys.Count == 0;
        }
        /// <summary>
        /// Thêm một sản phẩm vào giỏ hàng
        /// Thêm, tăng số lượng
        /// </summary>
        /// <param name="maSP"></param>
        public void addItem(string maSP)
        {
            if (sanPhamDC.Keys.Contains(maSP))
            {
                CtDonHang x = sanPhamDC.Values[sanPhamDC.IndexOfKey(maSP)];
                x.soLuong++;
            }
            else
            {
                CtDonHang i = new CtDonHang();
                i.maSP = maSP;
                i.soLuong = 1;
                SanPham x = Common.GetSanPhamById(maSP);
                i.giaBan = x.giaBan;
                i.giamGia = x.giamGia;
                sanPhamDC.Add(maSP, i);
            }
        }
        /// <summary>
        /// Thêm sản phẩm theo số lượng
        /// </summary>
        /// <param name="maSP"></param>
        /// <param name="slThemMoi"></param>
        public void addItems(string maSP, int slThemMoi)
        {
            if (sanPhamDC.Keys.Contains(maSP))
            {
                CtDonHang x = sanPhamDC.Values[sanPhamDC.IndexOfKey(maSP)];
                x.soLuong += slThemMoi;
            }
            else
            {
                CtDonHang i = new CtDonHang();
                i.maSP = maSP;
                i.soLuong = slThemMoi;
                SanPham x = Common.GetSanPhamById(maSP);
                i.giaBan = x.giaBan;
                i.giamGia = x.giamGia;
                sanPhamDC.Add(maSP, i);
            }
        }
        /// <summary>
        /// Xoá một sản phẩm trong giỏ hàng
        /// </summary>
        /// <param name="maSP"></param>
        public void deleteItem(string maSP)
        {
            if (sanPhamDC.Keys.Contains(maSP))
            {
                sanPhamDC.Remove(maSP);
            }
        }
        /// <summary>
        /// Giảm số lượng hoắc xoá sản phẩm đã chọn ra khỏi cửa hàng
        /// </summary>
        /// <param name="maSP"></param>
        public void decrease(string maSP)
        {
            if (sanPhamDC.Keys.Contains(maSP))
            {
                CtDonHang x = sanPhamDC.Values[sanPhamDC.IndexOfKey(maSP)];
                if(x.soLuong > 1)
                {
                    x.soLuong--;
                }else
                    deleteItem(maSP);
            }
        }
        /// <summary>
        /// Tính giá trị của 1 sản phẩm trong giỏ hàng
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public long moneyOfProduct(CtDonHang x)
        {
            return (long)(x.giaBan * x.soLuong - (x.giamGia * x.soLuong * x.giamGia));
        }
        /// <summary>
        /// Tổng tiền của toàn bộ sản phẩm
        /// </summary>
        /// <returns></returns>
        public long totalOfCartShop()
        {
            long kq = 0;
            foreach (CtDonHang i in sanPhamDC.Values)
                kq += moneyOfProduct(i);
            return kq;
        }
    }
}