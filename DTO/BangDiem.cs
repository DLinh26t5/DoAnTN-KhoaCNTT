using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BangDiem
    {
        public int ID {  get; set; }
        public int ID_SinhVien {  get; set; }
        public int ID_LanThi { get; set; }
        public int Diem {  get; set; }
        public BangDiem() { }
        public BangDiem(int iD, int iD_SinhVien, int iD_LanThi, int diem)
        {
            ID = iD;
            ID_SinhVien = iD_SinhVien;
            ID_LanThi = iD_LanThi;
            Diem = diem;
        }
    }
}
