using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LopHoc
    {
        public int ID {  get; set; }
        public string TenLop {  get; set; }
        public int ID_Nganh {  get; set; }
        public LopHoc() { }
        public LopHoc(int iD, string tenLop, int iD_Nganh)
        {
            ID = iD;
            TenLop = tenLop;
            ID_Nganh = iD_Nganh;
        }
        public LopHoc(string tenLop)
        {
            TenLop= tenLop;
        }
    }
}
