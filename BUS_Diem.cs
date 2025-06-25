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
    public class BUS_Diem
    {
        DAL_Diem dal = new DAL_Diem();
        public DataTable Load()
        {
            return dal.Load();
        }
        public void Insert(BangDiem d)
        {
            dal.Insert(d);
        }

        public DataTable Load(object iDotThi, object iLopHoc)
        {
            return dal.Select($"ID_DotThi='{iDotThi}' AND ID_LopHoc='{iLopHoc}'");
        }

        public DataTable LoadBangDiem(object iLop, object iDotThi, bool thiLai = false)
        {
            var sql = "SELECT s.ID, s.Ma, s.Ten as HoTen, s.NgaySinh, d.ID as ID_Diem, DiemThi from SinhVien s"
                + $" left join (select Diem.* from Diem where ID_DotThi={iDotThi}) d on d.ID_SinhVien=s.ID"
                + $" where ID_LopHoc='{iLop}'";

            if (thiLai)
            {
                sql += " AND (DiemThi < 5 OR DiemThi IS NULL)";
            }

            return dal.LoadTable(sql);
        }

        public void SetDiem(object id, object iSinhVien, object iDotThi, object diem)
        {
            if (id == DBNull.Value)
            {
                dal.Excecute($"insert into Diem(ID_SinhVien,ID_DotThi,DiemThi) values('{iSinhVien}','{iDotThi}','{diem}')");
            }
            else
            {
                dal.Excecute($"update Diem set DiemThi={diem} where id={id}");
            }    
        }
    }   
}
