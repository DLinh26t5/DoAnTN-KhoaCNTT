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
    public class BUS_MonHoc
    {
        DAL_MonHoc dalmhoc = new DAL_MonHoc();
        public DataTable Load()
        {
            return dalmhoc.Load();
        }
        public DataTable GetmonhocbyHinhthuc(int ID_Hinhthuc)
        {
            return dalmhoc.GetmonhocbyHinhthuc(ID_Hinhthuc);
        }
        public void Insert(MonHoc mh)
        {
            dalmhoc.Insert(mh);
        }
        public void Update(MonHoc mh)
        {
            dalmhoc.Update(mh);
        }
        public void Delete(MonHoc mh)
        {
            dalmhoc.Delete(mh);
        }
    }
}
