using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Security.Cryptography;
using System.Text;

namespace shoptraicay.Models
{
    public class Security
    {
        /// <summary>
        /// Mã hoá chuỗi văn bản dựa vào thuật toán SHA256
        /// </summary>
        /// <param name="PlanText">Chuỗi văn bản muốn mã hoá</param>
        /// <returns>Kết quả đã mã hoá</returns>
        public static string maHoaSHA256(string PlanText)
        {
            string kq = "";
            using(SHA256 bb = SHA256.Create())
            {
                byte[] sourceData = Encoding.UTF8.GetBytes(PlanText);
                byte[] hash = bb.ComputeHash(sourceData);
                kq = BitConverter.ToString(hash);
            }
            return kq;
        }
    }
}