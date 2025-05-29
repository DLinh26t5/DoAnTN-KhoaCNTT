using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
   public class BUS_HocKy
    {
        DAL_HocKy dalhky = new DAL_HocKy();
        public DataTable Load()
        {
            return dalhky.Load();
        }
        public void Insert(HocKy hocKy)
        {
            dalhky.Insert(hocKy);
        }
        public void Update(HocKy hocKy)
        {
            dalhky.Update(hocKy);
        }
        public void Delete(HocKy hocKy)
        {
            dalhky.Delete(hocKy);
        }
        public DataTable Gethkybynganh(int idNganh)
        {
            return dalhky.Gethkybynganh(idNganh);
        }
    }
}
