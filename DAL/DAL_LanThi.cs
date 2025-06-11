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
    public class DAL_LanThi:KetNoi
    {
        public DataTable Load()
        {
            return Load_Table ("Select * from LANTHI");
        }
        public DataTable GetlanthibyMonhoc(int Mamon)
        {
            string sql = "select * from LANTHI where MaMon= @MaMon";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@MaMon", Mamon);
            DataTable dt = new DataTable();
            Executee(cmd, dt);
            return dt;
        }
        public string Insert(LanTHi lt)
        {
            try
            {
                string sql = "insert into LANTHI values (N'" + lt.LanThi + "','" + lt.NgayThi.ToString("yyyy-MM-dd ") + "','" +lt.MaMon+"')";
                Excecute(sql);
                return "Thêm thành công";
            }
            catch (Exception ex)
            {
                return "Lỗi khi thêm : " + ex.Message;
            }
        }
        public string Update(LanTHi lt)
        {
            try
            {
                string sql = "update LANTHI set TenLop = N'" + lt.LanThi + "','" + lt.NgayThi+ "','"+lt.MaMon+"' where ID = '" + lt.ID + "'";
                Excecute(sql);
                return "Sửa thành công";
            }
            catch (Exception ex)
            {
                return "Lỗi khi Sửa : " + ex.Message;
            }
        }
        public string Delete(LanTHi lt)
        {
            try
            {
                string sql = "delete LANTHI from LOPHOC where MaMon ='" + lt.MaMon + "'";
                Excecute(sql);
                return "Xóa thành công";
            }
            catch (Exception ex)
            {
                return "Lỗi khi xóa : " + ex.Message;
            }
        }
    }
}
