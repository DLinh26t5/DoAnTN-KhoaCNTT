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
        public string QuyenNguoiDung { get; internal set; }
        BUS_HinhThuc busht  = new BUS_HinhThuc();
        private void FormHinhThuc_Load(object sender, EventArgs e)
        {
            if (QuyenNguoiDung != "Admin")
            {
                buttonThem.Enabled = false;
                buttonSua.Enabled = false;
                buttonXoa.Enabled = false;
            }
            dataGridView1.DataSource = busht.LoadHthuc();
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["TenKhoa"].HeaderText = "Khóa học";
            dataGridView1.Columns["HinhThuc"].HeaderText = "Hình thức";
            dataGridView1.Columns["TenHocKy"].HeaderText = "Học kỳ";
            dataGridView1.Columns["TenNganh"].HeaderText = "Ngành";
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
            if (e.RowIndex >= 0)
            {
                ID_select = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
                comboBoxTenKhoa.Text = dataGridView1.Rows[e.RowIndex].Cells["TenKhoa"].Value.ToString();
                textBoxHinhThuc.Text = dataGridView1.Rows[e.RowIndex].Cells["HinhThuc"].Value.ToString();
                comboBoxHocKy.Text = dataGridView1.Rows[e.RowIndex].Cells["TenHocKy"].Value.ToString();
            }
        }
    }
}
