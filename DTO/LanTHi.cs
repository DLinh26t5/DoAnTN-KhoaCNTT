using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LanTHi
    {
        public int ID {  get; set; }
        public int LanThi {  get; set; }
        public DateTime NgayThi { get; set; }
        public int MaMon {  get; set; }
        public LanTHi() { }
        public LanTHi(int iD, int lanTHi, DateTime ngayThi, int maMon)
        {
            ID = iD;
            LanThi = lanTHi;
            NgayThi = ngayThi;
            MaMon = maMon;
        }
    }
}
