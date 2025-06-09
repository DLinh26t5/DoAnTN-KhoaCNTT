using DTO;
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
    public partial class FormQuanLyNguoiDung : Form
    {
        public FormQuanLyNguoiDung()
        {
            InitializeComponent();
            Modify modify = new Modify();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormQuanLyNguoiDung_Load(object sender, EventArgs e)
        {
            cmbQuyen.Items.Add("Admin");
            cmbQuyen.Items.Add("User");
            cmbQuyen.SelectedIndex = 0;

            LoadData();
        }
        private void LoadData()
        {
            dgvTaiKhoan.DataSource = Modify.TaiKhoan();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = new TaiKhoan(txtTenDangNhap.Text, txtMatKhau.Text, cmbQuyen.Text);
            if (Modify.ThemTaiKhoan(tk))
            {
                MessageBox.Show("Thêm tài khoản thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show("Không thể thêm tài khoản!");
            }
        }
        // Example for Modify.cs
  
    }
}
