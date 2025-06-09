using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace ĐOAN_QLBD
{
    public partial class FormHinhThuc : Form
    {
        public FormHinhThuc()
        {
            InitializeComponent();
        }
        
        BUS_HinhThuc busht  = new BUS_HinhThuc();
        private void FormHinhThuc_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = busht.LoadHthuc();
            Loadcomboboxkhoa();
        }
        private void Loadcomboboxkhoa()
        {BUS_KhoaHoc buskhoa = new BUS_KhoaHoc();
            DataTable dt = buskhoa.LoadKhoa();
            comboBoxTenKhoa.DisplayMember = "TenKhoa";
            comboBoxTenKhoa.ValueMember = "ID";
            comboBoxTenKhoa.DataSource = dt;
        }

        private void comboBoxTenKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)comboBoxTenKhoa.SelectedValue;
            LoadNganh(id);
        }
        private void LoadNganh(int id)
        {
            BUS_NganhHoc busN = new BUS_NganhHoc();
            DataTable dt = busN.GetNganhbyKhoa(id);
            comboBoxTenNganh.DisplayMember = "TenNganh";
            comboBoxTenNganh.ValueMember = "id";
            comboBoxTenNganh.DataSource = dt;
        }

        private void comboBoxTenNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Id = (int)comboBoxTenNganh.SelectedValue;
            LoadHk(Id);
        }
        private void LoadHk(int Id)
        {
            BUS_HocKy bus = new BUS_HocKy();
            DataTable dt = bus.Gethkybynganh(Id);
            comboBoxHocKy.DisplayMember = "TenHocKy";
            comboBoxHocKy.ValueMember = "ID";
            comboBoxHocKy.DataSource = dt;
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            HinhTHuc ht = new HinhTHuc();
            ht.HinhThuc = textBoxHinhThuc.Text; 
            ht.ID_HocKy = Convert.ToInt32(comboBoxHocKy.SelectedValue);
            busht.Insert(ht);
            dataGridView1.DataSource = busht.LoadHthuc();
        }
        private int ID_select = -1;
        private void buttonSua_Click(object sender, EventArgs e)
        {
            HinhTHuc ht = new HinhTHuc();
            ht.HinhThuc = textBoxHinhThuc.Text;
            ht.ID_HocKy = Convert.ToInt32(comboBoxTenNganh.SelectedValue);
            ht.ID = ID_select;
            busht.Update(ht);
            dataGridView1.DataSource = busht.LoadHthuc();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            HinhTHuc ht = new HinhTHuc();
            ht.HinhThuc = textBoxHinhThuc.Text;
            ht.ID_HocKy = Convert.ToInt32(comboBoxTenNganh.SelectedValue);
            ht.ID = ID_select;
            busht.Delete(ht);
            dataGridView1.DataSource = busht.LoadHthuc();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID_select = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
            textBoxHinhThuc.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBoxHocKy.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
