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
    public class BUS_MonHoc
    {
        DAL_MonHoc dalmh = new DAL_MonHoc();
        public DataTable Load()
        {
            return dalmh.Load();
        }
        public void Insert(MonHoc mh)
        {
            dalmh.Insert(mh);
        }
        public void Update(MonHoc mh)
        {
            dalmh.Updater(mh);
        }
        public void Delete(MonHoc mh)
        {
            dalmh.Delete(mh);
        }
    }
}
