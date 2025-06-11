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
    public class DAL_LopHoc : KetNoi
    {
        public DataTable Load()
        {
            return Load_Table("select * from LOPHOC");
        }
        public DataTable GetLopbyNganh(int ID_nganh)
        {
            string sql = "select * from LOPHOC where (ID_Nganh=@ID_Nganh)";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@ID_Nganh", ID_nganh);
            DataTable dt = new DataTable();
            Executee(cmd, dt);
            return dt;
        }
        public string Insert(LopHoc lh)
        {
            try
            {
                string sql = "insert into LOPHOC values (N'" + lh.TenLop + "','" + lh.ID_Nganh + "')";
                Excecute(sql);
                return "Thêm thành công";
            }
            catch (Exception ex)
            {
                return "Lỗi khi thêm : " + ex.Message;
            }
        }
        public string Update(LopHoc lh)
        {
            try
            {
                string sql = "update LOPHOC set TenLop = N'" + lh.TenLop + "','" + lh.ID_Nganh + "' where ID = '" + lh.ID + "'";
                Excecute(sql);
                return "Sửa thành công";
            }
            catch (Exception ex)
            {
                return "Lỗi khi Sửa : " + ex.Message;
            }
        }
        public string Delete(LopHoc lh)
        {
            try
            {
                string sql = "dalete LOPHOC from LOPHOC where ID ='" + lh.ID + "'";
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

