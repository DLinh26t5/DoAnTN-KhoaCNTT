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
    public class BUS_ChuaDat
    {
        DAL_MonChuaDat dal = new DAL_MonChuaDat();

        public DataTable GetMonChuaDat(int idLop)
        {
            return dal.GetMonChuaDat(idLop);
        }
    }
}

