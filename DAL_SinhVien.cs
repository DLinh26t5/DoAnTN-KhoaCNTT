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
        protected override string GetSelectSQL()
        {
            return @"
        SELECT sv.ID, sv.Ma, sv.Ten, sv.NgaySinh, sv.ID_LopHoc, l.Ten AS TenLop
        FROM SinhVien sv
        INNER JOIN LopHoc l ON sv.ID_LopHoc = l.ID";
        }
        public SinhVien CreateOne(DataRow r)
        {
            var sv = new SinhVien();
            GetColumns(sv, (n, id, columns) =>
            {
                columns.Add(id);
                foreach (var p in columns)
                {
                    p.SetValue(sv, r[p.Name]);
                }
            });

            return sv;
        }

        public SinhVien GetByMSSV(string mssv)
        {
            var dt = Select($"Ma='{mssv}'");
            if (dt.Rows.Count > 0)
            {
                var sv = CreateOne(dt.Rows[0]);

                return sv;
            }
            return null;
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


        public DataTable TimKiemSinhVien(string ma, string ten)
        {
            string sql = "SELECT ID, Ma, Ten, NgaySinh, ID_LopHoc FROM SinhVien WHERE 1=1";
            SqlCommand cmd = new SqlCommand();

            if (!string.IsNullOrWhiteSpace(ma))
            {
                sql += " AND Ma COLLATE Vietnamese_CI_AI LIKE @Ma";
                cmd.Parameters.AddWithValue("@Ma", "%" + ma + "%");
            }

            if (!string.IsNullOrWhiteSpace(ten))
            {
                sql += " AND Ten COLLATE Vietnamese_CI_AI LIKE @Ten";
                cmd.Parameters.AddWithValue("@Ten", "%" + ten + "%");
            }

            cmd.CommandText = sql;

            DataTable dt = new DataTable();
            Executee(cmd, dt);
            return dt;
        }

        public string Insert(SinhVien sv)
        {
            try
            {
                string sql = CreateInsertSQL(sv);
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
                string sql = CreateUpdateSQL(sv);
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
