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
    public class DAL_TimKiem : KetNoi
    {
        public DataTable TimKiem(string maSV, string tenSV, string tenLop, string tenNganh, string tenKhoa)
        {
            string sql = @"
                SELECT sv.Ma AS MaSV, sv.Ten AS TenSV, sv.NgaySinh, l.Ten AS Lop, n.TenNganh, k.TenKhoa
                FROM SinhVien sv
                INNER JOIN LopHoc l ON sv.ID_LopHoc = l.ID
                INNER JOIN NganhHoc n ON l.ID_NganhHoc = n.ID
                INNER JOIN KhoaHoc k ON n.ID_KhoaHoc = k.ID
                WHERE 1=1 ";

            if (!string.IsNullOrWhiteSpace(maSV))
                sql += $" AND sv.Ma LIKE N'%{maSV}%' ";
            if (!string.IsNullOrWhiteSpace(tenSV))
                sql += $" AND sv.Ten LIKE N'%{tenSV}%' ";
            if (!string.IsNullOrWhiteSpace(tenLop))
                sql += $" AND l.Ten LIKE N'%{tenLop}%' ";
            if (!string.IsNullOrWhiteSpace(tenNganh))
                sql += $" AND n.TenNganh LIKE N'%{tenNganh}%' ";
            if (!string.IsNullOrWhiteSpace(tenKhoa))
                sql += $" AND k.TenKhoa LIKE N'%{tenKhoa}%' ";

            return LoadTable(sql);
        }
    }
}
