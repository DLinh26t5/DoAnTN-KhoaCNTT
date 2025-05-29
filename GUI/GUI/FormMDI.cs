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
    public partial class FormMDI : Form
    {
        private string tenDangNhap;

        public FormMDI(string tenDangNhap)
        {
            InitializeComponent();
            this.tenDangNhap = tenDangNhap;
        }

        private void FormMDI_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Xin chào, " + tenDangNhap + "!";
        }

        public FormMDI()
        {
            InitializeComponent();
        }
        private void lblWelcome_Click(object sender, EventArgs e)
        {
        }

        private void FormMDI_Load_1(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
          
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Formtrangchu F = new Formtrangchu();
            F.MdiParent = this;
        }
    }
}
