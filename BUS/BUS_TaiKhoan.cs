using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BUS
{
    public class BUS_TaiKhoan
    {
        private KetNoi _ketNoi = new KetNoi(); // Khởi tạo đối tượng KetNoi

        public DataTable GetTaiKhoanByCredentials(string username, string password)
        {
            // CẢNH BÁO QUAN TRỌNG: Vẫn sử dụng nối chuỗi. Rủi ro SQL Injection!
            // Tuy nhiên, lỗi hiện tại là do sai tên cột.

            // Tên cột đã được sửa trong truy vấn SQL
            string query = "SELECT ID, TenDangNhap, MaKhau, Quyen, GhiChu FROM TaiKhoan WHERE TenDangNhap = N'" + username + "' AND MaKhau = N'" + password + "'";

            try
            {
                DataTable dt = _ketNoi.Load_Table(query);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy tài khoản theo thông tin đăng nhập: {ex.Message}");
                throw new Exception("Lỗi khi xác thực tài khoản.", ex);
            }
        }

        public TaiKhoan GetTaiKhoanById(int id)
        {
            // Tên cột đã được sửa trong truy vấn SQL
            string query = "SELECT ID, TenDangNhap, MaKhau, Quyen, GhiChu FROM TaiKhoan WHERE ID = " + id;

            try
            {
                DataTable dt = _ketNoi.Load_Table(query);
                TaiKhoan taiKhoan = null;
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    taiKhoan = new TaiKhoan(
                        Convert.ToInt32(row["ID"]),
                        row["TenDangNhap"].ToString(), // <--- ĐÃ SỬA LỖI TẠI ĐÂY (từ "TenDangN..." thành "TenDangNhap")
                        row["MaKhau"].ToString(),
                        row["Quyen"].ToString(),
                        row["GhiChu"].ToString()
                    );
                }
                return taiKhoan;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy tài khoản theo ID: {ex.Message}");
                throw new Exception("Lỗi khi lấy tài khoản.", ex);
            }
        }
    }
}
