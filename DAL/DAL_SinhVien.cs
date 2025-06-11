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
    public class DAL_SinhVien:KetNoi
    {
        public DataTable Load() 
        {
            return Load_Table("SELECT SINHVIEN.ID, SINHVIEN.MaSinhVien, SINHVIEN.TenSinhVien, LOPHOC.TenLop, NGANHHOC.TenNganh, KHOAHOC.TenKhoa\r\nFROM     SINHVIEN INNER JOIN\r\n                  LOPHOC ON SINHVIEN.ID_Lop = LOPHOC.ID INNER JOIN\r\n                  KHOAHOC ON SINHVIEN.ID = KHOAHOC.ID INNER JOIN\r\n                  NGANHHOC ON LOPHOC.ID_Nganh = NGANHHOC.ID AND KHOAHOC.ID = NGANHHOC.ID_Khoa");
        }
        public DataTable GetSinhVienbyLop(int ID_Lop)
        {
            string sql = "select * from SINHVIEN where (ID_Lop =@ID_Lop) ";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@ID_Lop", ID_Lop);
            DataTable dt = new DataTable();
            Executee(cmd, dt);
            return dt;
        }
        public int GetID(string masv)
        {
            string sql = "Select ID from SINHVIEN where MaSinhVien =@MaSinhVien";
            int ID_SV = -1;
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@MaSinhVien", masv);
            DataTable dt = new DataTable();
            Executee(cmd, dt);
            if (dt.Rows.Count > 0)
            {
                ID_SV = Convert.ToInt32(dt.Rows[0]["ID"]);
            }
            return ID_SV;
        }
        public DataTable GetsvbyName(string name)
        {

            string sql = "SELECT ID, TenSv FROM SINHVIEN WHERE TenSinhVien LIKE @name";

            SqlCommand cmd = new SqlCommand(sql);
            SqlParameter[] parameters = new SqlParameter[]
               {
        new SqlParameter("@name", SqlDbType.NVarChar) { Value = "%" + name + "%" }
               };
            cmd.Parameters.AddRange(parameters);
            DataTable dataTable = new DataTable();
            Executee(cmd, dataTable);
            return dataTable;
        }
        public string Insert(SinhVien sv)
        {
            try
            {
                string sql = "insert into SINHVIEN values(N'" + sv.MaSinhVien + "','" + sv.TenSinhVien + "','" + sv.ID_Lop + "')";
                Excecute(sql);
                return "Thêm thành công";
            }
            catch (Exception ex)
            {
                return "Lỗi khi thêm : " + ex.Message;
            }
        }
        public string Update(SinhVien sv)
        {
            try
            {
                string sql = "update SINHVIEN set MaSinhVien = N'" + sv.MaSinhVien + "',TenSinhVien= '" + sv.TenSinhVien + "' where ID = '" + sv.ID + "'";
                Excecute(sql);
                return "Sửa thành công";
            }
            catch (Exception ex)
            {
                return "Lỗi khi Sửa : " + ex.Message;
            }
        }
        public string Delete(SinhVien sv)
        {
            try
            {
                string sql = "delete SINHVIEN from SINHVIEN where ID = '" + sv.ID + "'";
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
