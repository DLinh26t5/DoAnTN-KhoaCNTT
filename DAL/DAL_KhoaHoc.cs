using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace DAL
{
    public class DAL_KhoaHoc: KetNoi
    {

        public DataTable Load()
        {
            return Load_Table("Select * from KHOAHOC");
        }
        public void Insert(KhoaHoc khoa)
        {
            string sql = " insert into KHOAHOC values('" + khoa.TenKhoa+"')";
            Excecute(sql);
        }
        public void Update(KhoaHoc khoa)
        {
            string SQL = "update KHOAHOC set TenKhoa = '" + khoa.TenKhoa + "' Where ID = '" + khoa.ID + "'";
            Excecute(SQL);
        }
        public void Delete(KhoaHoc khoa)
        {
            string sql = "delete from KHOAHOC where ID = '" + khoa.ID + "'";
            Excecute(sql);
        }
    }
}
