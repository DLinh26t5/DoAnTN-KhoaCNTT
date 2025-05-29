using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }

        public string tenDangNhap { get; internal set; }

        private void buttonDangNhap_Click(object sender, EventArgs e)
        {

            string username = textBoxTenDN.Text;
            string password = textBoxMatKhau.Text;

            if (username == "admin" && password == "123")
            {
                this.tenDangNhap = username; // Sửa lỗi gán đúng biến
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
 
