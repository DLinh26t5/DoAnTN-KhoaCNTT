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
    public partial class FormDiem : Form
    {
        public string QuyenNguoiDung { get; internal set; }
        public FormDiem()
        {
            InitializeComponent();
        }

        private void FormDiem_Load(object sender, EventArgs e)
        {
            if (QuyenNguoiDung != "Admin")
            {
                buttonLưu.Enabled = false;
            }
        }
    }
}
