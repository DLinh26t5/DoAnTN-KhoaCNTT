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
        BUS_HocKy bushky = new BUS_HocKy();
        BUS_NganhHoc busnganh = new BUS_NganhHoc();
        BUS_KhoaHoc busKhoa = new BUS_KhoaHoc();
        public FormHocKy()
        {
            InitializeComponent();
        }

        private void FormHocKy_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bushky.Load();
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
            if (comboBoxKhoaHoc.SelectedValue is int id)
            {
                int Id = (int)comboBoxKhoaHoc.SelectedValue;
                LoadNganh(Id);
            }
        }
        private void LoadNganh(int Id)
        {
            BUS_NganhHoc busnganh = new BUS_NganhHoc();
            DataTable dt = busnganh.GetNganhbyKhoa(Id);
            comboBoxKhoaHoc.DisplayMember = "TenNganh";
            comboBoxKhoaHoc.ValueMember = "ID";
            comboBoxKhoaHoc.DataSource = dt;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID_select = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
            comboBoxKhoaHoc.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBoxNganhHoc.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxHocKy.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

        }
    }
}
