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
        public DataTable LoadHthuc()
        {
            return dalhthuc.Load();
        }
        public void Insert(DTO_HinhThuc hthuc)
        {
            dalhthuc.Insert(hthuc);
        }
        public void Update(DTO_HinhThuc hthuc)
        {
            dalhthuc.Update(hthuc);
        }
        public void Delete(DTO_HinhThuc hthuc)
        {
            dalhthuc.Delete(hthuc);
        }
        public DataTable Getthucbyky(int idhky)
        {
            return dalhthuc.Getthucbyky(idhky);
        }
    }
}
