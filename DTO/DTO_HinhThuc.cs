using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_HinhThuc
    {
        public int ID {  get; set; }
        public string HinhThuc {  get; set; }   
        public int ID_HocKy {  get; set; }
        public DTO_HinhThuc() { }
        public DTO_HinhThuc( string HinhThuc, int iD_HocKy)
        {
            
            HinhThuc = HinhThuc;
            ID_HocKy = iD_HocKy;
        }
        public DTO_HinhThuc(int ID,string hinhThuc,int iD_HocKy)
        {
            HinhThuc = hinhThuc;
            iD_HocKy = ID_HocKy ;
            ID = ID;
        }
    }
}
