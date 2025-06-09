using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;

namespace DTO
{
    public class Modify
    {
        public Modify() // Correct constructor syntax  
        {
        }

        private SqlCommand SqlCommand;
        private SqlDataReader dataReader;

        public SqlConnection GetSqlConnection()
        {
            string connectionString = "Data Source=DESKTOP-25KM0HC\\MSSQLSERVER02;Initial Catalog=DATN;Integrated Security=True";
            return new SqlConnection(connectionString);
        }

        // Change method name to PascalCase and fix accessibility of TaiKhoan  
        public List<TaiKhoan> TaiKhoan(string query, string tenDangNhap, string matKhau = null)
        {
            List<TaiKhoan> taiKhoan = new List<TaiKhoan>();
            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);

                // CHỈ THÊM @MatKhau NẾU CÂU QUERY CÓ SỬ DỤNG  
                if (query.Contains("@MatKhau"))
                {
                    sqlCommand.Parameters.AddWithValue("@MatKhau", matKhau);
                }

                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        taiKhoan.Add(new TaiKhoan(
                            dataReader["TenDangNhap"].ToString(),
                            dataReader["MatKhau"].ToString(),
                            dataReader["Quyen"].ToString() // Added the missing 'Quyen' parameter  
                        ));
                    }
                }
            }
            return taiKhoan;
        }

        public void Command(string query) //dùng đk    
        {
            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery(); //thucthicautruyvan    
                sqlConnection.Close(); // Corrected to use the instance of sqlConnection    
            }
        }
        public string LayQuyenNguoiDung(string tenDangNhap)
        {
            string quyen = "";
            string query = "SELECT Quyen FROM TAIKHOAN WHERE TenDangNhap = @TenDangNhap";
            using (SqlConnection conn = GetSqlConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);

                object result = cmd.ExecuteScalar();
                if (result != null)
                    quyen = result.ToString();
            }
            return quyen;
        }
    }
}