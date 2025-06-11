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

namespace QLBD
{
    public partial class FormLanThi : Form
    {
        public FormLanThi()
        {
            InitializeComponent();
        }

        private void FormLanThi_Load(object sender, EventArgs e)
        {
            BUS_LanThi bus = new BUS_LanThi();
            dataGridView1.DataSource = bus.LoadLT();
            LoadKhoatocombobox();
        }
        private void LoadKhoatocombobox()
        {
            BUS_KhoaHoc bus = new BUS_KhoaHoc();
            DataTable dt = bus.LoadKhoa();
            comboBoxTenKhoa.DisplayMember = "TenKhoa";
            comboBoxTenKhoa.ValueMember = "ID";
            comboBoxTenKhoa.DataSource = dt;
            comboBoxTenKhoa.SelectedIndex = -1;
        }

        private void comboBoxTenKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTenKhoa.SelectedIndex != -1)
            {
                int ID = (int)comboBoxTenKhoa.SelectedValue;
                LoadNganh(ID);
            }
            else
            {
                comboBoxTenNganh.DataSource = null;
                comboBoxHocKy.DataSource = null;
                comboBoxHinhThuc.DataSource = null;
            }
        }
        private void LoadNganh(int ID)
        {
            BUS_NganhHoc bus = new BUS_NganhHoc();
            DataTable dt = bus.GetNganhbyKhoa(ID);
            comboBoxTenNganh.DisplayMember = "Tennganh";
            comboBoxTenNganh.ValueMember = "ID";
            comboBoxTenNganh.DataSource = dt;
            comboBoxTenNganh.SelectedIndex = -1;

        }

        private void comboBoxTenNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTenNganh.SelectedIndex != -1)
            {
                int id = (int)comboBoxTenNganh.SelectedValue;
                LoadHk(id);
            }
            else
            {
                comboBoxHocKy.DataSource = null;
                comboBoxHinhThuc.DataSource = null;
            }
        }
        private void LoadHk(int id)
        {
            BUS_HocKy bus = new BUS_HocKy();
            DataTable dt = bus.Gethkybynganh(id);
            comboBoxHocKy.DisplayMember = "TenHocky";
            comboBoxHocKy.ValueMember = "ID";
            comboBoxHocKy.DataSource = dt;
            comboBoxHocKy.SelectedIndex = -1;
        }

        private void comboBoxHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxHocKy.SelectedIndex != -1)
            {
                int iD = (int)comboBoxHocKy.SelectedValue;
                LoadHT(iD);
            }
            else
            {
                comboBoxHinhThuc.DataSource = null;

            }
        }
        private void LoadHT(int iD)
        {
            BUS_HinhThuc bus = new BUS_HinhThuc();
            DataTable dt = bus.Getthucbyky(iD);
            comboBoxHinhThuc.DisplayMember = "HinhThuc";
            comboBoxHinhThuc.ValueMember = "ID";
            comboBoxHinhThuc.DataSource = dt;
            comboBoxHinhThuc.SelectedIndex = -1;

        }

        private void comboBoxHinhThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxHinhThuc.SelectedIndex != -1)
            {
                int Id = (int)comboBoxHinhThuc.SelectedValue;
                LoadMonhoc(Id);
            }
            else
            {
                comboBoxMonHoc.DataSource = null;
            }
        }
        private void LoadMonhoc(int Id)
        {
            BUS_MonHoc bus = new BUS_MonHoc();
            DataTable dt = bus.GetmonhocbyHinhthuc(Id);
            comboBoxMonHoc.DisplayMember = "TenMonHoc";
            comboBoxMonHoc.ValueMember = "ID";
            comboBoxMonHoc.DataSource = dt;
            comboBoxMonHoc.SelectedIndex = -1;
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            int Lanthi = Convert.ToInt32(numericUpDownLT.Value);
            DateTime Ngaythi = dateTimePickerNThi.Value;
            int Id_mon = Convert.ToInt32(comboBoxMonHoc.SelectedValue);


            LanTHi lt = new LanTHi();
            lt.LanThi = Lanthi;
            lt.NgayThi = Ngaythi;
            lt.MaMon = Id_mon;
            BUS_LanThi bus = new BUS_LanThi();
            string s = bus.Insert(lt);
            LoadLanthibyMonhoc(Id_mon);
            MessageBox.Show(s);
        }
        private void LoadLanthibyMonhoc(int Id)
        {
            BUS_LanThi bUS = new BUS_LanThi();
            DataTable dt = bUS.GetlanthibyMonhoc(Id);
            if (dt != null && dt.Rows.Count > 0)
            {
                if (dataGridView1.DataSource != dt)
                {
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void comboBoxMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMonHoc.SelectedIndex >= 0)
            {
                int Id = (int)comboBoxMonHoc.SelectedValue;
                LoadLanthibyMonhoc(Id);
            }
        }
        private int selectedID = -1;
        private int Mn = -1;
        private void buttonSua_Click(object sender, EventArgs e)
        {
            int ID = selectedID;
            int Lanthi = Convert.ToInt32(numericUpDownLT.Value);
            DateTime Ngaythi = dateTimePickerNThi.Value;

            LanTHi l = new LanTHi();
            l.LanThi = Lanthi;
            l.NgayThi = Ngaythi;
            l.MaMon = Mn;
            l.ID = ID;

            BUS_LanThi bus = new BUS_LanThi();
            string s = bus.Update(l);
            LoadLanthibyMonhoc(Mn);
            MessageBox.Show(s);
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            int ID = selectedID;
            int mamon = Mn;
            DialogResult d = MessageBox.Show($"Ban co chac chan mua xoa ?", "Xac nhan xoa", MessageBoxButtons.YesNo);
            if (d == DialogResult.No)
            {
                return;
            }
            LanTHi l = new LanTHi();
            l.ID = ID;

            BUS_LanThi bUS = new BUS_LanThi();
            string s = bUS.Delete(l);
            LoadLanthibyMonhoc(mamon);
            MessageBox.Show(s);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            selectedID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
            numericUpDownLT.Value = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
            dateTimePickerNThi.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[2].Value);
            Mn = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Mamon"].Value);
        }
    }
}
