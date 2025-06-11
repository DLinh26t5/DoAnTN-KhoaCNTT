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
namespace QLBD
{
    public partial class FormHocKy : Form
    {
        BUS_HocKy bushky = new BUS_HocKy();
        BUS_NganhHoc busNHoc = new BUS_NganhHoc();
        BUS_KhoaHoc busKH = new BUS_KhoaHoc();
        public FormHocKy()
        {
            InitializeComponent();
        }

        private void FormHocKy_Load(object sender, EventArgs e)
        {
            //đổ dữ liệu ra combobox
           /* comboBoxKhoa.DataSource = busKH.LoadKhoa();
            comboBoxKhoa.DisplayMember = "TenKhoa";
            comboBoxKhoa.ValueMember = "ID";
            comboBoxKhoa.SelectedIndex = -1;
            /*comboBoxNganh.DataSource = busNHoc.LoadNganh();
            comboBoxNganh.DisplayMember = "TenNganh";
            comboBoxNganh.ValueMember = "ID";*/
            //đổ dl ra datagripview
           // dataGridView1.DataSource = busKH.LoadKhoa();
           // dataGridView1.DataSource = busNHoc.LoadNganh();
          //  dataGridView1.DataSource = bushky.Load();
           // textBoxHocKy.Clear();
           dataGridView1.DataSource = bushky.Load();
            LoadKhoatocombobox();


        }
        private void LoadKhoatocombobox()
        {
            
            DataTable dt = busKH.LoadKhoa();
            // comboBoxkhoa.Items.Clear();

            comboBoxKhoa.DisplayMember = "TenKhoa";
            comboBoxKhoa.ValueMember = "ID";
            comboBoxKhoa.DataSource = dt;
        }
        private void buttonThem_Click(object sender, EventArgs e)
        {
            HocKy hk = new HocKy(textBoxHocKy.Text,Convert.ToInt32(comboBoxNganh.SelectedValue.ToString()));
            bushky.Insert(hk);
            dataGridView1.DataSource = bushky.Load();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            HocKy hk = new HocKy();
            hk.TenHocKy = textBoxHocKy.Text;
            hk.ID_NganhHoc = Convert.ToInt32(comboBoxNganh.SelectedValue);
            hk.ID = ID_select;

            bushky.Update(hk);
            dataGridView1.DataSource = bushky.Load();

        }
        private int ID_select = -1;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID_select = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
            comboBoxKhoa.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBoxNganh.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxHocKy.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            HocKy hk = new HocKy();
            hk.TenHocKy = textBoxHocKy.Text;
            hk.ID_NganhHoc = Convert.ToInt32(comboBoxNganh.SelectedValue);
            hk.ID = ID_select;
            bushky.Delete(hk);
            dataGridView1 .DataSource = bushky.Load();
        }

        private void comboBoxKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {

            int Id = (int)comboBoxKhoa.SelectedValue;
            LoadNganh(Id);
           /* if (comboBoxKhoa.SelectedValue != null && comboBoxKhoa.SelectedValue is int)
            {
                int tenKhoa = Convert.ToInt32(comboBoxKhoa.SelectedValue);
                NganhHoc nganh = new NganhHoc(0, "", tenKhoa);
                comboBoxNganh.DataSource = busNHoc.GetNganhbyKhoa(nganh);
                comboBoxNganh.DisplayMember = "TenNganh"; // Hiển thị tên ngành
                comboBoxNganh.ValueMember = "ID";    // Lấy giá trị là mã ngành
                comboBoxNganh.SelectedIndex = -1;
               
            }*/
        }
        private void LoadNganh(int Id)
        {
            BUS_NganhHoc bus = new BUS_NganhHoc();
            DataTable dt = bus.GetNganhbyKhoa(Id);
            comboBoxNganh.DisplayMember = "Tennganh";
            comboBoxNganh.ValueMember = "ID";
            comboBoxNganh.DataSource = dt;


        }
        private void comboBoxNganh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
