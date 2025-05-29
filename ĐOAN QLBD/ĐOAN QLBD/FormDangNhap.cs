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
        public bool IsAuthenticated {  get;private set; }=false;
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            if (textBoxTenDN.Text == "BuiThiDieuLinh" && textBoxMatKhau.Text == "123456")
            {
                ClassDN.dangnhap = true;
                //MessageBox.Show("Đăng nhâp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                ClassDN.dangnhap = false;
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng","Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                /*textBoxMatKhau.Clear();
                textBoxMatKhau.Focus();*/
            }
            
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            
        }
    }
}

        

