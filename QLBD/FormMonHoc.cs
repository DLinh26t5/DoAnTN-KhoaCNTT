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
    public partial class FormMonHoc : Form
    {
        BUS_MonHoc busmh = new BUS_MonHoc();
        BUS_KhoaHoc buskhoa = new BUS_KhoaHoc();
        BUS_NganhHoc busnganh = new BUS_NganhHoc();
        BUS_HocKy bushk = new BUS_HocKy();  
        BUS_HinhThuc busht = new BUS_HinhThuc();
        public FormMonHoc()
        {
            InitializeComponent();
        }
        
        private void FormMonHoc_Load(object sender, EventArgs e)
        {
           dataGridView1.DataSource = busmh.Load();
            LoadcomboxKhoa();
        }
        private void LoadcomboxKhoa()
        {
            DataTable dt  = buskhoa.LoadKhoa();
            comboBoxKhoa.DisplayMember = "TenKhoa";
            comboBoxKhoa.ValueMember = "ID";
            comboBoxKhoa.DataSource = dt;
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            MonHoc mh = new MonHoc(0,textBoxMaMH.Text,textBoxTenMH.Text,Convert.ToInt32(textBoxSoGio.Text),ID);
            busmh.Insert(mh);
            dataGridView1.DataSource = busmh.Load();
        }
        private int ID_Select = -1;
        private void buttonSua_Click(object sender, EventArgs e)
        {
            MonHoc mh = new MonHoc( textBoxMaMH.Text, textBoxTenMH.Text, Convert.ToInt32(textBoxSoGio.Text),Convert.ToInt32(comboBoxHinhThuc.SelectedValue.ToString())) ;
            /*mh.MaMonHoc = textBoxMaMH.Text;
            mh.TenMonHoc = textBoxTenMH.Text;
            mh.SoGio = Convert.ToInt32(textBoxSoGio.Text);
            mh.ID_HinhThuc = Convert.ToInt32(comboBoxHinhThuc.SelectedValue);
            mh.ID = ID_Select;*/
            busmh.Update(mh);
            dataGridView1.DataSource = busmh.Load();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            MonHoc mh = new MonHoc();
            mh.MaMonHoc = textBoxMaMH.Text;
            mh.TenMonHoc = textBoxTenMH.Text;
            mh.SoGio = Convert.ToInt32(textBoxSoGio.Text);
            mh.ID_HinhThuc = Convert.ToInt32(comboBoxHinhThuc.SelectedValue);
            mh.ID = ID_Select;
            busmh.Delete(mh);
            dataGridView1.DataSource = busmh.Load();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*ID_Select = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
            comboBoxKhoa.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBoxNganh.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBoxHocKy.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();*/
            comboBoxHinhThuc.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBoxMaMH.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxTenMH.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxSoGio.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
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

            int Id = (int)comboBoxNganh.SelectedValue;
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
        private void comboBoxHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Id = (int)comboBoxHocKy.SelectedValue;
            LoadHt(Id);
        }
        private void LoadHt(int Id)
        {
            BUS_HinhThuc bus = new BUS_HinhThuc();
            DataTable dt = bus.Getthucbyky(Id);
            comboBoxHinhThuc.DisplayMember = "HinhThuc";
            comboBoxHinhThuc.ValueMember = "ID";
            comboBoxHinhThuc.DataSource = dt;
        }
        private int ID = -1;
        private void comboBoxHinhThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
             ID = (int)comboBoxHinhThuc.SelectedValue;

        }
    }
}
