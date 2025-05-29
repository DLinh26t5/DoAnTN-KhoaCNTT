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
    public class DAL_HocKy:KetNoi
    {
        public DataTable Load()
        {
            return Load_Table ("SELECT HOCKY.ID, HOCKY.TenHocKy, NGANHHOC.TenNganh\r\nFROM     HOCKY INNER JOIN\r\n                NGANHHOC ON HOCKY.ID_NganhHoc = NGANHHOC.ID");
        }
        public DataTable Gethkybynganh(int idNganh)
        {
            string sql = "SELECT ID, TenHocKy,ID_NganhHoc FROM HOCKY WHERE  (ID_NganhHoc = @ID_NganhHoc)";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@ID_NganhHoc", idNganh);
            DataTable dt = new DataTable();
            Executee(cmd, dt);
            return dt;
        }
        public void Insert(HocKy hk)
        {
            string sql = "insert into HOCKY values (N'" + hk.TenHocKy + "','" + hk.ID_NganhHoc + "')";
            Excecute(sql);
        }
        public void Update(HocKy hk)
        {
            string sql = "update HOCKY set TenHocKy = N'" + hk.TenHocKy + "',ID_NganhHoc = '" + hk.ID_NganhHoc + "' where ID = '" + hk.ID + "'";
            Excecute(sql);
        }
        public void Delete(HocKy hk)
        {
            string sql = "delete HOCKY from HOCKY where ID = '" + hk.ID + "'";
            Excecute (sql);
        }
    }
}
