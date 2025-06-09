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
    public partial class MDI : Form
    {
        public MDI()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDangNhap f = new FormDangNhap();
            f.IsMdiContainer = true;
            f.Show();
        }

        private void MDI_Load(object sender, EventArgs e)
        {
            if (Global.Quyen == "Admin")
            {
                label4.Text = Global.TenDangNhap + Environment.NewLine +
                              " --" + Global.Quyen + "--";
                label4.ForeColor = Color.DarkBlue;

                btnQuanLyNguoiDung.Visible = true;
            }
            else
            {
                label4.Text = Global.TenDangNhap + " (" + Global.Quyen + ")";
                label4.ForeColor = Color.Black;

                btnQuanLyNguoiDung.Visible = false;
            }
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.khóaHọcToolStripMenuItem.Enabled = ClassDN.dangnhap;
            this.ngànhHọcToolStripMenuItem.Enabled = ClassDN.dangnhap;
            this.hìnhThứcToolStripMenuItem.Enabled = ClassDN.dangnhap;
            this.họcKỳToolStripMenuItem.Enabled = ClassDN.dangnhap;
            this.lớpHọcToolStripMenuItem.Enabled = ClassDN.dangnhap;
            this.lầnThiToolStripMenuItem.Enabled = ClassDN.dangnhap;
            this.mônHọcToolStripMenuItem.Enabled = ClassDN.dangnhap;
            this.sinhViênToolStripMenuItem.Enabled = ClassDN.dangnhap;
            this.điểmToolStripMenuItem.Enabled = ClassDN.dangnhap;
        }

        private void khóaHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKhoaHoc f = new FormKhoaHoc();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void ngànhHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNganhHoc f = new FormNganhHoc();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void họcKỳToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHocKy f = new FormHocKy();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void hìnhThứcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHinhThuc f = new FormHinhThuc();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void mônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMonHoc f = new FormMonHoc();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void lớpHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLopHoc f = new FormLopHoc();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void sinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSinhVien f = new FormSinhVien();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void lầnThiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLanThi f = new FormLanThi();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void điểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDiem f = new FormDiem();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void toolStripLabelSV_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormĐoiMatKhau f = new FormĐoiMatKhau();
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
    }
}
