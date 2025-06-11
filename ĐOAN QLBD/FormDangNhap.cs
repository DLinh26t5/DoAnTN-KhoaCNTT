using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using DTO;
using DAL;

namespace ĐOAN_QLBD
{
    public partial class FormDangNhap : Form
    {
        Modify modify = new Modify();
        public bool IsAuthenticated { get; private set; } = false;

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

        private void buttonThoat_Click(object sender, EventArgs e)
        {

        }

        private SqlConnection GetSqlConnection()
        {
            // Replace with your actual connection string    
            string connectionString = "Data Source=DESKTOP-25KM0HC\\MSSQLSERVER02;Initial Catalog=DoAnTotNghiep;Integrated Security=True";
            return new SqlConnection(connectionString);
        }

        private void buttonDangNhap_Click_1(object sender, EventArgs e)
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
    }

}



