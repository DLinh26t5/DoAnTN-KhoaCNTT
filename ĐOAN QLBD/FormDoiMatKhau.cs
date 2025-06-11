using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ĐOAN_QLBD
{
    public partial class FormDoiMatKhau : Form
    {
        private Modify modify; // Declare the 'modify' field  
        public FormDoiMatKhau()
        {
            InitializeComponent();
            modify = new Modify();
        }

        private void FormDoiMatKhau_Load(object sender, EventArgs e)
        {
            textBoxTenDN.Text = Global.TenDangNhap;
            textBoxTenDN.Enabled = false; // khóa để không sửa tên đăng nhập
        }

        private void buttonDoiMatKhau_Click(object sender, EventArgs e)
        {
            string tenDN = Global.TenDangNhap;
            string matKhauCu = textBoxMKCu.Text;
            string matKhauMoi = textBoxMKMoi.Text;
            string xacNhanMK = textBoxXNMKMoi.Text;

            if (matKhauCu == "" || matKhauMoi == "" || xacNhanMK == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các trường!");
                return;
            }

            if (matKhauMoi != xacNhanMK)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận không khớp!");
                return;
            }

            string query = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @TenDN AND MatKhau = @MKCu";
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-25KM0HC\\MSSQLSERVER02;Initial Catalog=DATN;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@TenDN", tenDN);
            cmd.Parameters.AddWithValue("@MKCu", matKhauCu);

            conn.Open();
            int count = (int)cmd.ExecuteScalar();
            conn.Close();

            if (count == 1)
            {
                // Đổi mật khẩu
                string update = "UPDATE TaiKhoan SET MatKhau = @MKMoi WHERE TenDangNhap = @TenDN";
                SqlCommand updateCmd = new SqlCommand(update, conn);
                updateCmd.Parameters.AddWithValue("@TenDN", tenDN);
                updateCmd.Parameters.AddWithValue("@MKMoi", matKhauMoi);
                conn.Open();
                updateCmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Đổi mật khẩu thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không đúng!");
            }
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
