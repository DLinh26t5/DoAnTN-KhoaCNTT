using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using DAL;

namespace BUS
{
    public class BUS_HocKy
    {
        DAL_HocKy dalhky = new DAL_HocKy();
        public DataTable Load()
        {
            return dalhky.Load();
        }
        public void Insert(HocKy hk)
        {
            dalhky.Insert(hk);
        }
        public void Update(HocKy hk)
        {
            dalhky.Update(hk);
        }
        public void Delete(HocKy hk)
        {
            dalhky.Delete(hk);
        }
        public DataTable Gethkybynganh(int idNganh)
        {
            return dalhky.Gethkybynganh(idNganh);
        }
    }
}
