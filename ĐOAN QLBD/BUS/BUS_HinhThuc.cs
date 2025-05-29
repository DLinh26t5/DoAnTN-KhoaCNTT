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
    public class BUS_HinhThuc
    {
        DAL_HinhThuc dalhthuc = new DAL_HinhThuc();
        public DataTable LoadHthuc()
        {
            return dalhthuc.Load();
        }
        public void Insert (HinhTHuc ht)
        {
            dalhthuc.Insert(ht);
        }
        public void Update (HinhTHuc ht) {  dalhthuc.Update(ht);}
        public void Delete (HinhTHuc ht) { dalhthuc.Delete(ht);}
        public DataTable Getthucbyky(int idhky)
        {
            return dalhthuc.Getthucbyky(idhky);
        }
    }
}
