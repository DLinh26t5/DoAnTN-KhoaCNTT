
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using DTO;


namespace BUS
{
    public class BUS_KhoaHoc
    {
        DAL_KhoaHoc dal = new DAL_KhoaHoc();
        public DataTable Load()
        {
            return dal.Load();
        }
        public string Insert(KhoaHoc hoc)
        {
            return dal.Insert(hoc);
        }

        public string Update(KhoaHoc hoc)
        {
            return dal.Update(hoc);
        }

        public string Delete(KhoaHoc hoc)
        {
            return dal.Delete(hoc);
        }
    }
}
