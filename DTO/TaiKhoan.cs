using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaiKhoan
    {
        public int ID { get; set; }
        public string TenDangNhap { get; set; } // Tên cột trong DB có thể là TenDangN...
        public string MatKhau { get; set; } // Tên cột trong DB là MaKhau
        public string Quyen { get; set; }
        public string GhiChu { get; set; }
        public TaiKhoan() { }
        public TaiKhoan(int iD, string tenDangNhap, string matKhau, string quyen, string ghiChu)
        {
            ID = iD;
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            Quyen = quyen;
            GhiChu = ghiChu;
        }
    }
}
