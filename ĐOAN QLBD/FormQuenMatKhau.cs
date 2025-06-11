using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ĐOAN_QLBD
{
    public partial class FormQuenMatKhau : Form
    {
        private Modify modify; // Declare an instance of Modify  
        public FormQuenMatKhau()
        {
            InitializeComponent();
            label3.Text = "";
            modify = new Modify(); // Initialize the Modify instance  
        }

        private void FormQuenMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = textBoxTenDN.Text.Trim();
            if (tenDangNhap == "")
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!");
                return;
            }

            // Use parameterized query for security
            string query = "SELECT * FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
            var accounts = modify.TaiKhoan(query, tenDangNhap, "");

            if (accounts.Count > 0)
            {
                label3.ForeColor = Color.Blue;
                label3.Text = "Mật khẩu: " + accounts[0].MatKhau;
            }
            else
            {
                label3.ForeColor = Color.Red;
                label3.Text = "Tên đăng nhập này chưa được đăng ký!";
            }
        }
    }
}
