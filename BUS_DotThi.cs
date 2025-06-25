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
    public class BUS_DotThi
    {
        DAL_DotThi dal = new DAL_DotThi();

        public DataTable SelectBangDiem(object nganhID, object hocKyID, object hinhThucID)
        {
            return dal.Select($"ID_NganhHoc={nganhID} AND ID_HocKy={hocKyID} AND Lan=1 AND ID_HinhThuc={hinhThucID} ");
        }

        public DataTable Load()
        {
            return dal.Load();
        }
        public string Insert(DotThi lt)
        {
            return dal.Insert(lt);
        }
        public string Update(DotThi lt)
        {
            return dal.Update(lt);
        }
        public string Delete(DotThi lt)
        {
            return dal.Delete(lt);
        }
    }
}
