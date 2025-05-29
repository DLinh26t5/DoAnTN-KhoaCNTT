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
            f.IsMdiContainer = true;
            f.Show();
        }

        private void ngànhHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNganhHoc f = new FormNganhHoc();
            f.IsMdiContainer = true;
            f.Show();
        }

        private void họcKỳToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHocKy f = new FormHocKy();
            f.IsMdiContainer= true;
            f.Show();
        }

        private void hìnhThứcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHinhThuc f = new FormHinhThuc();
            f.IsMdiContainer = true;
            f.Show();
        }

        private void mônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMonHoc f = new FormMonHoc();
            f.IsMdiContainer = true;
            f.Show();
        }

        private void lớpHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLopHoc f = new FormLopHoc();
            f.IsMdiContainer= true;
            f.Show();
        }

        private void sinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSinhVien f = new FormSinhVien();
            f.IsMdiContainer= true;
            f.Show();
        }

        private void lầnThiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLanThi f = new FormLanThi();
            f.IsMdiContainer= true;
            f.Show();
        }

        private void điểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDiem f = new FormDiem();
            f.IsMdiContainer= true;
            f.Show();
        }

        private void toolStripLabelSV_Click(object sender, EventArgs e)
        {
        }
           
    }
}
