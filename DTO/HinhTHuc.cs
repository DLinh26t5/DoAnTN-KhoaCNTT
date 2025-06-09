using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HinhTHuc
    {
        public int ID {  get; set; }
        public string HinhThuc {  get; set; }
        public int ID_HocKy {  get; set; }
        public HinhTHuc() { }
        public HinhTHuc(int iD, string hinhThuc, int iD_HocKy)
        {
            ID = iD;
            HinhThuc = hinhThuc;
            ID_HocKy = iD_HocKy;
        }
    }
}
