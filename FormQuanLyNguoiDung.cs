using DAL;
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

namespace QLBD
{
    public partial class FormQuanLyNguoiDung : Form
    {
        private Modify modify;
        public FormQuanLyNguoiDung()
        {
            InitializeComponent();
            modify = new Modify();
        }

        private void FormQuanLyNguoiDung_Load(object sender, EventArgs e)
        {
            cmbQuyen.Items.Add("Admin");
            cmbQuyen.Items.Add("User");
            cmbQuyen.Items.Add("GiaoVien");
            cmbQuyen.SelectedIndex = 0;

            LoadData();
        }
        private void LoadData()
        {
            dgvTaiKhoan.DataSource = modify.GetAllTaiKhoan();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {

            TaiKhoan tk = new TaiKhoan(txtTen.Text, txtMatKhau.Text, cmbQuyen.Text);
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            TaiKhoan tk = new TaiKhoan(txtTen.Text, txtMatKhau.Text, cmbQuyen.Text);
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

        private void button3_Click_1(object sender, EventArgs e)
        {

            if (modify.XoaTaiKhoan(txtTen.Text))
            {
                MessageBox.Show("Xóa tài khoản thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show("Xóa thất bại!");
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvTaiKhoan_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không click vào header
            {
                DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];

                txtTen.Text = row.Cells["Ten"].Value.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
                cmbQuyen.Text = row.Cells["Quyen"].Value.ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
