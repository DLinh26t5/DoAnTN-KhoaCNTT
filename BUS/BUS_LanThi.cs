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
    public class BUS_LanThi
    {
        DAL_LanThi dallt = new DAL_LanThi();
        public DataTable LoadLT()
        {
            return dallt.Load();
        }
        public string Insert(LanTHi lt)
        {
            return dallt.Insert(lt);
        }
        public string Update(LanTHi lt)
        {
            return dallt.Update(lt);
        }
        public string Delete(LanTHi lt)
        {
            return dallt.Delete(lt);
        }
        public DataTable GetlanthibyMonhoc(int Mamon) 
        {
            return dallt.GetlanthibyMonhoc( Mamon);
        }
    }
}
