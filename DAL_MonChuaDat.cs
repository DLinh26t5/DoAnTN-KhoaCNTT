using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_MonChuaDat:KetNoi
    {
        public DataTable GetMonChuaDat(int idLop)
        {
            string sql = @"
        SELECT 
            sv.Ma AS MaSV,
            sv.Ten AS TenSV,
            MonHoc.Ten AS TenMon,
            MonHoc.SoGio / 15 AS SoTC,
            d.DiemThi AS Diem
        FROM Diem d
        INNER JOIN SinhVien sv ON d.ID_SinhVien = sv.ID
        INNER JOIN DotThi dt ON d.ID_DotThi = dt.ID
        INNER JOIN ChuongTrinh ct ON dt.ID_ChuongTrinh = ct.ID
        INNER JOIN MonHoc ON ct.ID_MonHoc = MonHoc.ID
        WHERE d.DiemThi < 5
          AND sv.ID_LopHoc = @IDLop
        ORDER BY sv.Ma, TenMon
    ";
            


            string connectionString = $"Data Source={KetNoi.HostName};Initial Catalog={KetNoi.DataName};Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IDLop", idLop);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}

