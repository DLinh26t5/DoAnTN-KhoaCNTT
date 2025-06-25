using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class Modify
    {
        public Modify() // Correct constructor syntax  
        {
        }

        SqlCommand SqlCommand;
        SqlDataReader dataReader;

        public SqlConnection GetSqlConnection()
        {
            return DTO.KetNoi.CreateConnection();
        }

        // Change method name to PascalCase and fix accessibility of TaiKhoan  
        public List<TaiKhoan> TaiKhoan(string query, string Ten, string matKhau=null)
        {
            List<TaiKhoan> taiKhoan = new List<TaiKhoan>();
            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Ten", Ten);

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
                            dataReader["Ten"].ToString(),
                            dataReader["MatKhau"].ToString(),
                            dataReader["Quyen"].ToString()
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
        public string QuyenNguoiDung(string Ten)
        {
            string quyen = "";
            string query = "SELECT Quyen FROM TAIKHOAN WHERE Ten = @Ten";
            using (SqlConnection conn = GetSqlConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Ten", Ten);

                object result = cmd.ExecuteScalar();
                if (result != null)
                    quyen = result.ToString();
            }
            return quyen;
        }
        public List<TaiKhoan> GetAllTaiKhoan()
        {
            List<TaiKhoan> list = new List<TaiKhoan>(); // Corrected variable name to 'list'  
            using (SqlConnection conn = GetSqlConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM TaiKhoan", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new TaiKhoan( // Corrected variable name to 'list'  
                        Convert.ToString(reader["Ten"]), // Corrected 'dataReader' to 'reader'  
                        Convert.ToString(reader["MatKhau"]),
                        Convert.ToString(reader["Quyen"])
                        
                    ));
                }
            }
            return list;
        }

        // Replace all occurrences of 'GetConnection()' with 'GetSqlConnection()' to fix the error.  
        public bool ThemTaiKhoan(TaiKhoan tk)
        {
            using (SqlConnection conn = GetSqlConnection()) // Fixed method name  
            {
                conn.Open();
                string query = "INSERT INTO TaiKhoan (Ten, MatKhau, Quyen ) VALUES (@Ten, @MatKhau, @Quyen)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Ten", tk.Ten);
                cmd.Parameters.AddWithValue("@MatKhau", tk.MatKhau);
                cmd.Parameters.AddWithValue("@Quyen", tk.Quyen);
              

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool SuaTaiKhoan(TaiKhoan tk)
        {
            using (SqlConnection conn = GetSqlConnection()) // Fixed method name  
            {
                conn.Open();
                string query = "UPDATE TaiKhoan SET MatKhau=@MatKhau, Quyen=@Quyen WHERE Ten=@Ten";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Ten", tk.Ten);
                cmd.Parameters.AddWithValue("@MatKhau", tk.MatKhau);
                cmd.Parameters.AddWithValue("@Quyen", tk.Quyen);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool XoaTaiKhoan(string Ten)
        {
            using (SqlConnection conn = GetSqlConnection()) // Fixed method name  
            {
                conn.Open();
                string query = "DELETE FROM TaiKhoan WHERE Ten=@Ten";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Ten", Ten);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}