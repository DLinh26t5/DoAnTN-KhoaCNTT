using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
using System.Reflection;


namespace DAL
{
    public class DAL_NganhHoc:KetNoi
    {
        protected override string GetSelectSQL()
        {
            return "select NganhHoc.*, Khoa.Ten as Khoa  FROM NGANHHOC "
                + "INNER JOIN Khoa ON ID_Khoa = Khoa.ID";
        }
  /*      public DataTable GetNganhbyKhoa(int id)
        {
            string sql = "SELECT ID, Ten FROM NganhHoc WHERE ID_Khoa = @ID_Khoa";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@ID_Khoa", id);
            DataTable dt = new DataTable();
            Executee(cmd, dt);
            return dt;
        }*/
        public void Insert(NganhHoc nganh)
        {
            string sql = CreateInsertSQL(nganh);
            Excecute(sql);
        }
        public void Update(NganhHoc nganh)
        {
            string sql = CreateUpdateSQL(nganh);
            Excecute(sql);
        }
        public void Delete(NganhHoc nganh)
        {
            string sql = "delete NGANHHOC from NGANHHOC where ID = '" + nganh.ID + "'";
            Excecute(sql);
        }
    }
}
