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
    public partial class FormQuanLyNguoiDung : Form
    {
        private Modify modify; // Declare an instance of Modify  
        public FormQuanLyNguoiDung()
        {
            InitializeComponent();
            modify = new Modify(); // Initialize the Modify instance  
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
            dgvTaiKhoan.DataSource = modify.GetAllTaiKhoan();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = new TaiKhoan(txtTenDangNhap.Text, txtMatKhau.Text, cmbQuyen.Text);
            if (modify.ThemTaiKhoan(tk))
            {
                MessageBox.Show("Thêm tài khoản thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show("Không thể thêm tài khoản!");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            TaiKhoan tk = new TaiKhoan(txtTenDangNhap.Text, txtMatKhau.Text, cmbQuyen.Text);
            if (modify.ThemTaiKhoan(tk))
            {
                MessageBox.Show("Thêm tài khoản thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show("Không thể thêm tài khoản!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = new TaiKhoan(txtTenDangNhap.Text, txtMatKhau.Text, cmbQuyen.Text);
            if (modify.SuaTaiKhoan(tk))
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (modify.XoaTaiKhoan(txtTenDangNhap.Text))
            {
                MessageBox.Show("Xóa tài khoản thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show("Xóa thất bại!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không click vào header
            {
                DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];

                txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
                cmbQuyen.Text = row.Cells["Quyen"].Value.ToString();
            }
        }
    }
}
