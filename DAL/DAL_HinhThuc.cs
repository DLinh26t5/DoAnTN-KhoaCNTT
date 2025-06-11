using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DAL_HinhThuc:KetNoi
    {
        public DataTable Load()
        {
            return Load_Table("SELECT HINHTHUC.ID, HINHTHUC.HinhThuc, HOCKY.TenHocKy\r\nFROM     HINHTHUC INNER JOIN\r\n                  HOCKY ON HINHTHUC.ID_HocKy = HOCKY.ID");
        }
        public DataTable Getthucbyky(int idhky)
        {
            string sql = "SELECT ID, HinhThuc, ID_HocKy\r\nFROM     HINHTHUC where (ID_HocKy = @ID_HocKy)";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@ID_HocKy", idhky);
            DataTable dt = new DataTable();
            Executee(cmd, dt);

            return dt;
        }
        public void Insert(DTO_HinhThuc Hthuc)
        {
            string sql = "insert into HINHTHUC values(N'" + Hthuc.HinhThuc + "','" + Hthuc.ID_HocKy + "')";
            Excecute(sql);
        }
        public void Update(DTO_HinhThuc Hthuc)
        {
            string sql = "update HINHTHUC set HinhThuc =(N'" + Hthuc.HinhThuc + "','"+Hthuc.ID_HocKy+"' where ID = '"+Hthuc.ID+"')";
            Excecute(sql);
        }
        public void Delete(DTO_HinhThuc Hthuc)
        {
            string sql = "delete HINHTHUC from HINHTHUC where ID = '" + Hthuc.ID + "'";
            Excecute(sql);
        }
    }
}
