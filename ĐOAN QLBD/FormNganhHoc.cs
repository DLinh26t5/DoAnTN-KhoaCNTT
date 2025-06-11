using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ĐOAN_QLBD
{
    public partial class FormNganhHoc : Form
    {
        public string QuyenNguoiDung { get; internal set; }
        BUS_KhoaHoc buskhoa = new BUS_KhoaHoc();
        BUS_NganhHoc busnganh = new BUS_NganhHoc();
        public FormNganhHoc()
        {
            InitializeComponent();
        }

        private void FormNganhHoc_Load(object sender, EventArgs e)
        {
            if (QuyenNguoiDung != "Admin")
            {
                buttonThem.Enabled = false;
                buttonSua.Enabled = false;
                buttonXoa.Enabled = false;
            }
            comboBoxKhoaHoc.DataSource = buskhoa.LoadKhoa();
            comboBoxKhoaHoc.DisplayMember = "TenKhoa";
            comboBoxKhoaHoc.ValueMember = "ID";
            dataGridView1.DataSource = busnganh.LoadNganh();
            textBoxNganhHoc.Clear();
            comboBoxKhoaHoc.SelectedIndex = -1;
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            NganhHoc n = new NganhHoc(0, textBoxNganhHoc.Text, Convert.ToInt32(comboBoxKhoaHoc.SelectedValue.ToString()));
            busnganh.Insert(n);
            dataGridView1.DataSource = busnganh.LoadNganh();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            NganhHoc n = new NganhHoc(Convert.ToInt32(textBoxID.Text), textBoxNganhHoc.Text, Convert.ToInt32(comboBoxKhoaHoc.SelectedValue.ToString()));
            busnganh.Update(n);
            dataGridView1.DataSource = busnganh.LoadNganh();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            NganhHoc n = new NganhHoc(Convert.ToInt32(textBoxID.Text), textBoxNganhHoc.Text, Convert.ToInt32(comboBoxKhoaHoc.SelectedValue.ToString()));
            busnganh.Delete(n);
            FormNganhHoc_Load(sender, e);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxNganhHoc.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBoxKhoaHoc.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
