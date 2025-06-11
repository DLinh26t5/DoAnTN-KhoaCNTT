using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BUS
{
    public class BUS_BangDiem
    {
        DAL_BangDiem dalbd = new DAL_BangDiem();
        public DataTable LoadBD()
        {
            return dalbd.Load_DAL();
        }
        public DataTable GetAllSV(int ID_Lop, int ID_MonHoc)
        {
            return dalbd.GetAllSV(ID_Lop, ID_MonHoc);
        }
        public void Insert(BangDiem d)
        {
            dalbd.Insert(d);
        }
        public DataTable GetSVL2(int ID_Lop, int ID_MonHoc)
        {
            return dalbd.GetSVL2(ID_Lop, ID_MonHoc);
        }
    }
   
}
