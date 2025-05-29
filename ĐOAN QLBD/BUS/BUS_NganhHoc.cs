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
    public class BUS_NganhHoc
    {
        DAL_NganhHoc dalnganh = new DAL_NganhHoc();
        public DataTable LoadNganh()
        {
            return dalnganh.Load();
        }
        public void Insert(NganhHoc nganh)
        {
            dalnganh.Insert(nganh);
        }
        public void Update(NganhHoc nganh)
        {
            dalnganh.Update(nganh);
        }
        public void Delete(NganhHoc nganh)
        {
            dalnganh.Delete(nganh);
        }
        public DataTable GetNganhbyKhoa(int id)
        {
            return dalnganh.GetNganhbyKhoa(id);
        }
    }
}
