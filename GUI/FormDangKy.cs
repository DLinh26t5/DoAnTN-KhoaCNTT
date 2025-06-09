using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace ĐOAN_QLBD
{
    public partial class FormDangKy : Form
    {
        private Modify modify; // Declare an instance of Modify  

        public FormDangKy()
        {
            InitializeComponent();
            modify = new Modify(); // Initialize the Modify instance  
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public bool CheckAccount(string ac) //check mat khau va ten dn  
        {
            return Regex.IsMatch(ac, "^[a-zA-Z0-9]{6,24}$");
        }

        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = textBoxTenDN.Text.Trim();
            string matKhau = textBoxMatKhau.Text.Trim();
            string xnmatKhau = textBoxXnMatKhau.Text.Trim();

            // Kiểm tra không để trống
            if (string.IsNullOrEmpty(tenDangNhap))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!");
                return;
            }

            if (string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu trên 6 ký tự!");
                return;
            }

            if (!CheckAccount(tenDangNhap))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!");
                return;
            }

            if (!CheckAccount(matKhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                return;
            }

            if (matKhau != xnmatKhau)
            {
                MessageBox.Show("Xác nhận mật khẩu không trùng khớp!");
                return;
            }

            // Kiểm tra tài khoản đã tồn tại chưa
            string checkQuery = "SELECT * FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
            // Update the method call to include the required 'matKhau' parameter.  
            var listTK = modify.TaiKhoan(checkQuery, tenDangNhap, matKhau);

            if (listTK.Count > 0)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác!");
                return;
            }

            // Thêm tài khoản mới
            try
            {
                string insertQuery = "INSERT INTO TaiKhoan (TenDangNhap, MatKhau) VALUES (@TenDangNhap, @MatKhau)";
                using (SqlConnection conn = modify.GetSqlConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                        cmd.Parameters.AddWithValue("@MatKhau", matKhau);
                        cmd.ExecuteNonQuery();
                    }
                }

                if (MessageBox.Show("Đăng ký thành công! Bạn có muốn đăng nhập không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng ký tài khoản: " + ex.Message);
            }
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormDangKy_Load(object sender, EventArgs e)
        {

        }
    }
}
