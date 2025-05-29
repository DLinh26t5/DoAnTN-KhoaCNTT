using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace DAL
{
    public class DAL_KhoaHoc : KetNoi
    {
        public DataTable Load()
        {
            return Load_Table("select ID, TenKhoa FROM KHOAHOC");
        }
        public void Insert (KhoaHoc khoa)
        {
            string sql = "insert into KHOAHOC Values('"+khoa.TenKhoa+"')";
            Excecute(sql);
        }
        public void Update(KhoaHoc khoa)
        {
            string sql =" Update KHOAHOC SET TenKhoa = '"+khoa.TenKhoa+"'where ID = '"+khoa.ID+"'";
            Excecute(sql);
        }
        public void Delete(KhoaHoc khoa)
        {
            string sql = "delete from KHOAHOC where ID = '" + khoa.ID + "'";
            Excecute(sql);
        }
    }
}
