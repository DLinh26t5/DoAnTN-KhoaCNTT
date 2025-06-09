using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KetNoi
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-25KM0HC\MSSQLSERVER02;Initial Catalog=DATN;Integrated Security=True");
        public DataTable Load_Table(String sql)
        {
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();
            return dt;
        }
        public void Excecute(String sql)
        {
            if (con.State == ConnectionState.Open) con.Close();
            con.Open();
            SqlCommand ThucHien = new SqlCommand(sql, con);
            ThucHien.ExecuteNonQuery();
            con.Close();
        }
        public void Executee(SqlCommand cmd, DataTable dt)
        {
            // Mở kết nối đến cơ sở dữ liệu
            con.Open();
            cmd.Connection = con; // Gán kết nối cho câu lệnh
            SqlDataAdapter da = new SqlDataAdapter(cmd); // Thực thi câu lệnh SQL
            da.Fill(dt);
            con.Close(); // Đóng kết nối
        }
    }
}
