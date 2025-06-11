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
    public class DAL_BangDiem : KetNoi
    {
        public DataTable Load_DAL()
        {
            return Load_Table("Select * from Diem");
        }
        public DataTable GetAllSV(int ID_Lop, int ID_MonHoc)
        {
            string sql = @"
        SELECT 
            sv.ID, 
            sv.MaSinhVien, 
            sv.TenSinhVien, 
            l.NgayThi,
            MAX(CASE WHEN l.LanThi = 1 THEN d.Diem ELSE NULL END) AS Diem
        FROM SINHVIEN sv
        LEFT JOIN Diem d ON sv.ID = d.ID_SinhVien
        LEFT JOIN LanThi l ON d.ID_LanThi = l.ID AND l.LanThi = 1
        WHERE sv.ID_Lop = @ID_Lop
        GROUP BY sv.ID, sv.MaSinhVien, sv.TenSinhVien, l.NgayThi";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@ID_Lop", ID_Lop);
            DataTable dt = new DataTable();
            Executee(cmd, dt);
            return dt;
        }
        public DataTable GetSVL2(int ID_Lop, int ID_MonHoc)
        {
            string sql = @"
        SELECT 
            sv.MaSinhVien, 
            sv.TenSinhVien,
            MAX(CASE WHEN lt1.LanThi = 1 THEN d1.Diem ELSE NULL END) AS DiemLan1,
            MAX(CASE WHEN lt2.LanThi = 2 THEN d2.Diem ELSE NULL END) AS DiemLan2
        FROM SINHVIEN sv
        LEFT JOIN Diem d1 ON sv.ID = d1.ID_SinhVien
        LEFT JOIN LanThi lt1 ON d1.IDLanThi = lt1.ID AND lt1.LanThi = 1
        LEFT JOIN Diem d2 ON sv.ID = d2.ID_SinhVien
        LEFT JOIN LanThi lt2 ON d2.ID_LanThi = lt2.ID AND lt2.LanThi = 2
        WHERE sv.ID_Lop = @ID_Lop
          AND d1.Diem < 5
        GROUP BY sv.ID, sv.MaSinhVien, sv.TenSinhVien";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@ID_Lop", ID_Lop);
            DataTable dt = new DataTable();
            Executee(cmd, dt);
            return dt;
        }
        public void Insert(BangDiem dB)
        {
            string sql = "insert into DIEM values (N'" + dB.ID_SinhVien + "','" + dB.ID_LanThi+ "','" + dB.Diem + "')";
            Excecute(sql);
        }

    }
}
