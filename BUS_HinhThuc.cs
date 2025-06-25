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
    public class BUS_HinhThuc 
    {
        DAL_HinhThuc dalhthuc = new DAL_HinhThuc();
        public DataTable Load()
        {
            return dalhthuc.Load();
        }
        public string Insert(HinhThuc hthuc)
        {
            return dalhthuc.Insert(hthuc);
        }
        public string Update(HinhThuc hthuc)
        {
            return dalhthuc.Update(hthuc);
        }
        public string Delete(HinhThuc hthuc)
        {
            return dalhthuc.Delete(hthuc);
        }
       /* public DataTable Getthucbyky(int idhky)
        {
            return dalhthuc.Getthucbyky(idhky);
        }*/
    }
}
