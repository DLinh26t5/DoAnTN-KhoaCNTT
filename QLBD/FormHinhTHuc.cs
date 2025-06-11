using BUS;
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

namespace QLBD
{
    public partial class FormHinhTHuc : Form
    {
        public FormHinhTHuc()
        {
            InitializeComponent();
        }
        BUS_HinhThuc busht = new BUS_HinhThuc();
        BUS_KhoaHoc busk = new BUS_KhoaHoc();
        BUS_NganhHoc busn = new BUS_NganhHoc();
        BUS_HocKy  bushk = new BUS_HocKy();
        private void FormHinhTHuc_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = busht.LoadHthuc();
            LoadcomboxKhoa();
            /*comboBoxKhoa.DataSource = busk.LoadKhoa();
            comboBoxKhoa.DisplayMember = "TenKhoa";
            comboBoxKhoa.ValueMember = "ID";
            comboBoxKhoa.DataSource = busn.LoadNganh();
            comboBoxKhoa.DisplayMember = "TenNganh";
            comboBoxKhoa.ValueMember = "ID";
            comboBoxKhoa.DataSource = bushk.Load();
            comboBoxKhoa.DisplayMember = "TenHocKy";
            comboBoxKhoa.ValueMember = "ID";
            dataGridView1.DataSource = busn.LoadNganh();
            dataGridView1.DataSource = bushk.Load();
            dataGridView1.DataSource = busk.LoadKhoa();
            comboBoxKhoa.SelectedIndex = -1;*/
        }
        private void LoadcomboxKhoa()
        {
            DataTable dt = busk.LoadKhoa();
            comboBoxKhoa.DisplayMember = "TenKhoa";
            comboBoxKhoa.ValueMember = "ID";
            comboBoxKhoa.DataSource = dt;
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            DTO_HinhThuc ht = new DTO_HinhThuc();
            ht.HinhThuc=textBoxHinhThuc.Text;
            ht.ID_HocKy=Convert.ToInt32(comboBoxTenHK.SelectedValue);
            busht.Insert(ht);
            dataGridView1.DataSource = busht.LoadHthuc();
        }
        private int ID_Select = -1;
        private void buttonSua_Click(object sender, EventArgs e)
        {
            DTO_HinhThuc hk = new DTO_HinhThuc();
            hk.HinhThuc = textBoxHinhThuc.Text;
            hk.ID_HocKy = Convert.ToInt32(comboBoxNganh.SelectedValue);
            hk.ID = ID_Select;

            busht.Update(hk);
            dataGridView1.DataSource = busht.LoadHthuc();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {

            DTO_HinhThuc hk = new DTO_HinhThuc();
            hk.HinhThuc = textBoxHinhThuc.Text;
            hk.ID_HocKy = Convert.ToInt32(comboBoxNganh.SelectedValue);
            hk.ID = ID_Select;
            busht.Delete(hk);
            dataGridView1.DataSource = busht.LoadHthuc();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID_Select = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
            textBoxHinhThuc.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBoxTenHK.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            /*comboBoxKhoa.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBoxNganh.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();*/

        }
           

        private void comboBoxKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)comboBoxKhoa.SelectedValue;
            LoadNganh(id);
        }
        private void LoadNganh(int id)
        {
            BUS_NganhHoc busN = new BUS_NganhHoc();
            DataTable dt = busN.GetNganhbyKhoa(id);
            comboBoxNganh.DisplayMember = "TenNganh";
            comboBoxNganh.ValueMember = "id";
            comboBoxNganh.DataSource = dt;
        }

        private void comboBoxNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Id=(int)comboBoxNganh.SelectedValue;
            LoadHk(Id); 
        }
        private void LoadHk(int Id)
        {
            BUS_HocKy bus = new BUS_HocKy();
            DataTable dt = bus.Gethkybynganh(Id);
            comboBoxTenHK.DisplayMember = "TenHocKy";
            comboBoxTenHK.ValueMember = "ID";
            comboBoxTenHK.DataSource = dt;
        }
    }
}
