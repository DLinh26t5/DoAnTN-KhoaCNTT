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
    public class BUS_ChuongTrinh
    {
        DAL_ChuongTrinh dal = new DAL_ChuongTrinh();
        public DataTable LoadByNganhID(object id) => dal.SelectByNganhID(id);
        public DataTable Load()
        {
            return dal.Load();
        }

       

        public string Insert(ChuongTrinh  ct)
        {
            return dal.Insert(ct);
        }
        public string Update(ChuongTrinh ct)
        {
            return dal.Update(ct);
        }
        public string Delete(ChuongTrinh ct)
        {
            return dal.Delete(ct);
        }
    }
}
