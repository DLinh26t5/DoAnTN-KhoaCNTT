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
                
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Global.Quyen == "Admin")
            {
                label4.Text = Global.TenDangNhap + Environment.NewLine +
                              " --" + Global.Quyen + "--";
                label4.ForeColor = Color.DarkBlue;

                menuStrip1.Enabled = true;
               
            }
            else
            {
                label4.Text = Global.TenDangNhap + Environment.NewLine +
                              " --" + Global.Quyen + "--";
                label4.ForeColor = Color.Black;

                btnQuanLyNguoiDung.Visible = false;
                menuStrip1.Enabled = true;
            }
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
            f.Show(); ;
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
            FormHinhThuc f = new FormHinhThuc();
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

        private void lớpHọcToolStripMenuItem_Click(object sender, EventArgs e)
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
            FormLanThi f = new FormLanThi();
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

        private void toolStripLabelSV_Click(object sender, EventArgs e)
        {
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void doimatkhau_Click(object sender, EventArgs e)
        {
            FormDoiMatKhau f = new FormDoiMatKhau();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

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
