using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DTO;

namespace ĐOAN_QLBD
{
    public partial class FormDangNhap : Form
    {
        public bool IsAuthenticated { get; private set; } = false;

        private Modify modify;
        public FormDangNhap()
        {
            InitializeComponent();
            modify = new Modify();
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            // Nếu muốn focus textbox thì làm ở đây
            textBoxTenDN.Focus();

        }

        // The issue with the provided code is a syntax error in the SQL query string and improper concatenation.  
        // Corrected code:  

        private void buttonDangNhap_Click(object sender, EventArgs e)
        {

            string tenDangNhap = textBoxTenDN.Text.Trim();
            string matKhau = textBoxMatKhau.Text.Trim();

            if (tenDangNhap == "")
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!");
                return;
            }
            if (matKhau == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                return;
            }

            string query = "SELECT * FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";
            List<TaiKhoan> list = modify.TaiKhoan(query, tenDangNhap, matKhau);
            if (list.Count > 0)
            {
                // Gán tài khoản cho biến toàn cục
                Global.TenDangNhap = tenDangNhap;

                // Lấy quyền từ CSDL
                string quyenQuery = "SELECT Quyen FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
                using (SqlConnection conn = GetSqlConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(quyenQuery, conn);
                    cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    Global.Quyen = cmd.ExecuteScalar()?.ToString(); // Gán quyền
                }

                ClassDN.DangNhap = false;
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                MDI mdi = new MDI();
                mdi.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel_QuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormQuenMatKhau f = new FormQuenMatKhau();
            f.Show();
        }

        private void linkLabel_DangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormDangKy f = new FormDangKy();
            f.Show();
        }
        public List<TaiKhoan> TaiKhoans(string query, string tenDangNhap, string matKhau)
        {
            List<TaiKhoan> taiKhoans = new List<TaiKhoan>();
            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                sqlCommand.Parameters.AddWithValue("@MatKhau", matKhau);

                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        taiKhoans.Add(new TaiKhoan(dataReader.GetString(0), dataReader.GetString(1)));
                    }
                }
            }
            return taiKhoans;
        }

        private SqlConnection GetSqlConnection()
        {
            // Replace with your actual connection string  
            string connectionString = "Data Source=DESKTOP-25KM0HC\\MSSQLSERVER02;Initial Catalog=DATN;Integrated Security=True";
            return new SqlConnection(connectionString);
        }

    }
}


        

