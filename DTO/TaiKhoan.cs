using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaiKhoan
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string Quyen { get; set; }

        public TaiKhoan(string tenDN, string matKhau, string quyen)
        {
            TenDangNhap = tenDN;
            MatKhau = matKhau;
            Quyen = quyen;
        }
    }
}
