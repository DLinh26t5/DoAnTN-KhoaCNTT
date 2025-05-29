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
    public partial class FormMonHoc : Form
    {
        public FormMonHoc()
        {
            InitializeComponent();
        }
        BUS_MonHoc busmh = new BUS_MonHoc();
        private void FormMonHoc_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = busmh.Load();
            LoadComboboxkhoa();
        }
        private void LoadComboboxkhoa()
        {
            BUS_KhoaHoc buskhoa = new BUS_KhoaHoc();
            DataTable dt = buskhoa.LoadKhoa();
            comboBoxTenKhoa.DisplayMember = "TenKhoa";
            comboBoxTenKhoa.ValueMember = "ID";
            comboBoxTenKhoa.DataSource = dt;
        }

        private void comboBoxTenKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTenKhoa.SelectedValue != null && comboBoxTenKhoa.SelectedValue != DBNull.Value)
            {
                int id = (int)comboBoxTenKhoa.SelectedValue;
                LoadNganh(id);
            }
            else
            {
                // Xử lý trường hợp không có lựa chọn nào, ví dụ: xóa dữ liệu comboboxNganh
                comboBoxTenNganh.DataSource = null;
            }
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

        private void comboBoxHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Id = (int)comboBoxHocKy.SelectedValue;
            LoadHT(Id);
        }
        private void LoadHT(int Id)
        {
            BUS_HinhThuc bus = new BUS_HinhThuc();
            DataTable dt = bus.Getthucbyky(Id);
            comboBoxHinhThuc.DisplayMember = "HinhThuc";
            comboBoxHinhThuc.ValueMember = "ID";
            comboBoxHinhThuc.DataSource = dt;
        }
        private int ID_Select = -1;
        private void buttonThem_Click(object sender, EventArgs e)
        {
            MonHoc mh = new MonHoc();
            mh.TenMonHoc = textBoxTenMH.Text;
            mh.MaMonHoc = textBoxMaMH.Text;
            mh.SoGio = Convert.ToInt32(textBoxSoGio.Text);
            mh.ID_HinhThuc = Convert.ToInt32(comboBoxHinhThuc.SelectedValue);
            busmh.Insert(mh);
            dataGridView1.DataSource = busmh.Load();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            MonHoc mh = new MonHoc();
            mh.TenMonHoc = textBoxTenMH.Text;
            mh.MaMonHoc = textBoxMaMH.Text;
            mh.SoGio = Convert.ToInt32(textBoxSoGio.Text);
            mh.ID_HinhThuc = Convert.ToInt32(comboBoxHinhThuc.SelectedValue);
            mh.ID = ID_Select;
            busmh.Update(mh);
            dataGridView1.DataSource = busmh.Load();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            MonHoc mh = new MonHoc();
            mh.TenMonHoc = textBoxTenMH.Text;
            mh.MaMonHoc = textBoxMaMH.Text;
            mh.SoGio = Convert.ToInt32(textBoxSoGio.Text);
            mh.ID_HinhThuc = Convert.ToInt32(comboBoxHinhThuc.SelectedValue);
            mh.ID = ID_Select;
            busmh.Update(mh);
            dataGridView1.DataSource = busmh.Load();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
