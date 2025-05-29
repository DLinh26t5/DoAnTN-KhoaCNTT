using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NganhHoc
    {
        public int ID {  get; set; }
        public string TenNganh {  get; set; }
        public int ID_Khoa {  get; set; }
        public NganhHoc() { }
        public NganhHoc(int iD, string tenNganh, int iD_Khoa)
        {
            ID = iD;
            TenNganh = tenNganh;
            ID_Khoa = iD_Khoa;
        }   
        public NganhHoc(string tenNganh)
        {
            tenNganh = TenNganh;
        }
    }
}
