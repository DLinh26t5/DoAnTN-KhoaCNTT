using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HocKy
    {
        public int ID { get; set; }
        public string TenHocKy {  get; set; }
        public int ID_NganhHoc {  get; set; }
        public HocKy() { }
        public HocKy(int iD, string tenHocKy, int iD_NganhHoc)
        {
            ID = iD;
            TenHocKy = tenHocKy;
            ID_NganhHoc = iD_NganhHoc;
        }
        public HocKy(string tenHocKy, int  iD_NganhHoc)
        {
            TenHocKy = tenHocKy;
            ID_NganhHoc = iD_NganhHoc;
        }
    }
}
