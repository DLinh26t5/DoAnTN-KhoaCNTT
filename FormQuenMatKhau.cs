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

namespace QLBD
{
    public partial class FormQuenMatKhau : Form
    {

        private Modify modify;
        public FormQuenMatKhau()
        {
            InitializeComponent();
            label3.Text = "";
            modify = new Modify(); // Initialize the Modify instance  
        }

        private void FormQuenMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            string Ten = textBoxTenDN.Text.Trim();
            if (Ten == "")
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!");
                return;
            }

            // Use parameterized query for security
            string query = "SELECT * FROM TaiKhoan WHERE Ten = @Ten";
            var accounts = modify.TaiKhoan(query, Ten, "");

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
