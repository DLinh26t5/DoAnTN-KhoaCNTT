using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HocKy
    {
        public int ID {  get; set; }
        public string TenHocKy {  get; set; }
        public int ID_NganhHoc {  get; set; }
        //public string KhoaHoc {  get; set; }
        //public string NganhHoc { get; set; }
        public HocKy() { }
        public HocKy( string tenHocKy, int iD_NganhHoc)
        {
          
            TenHocKy = tenHocKy;
            ID_NganhHoc = iD_NganhHoc;
          //  KhoaHoc = khoaHoc;
            //NganhHoc = nganhHoc ;
        }
        public HocKy(int ID,string tenHocKy, int iD_nganh)
        {
            tenHocKy = TenHocKy;
            iD_nganh = ID_NganhHoc;
            ID = ID;
        }
    }
}
