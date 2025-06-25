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
        public int ID_DotThi { get; set; }
        public int ID_LopHoc { get; set; }
        public int LanThi { get; set; }
        public int Diem {  get; set; }
        public BangDiem() { }
        
    }
}
