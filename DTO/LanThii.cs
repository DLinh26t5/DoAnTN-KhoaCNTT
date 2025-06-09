using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LanThii
    {
        public int ID {  get; set; }
        public int LanThi {  get; set; }
        public DateTime NgayThi { get; set; }
        public int MaMon {  get; set; }
        public LanThii() { }
        public LanThii(int iD, int lanThi, DateTime ngayThi, int maMon)
        {
            ID = iD;
            LanThi = lanThi;
            NgayThi = ngayThi;
            MaMon = maMon;
        }
    }
}
