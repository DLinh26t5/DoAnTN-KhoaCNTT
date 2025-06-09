using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SinhVien
    {
        public int ID {  get; set; }
        public int MaSinhVien {  get; set; }
        public string TenSinhVien { get; set; }
        public int ID_Lop {  get; set; }
        public SinhVien() { }
        public SinhVien(int iD, int maSinhVien, string tenSinhVien, int iD_Lop)
        {
            ID = iD;
            MaSinhVien = maSinhVien;
            TenSinhVien = tenSinhVien;
            ID_Lop = iD_Lop;
        }
    }
}
