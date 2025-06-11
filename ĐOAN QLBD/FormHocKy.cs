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
using BUS;

namespace ĐOAN_QLBD
{
    public partial class FormHocKy : Form
    {
        public string QuyenNguoiDung { get; internal set; }
        BUS_HocKy bushky = new BUS_HocKy();
        BUS_NganhHoc busnganh = new BUS_NganhHoc();
        BUS_KhoaHoc busKhoa = new BUS_KhoaHoc();
        public FormHocKy()
        {
            InitializeComponent();
        }

        private void FormHocKy_Load(object sender, EventArgs e)
        {
            if (QuyenNguoiDung != "Admin")
            {
                buttonThem.Enabled = false;
                buttonSua.Enabled = false;
                buttonXoa.Enabled = false;
            }
            dataGridView1.DataSource = bushky.Load();
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Khóa học";
            dataGridView1.Columns[2].HeaderText = "Học kỳ";
            dataGridView1.Columns[3].HeaderText = "Ngành học";
            LoadKhoatocombobox();
        }
        private void LoadKhoatocombobox()
        {
            DataTable dt = busKhoa.LoadKhoa();
            comboBoxKhoaHoc.DisplayMember = "TenKhoa";
            comboBoxKhoaHoc.ValueMember = "ID";
            comboBoxKhoaHoc.DataSource = dt;
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            HocKy hk = new HocKy(textBoxHocKy.Text, Convert.ToInt32(comboBoxNganhHoc.SelectedValue.ToString()));
            bushky.Insert(hk);
            dataGridView1.DataSource = bushky.Load();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            HocKy hk = new HocKy();
            hk.TenHocKy = textBoxHocKy.Text;
            hk.ID_NganhHoc = Convert.ToInt32(comboBoxNganhHoc.SelectedValue);
            hk.ID = ID_select;
            bushky.Update(hk);
            dataGridView1.DataSource = bushky.Load();
        }
        private int ID_select = -1;
        private void buttonXoa_Click(object sender, EventArgs e)
        {
            HocKy hk = new HocKy();
            hk.TenHocKy = textBoxHocKy.Text;
            hk.ID_NganhHoc = Convert.ToInt32(comboBoxNganhHoc.SelectedValue);
            hk.ID = ID_select;
            bushky.Delete(hk);
            dataGridView1.DataSource = bushky.Load();
        }

        private void comboBoxKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxKhoaHoc.SelectedValue != null && int.TryParse(comboBoxKhoaHoc.SelectedValue.ToString(), out int id))
            {
                LoadNganh(id);
            }
        }
        private void LoadNganh(int Id)
        {
            DataTable dt = busnganh.GetNganhbyKhoa(Id);
            comboBoxNganhHoc.DisplayMember = "TenNganh";
            comboBoxNganhHoc.ValueMember = "ID";
            comboBoxNganhHoc.DataSource = dt;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView1.Columns[0].Visible = false;
                ID_select = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                comboBoxKhoaHoc.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(); // TenKhoa
                textBoxHocKy.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();     // TenHocKy
                comboBoxNganhHoc.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(); // TenNganh
            }

        }
    }
}
