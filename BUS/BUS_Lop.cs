using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_Lop
    {
        DAL_LopHoc dallop = new DAL_LopHoc();
        public DataTable Load()
        {
            return dallop.Load();
        }
        public string Insert(LopHoc lh)
        {
           return dallop.Insert(lh);
        }
        public string Update(LopHoc lh)
        {
            return dallop.Update(lh);
        }
        public string Delete(LopHoc lh)
        {
            return dallop.Delete(lh);
        }
        public DataTable GetLopbyNganh(int ID_nganh)
        {
            return dallop.GetLopbyNganh(ID_nganh);
        }
    }
}
