using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_BangDiemLopMon: KetNoi
    {
        public DataTable GetBangDiemLopMon(int idLop, int idMon, int idHinhThuc)
        {
            string sql = @"
                SELECT 
                    sv.Ma AS MaSV,
                    sv.Ten AS TenSV,
                    sv.NgaySinh,
                    MonHoc.Ma AS MaMon,
                    MonHoc.Ten AS TenMon,
                    MonHoc.SoGio / 15 AS SoTC,
                    d.DiemThi AS Diem
                FROM Diem d
                INNER JOIN SinhVien sv ON d.ID_SinhVien = sv.ID
                INNER JOIN DotThi dt ON d.ID_DotThi = dt.ID
                INNER JOIN ChuongTrinh ct ON dt.ID_ChuongTrinh = ct.ID
                INNER JOIN MonHoc ON ct.ID_MonHoc = MonHoc.ID
                INNER JOIN HinhThuc ON dt.ID_HinhThuc = HinhThuc.ID
                WHERE sv.ID_LopHoc = @IDLop
                  AND ct.ID_MonHoc = @IDMon
                  AND dt.ID_HinhThuc = @IDHinhThuc
                ORDER BY sv.Ma
            ";

            using (SqlConnection con = CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@IDLop", idLop);
                    cmd.Parameters.AddWithValue("@IDMon", idMon);
                    cmd.Parameters.AddWithValue("@IDHinhThuc", idHinhThuc);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
    