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
    public partial class FormMDI : Form
    {
        public FormMDI()
        {
            InitializeComponent();
            this.IsMdiContainer = true;

        }
   
        private void khóaHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKhoaHoc f = new FormKhoaHoc();
            f.QuyenNguoiDung = Global.Quyen;
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void ngànhHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNganhHoc f = new FormNganhHoc();
            f.QuyenNguoiDung = Global.Quyen;
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void họcKỳToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHocKy f = new FormHocKy();
            f.QuyenNguoiDung = Global.Quyen;
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void hìnhThứcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHinhTHuc f = new FormHinhTHuc();
            f.QuyenNguoiDung = Global.Quyen;
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void mônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMonHoc f = new FormMonHoc();
            f.QuyenNguoiDung = Global.Quyen;
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void lớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLopHoc f = new FormLopHoc();
            f.QuyenNguoiDung = Global.Quyen;
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void sinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSinhVien f = new FormSinhVien();
            f.QuyenNguoiDung = Global.Quyen;
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void lầnThiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDotThi f = new FormDotThi();
            f.QuyenNguoiDung = Global.Quyen;
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show(); ;
        }

        private void điểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDiem f = new FormDiem();
            f.QuyenNguoiDung = Global.Quyen;
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void doimatkhau_Click(object sender, EventArgs e)
        {
            FormDoiMatKhau f = new FormDoiMatKhau();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void btnQuanLyNguoiDung_Click(object sender, EventArgs e)
        {
            FormQuanLyNguoiDung f = new FormQuanLyNguoiDung();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void đăngNhậpToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormDangNhap f = new FormDangNhap();
            f.IsMdiContainer = true;
            f.Show();
        }

        private void FormMDI_Load_1(object sender, EventArgs e)
        {

            label4.Text = Global.Ten + Environment.NewLine +
                              " --" + Global.Quyen + "--";

            if (Global.Quyen == "Admin")
            {
                label4.ForeColor = Color.DarkBlue;
                menuStrip1.Enabled = true;
                btnQuanLyNguoiDung.Visible = true; // Admin thấy
            }
            else if (Global.Quyen == "Giáo viên")
            {
                label4.ForeColor = Color.Green;
                menuStrip1.Enabled = true;
                btnQuanLyNguoiDung.Visible = false; // Giáo viên không thấy nút quản lý người dùng
            }
            else
            {
                label4.ForeColor = Color.Black;
                menuStrip1.Enabled = true;
                btnQuanLyNguoiDung.Visible = false; // Mặc định cũng không cho
            }

        }

        private void thôngTinToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void chươngTrìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChuongTrinh f = new FormChuongTrinh();
           
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void bảngĐiểmCủaMộtSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FormBangDiemCaNhan();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void cácMônChưaĐạtToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            var frm = new FormMonChuaDat();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void bảngĐiểmLớpMônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FormBangDiemLop_Mon();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTimKiem f = new FormTimKiem();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }
    }

}
