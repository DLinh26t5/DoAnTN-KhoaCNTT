using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_BangDiemLopMon
    {
        DAL_BangDiemLopMon dal = new DAL_BangDiemLopMon();

        public DataTable GetBangDiem(int idLop, int idMon, int idHinhThuc)
        {
            return dal.GetBangDiemLopMon(idLop, idMon, idHinhThuc);
        }

    }
}
