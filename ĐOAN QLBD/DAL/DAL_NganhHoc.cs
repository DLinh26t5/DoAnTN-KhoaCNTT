using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_NganhHoc:KetNoi
    {
        public DataTable Load()
        {
            return Load_Table("select * From NGANHHOC");
        }
        public DataTable GetNganhbyKhoa(int id)
        {
            string sql = "SELECT ID, TenNganh FROM NGANHHOC WHERE ID_Khoa = @ID_Khoa";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@ID_Khoa", id);
            DataTable dt = new DataTable();
            Executee(cmd, dt);
            return dt;
        }
        public void Insert (NganhHoc nganh)
        {
            string sql = "insert into NGANHHOC values('" + nganh.TenNganh + "','" + nganh.ID_Khoa + "')";
            Excecute(sql);
        }
        public void Update(NganhHoc nganh)
        {
            string sql = "update NGANHHOC set TenNganh = N'" + nganh.TenNganh + "',ID_Khoa= '" + nganh.ID_Khoa + "' where ID = '" + nganh.ID + "'";
            Excecute(sql);
        }
        public void Delete( NganhHoc nganh)
        {
            string sql = "delete NGANHHOC from NGANHHOC where ID = '" + nganh.ID + "'";
            Excecute(sql);
        }
    }
}
