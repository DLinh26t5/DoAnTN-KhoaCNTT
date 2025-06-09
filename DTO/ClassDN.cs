using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public static class ClassDN
    {
        public static bool dangnhap;

        public static string TenDangNhap { get; set; }
        public static string Quyen { get; set; }
       public static bool DangNhap { get; set; } // Added this property to fix the error
    }
}
