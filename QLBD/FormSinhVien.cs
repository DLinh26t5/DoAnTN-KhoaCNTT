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
    public partial class FormSinhVien : Form
    {
        public FormSinhVien()
        {
            InitializeComponent();
        }
        
        private void FormSinhVien_Load(object sender, EventArgs e)
        {
            BUS_SinhVien bus = new BUS_SinhVien();
            dataGridView1.DataSource = bus.Loadsv();

            Loadkhoatocombobox();
        }
        private void Loadkhoatocombobox()
        {
            BUS_KhoaHoc busK = new BUS_KhoaHoc();
            DataTable dt = busK.LoadKhoa();
            comboBoxTenKhoa.DisplayMember = "TenKhoa";
            comboBoxTenKhoa.ValueMember = "ID";
            comboBoxTenKhoa.DataSource = dt;
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
                // Nếu không có Khoa, xóa Ngành và Lớp
                comboBoxTenNganh.DataSource = null;
                comboBoxTenLop.DataSource = null;
            }
        }
        private void LoadNganh(int ID_Khoa)
        {
            BUS_NganhHoc bus = new BUS_NganhHoc();
            DataTable dt = bus.GetNganhbyKhoa(ID_Khoa);
            comboBoxTenNganh.DisplayMember = "Tennganh";
            comboBoxTenNganh.ValueMember = "ID";
            comboBoxTenNganh.DataSource = dt;
        }

        private void comboBoxTenNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTenNganh.SelectedIndex != -1)
            {
                int ID = (int)comboBoxTenNganh.SelectedValue;
                LoadLop(ID);
            }
            else
            {
                // Nếu không có Ngành, xóa Lớp
                comboBoxTenLop.DataSource = null;
            }
        }
        private void LoadLop(int ID)
        {
            BUS_Lop bus = new BUS_Lop();
            DataTable dt = bus.GetLopbyNganh(ID);
            comboBoxTenLop.DisplayMember = "Tenlop";
            comboBoxTenLop.ValueMember = "ID";
            comboBoxTenLop.DataSource = dt;
            comboBoxTenLop.SelectedIndex = -1;

        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            string Masv = textBoxMaSV.Text;
            string Tensv = textBoxTenSV.Text;
            int ID_lop = Convert.ToInt32(comboBoxTenLop.SelectedValue);

            SinhVien sv = new SinhVien();
            sv.MaSinhVien = Masv;
            sv.TenSinhVien = Tensv;
            sv.ID_Lop = ID_lop;

            BUS_SinhVien bus = new BUS_SinhVien();
            string s = bus.Insert(sv);
            LoadSinhvienbyLop(ID_lop);
            MessageBox.Show(s);
        }
        private void LoadSinhvienbyLop(int ID_lop)
        {
            BUS_SinhVien bus = new BUS_SinhVien();
            DataTable dt = bus.GetSinhvienbylop(ID_lop);
            if (dt != null && dt.Rows.Count > 0)
            {
                if (dataGridView1.DataSource != dt)
                {
                    dataGridView1.DataSource = dt;
                }
            }
        }
        private int selectedid = -1;
        private int ID_lop = -1;
        private void buttonSua_Click(object sender, EventArgs e)
        {
            int ID = selectedid;
            string Masv = textBoxMaSV.Text;
            string Tensv = textBoxTenSV.Text;
            int ID_Lop = ID_lop;

            SinhVien sv = new SinhVien();
            sv.MaSinhVien = Masv;
            sv.TenSinhVien = Tensv;
            sv.ID_Lop = ID_Lop;
            sv.ID = ID;

            BUS_SinhVien bus = new BUS_SinhVien();
            string s = bus.Update(sv);
            LoadSinhvienbyLop(ID_Lop);
            MessageBox.Show(s);
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            int ID = selectedid;
            int ID_Lop = ID_lop;
            DialogResult d = MessageBox.Show($"Ban co chac chan mua xoa ?", "Xac nhan xoa", MessageBoxButtons.YesNo);
            if (d == DialogResult.No)
            {
                return;
            }
            SinhVien sv = new SinhVien();
            sv.ID = ID;

            BUS_SinhVien bus = new BUS_SinhVien();
            string s = bus.Delete(sv);
            LoadSinhvienbyLop(ID_Lop);
            MessageBox.Show(s);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
            textBoxMaSV.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxTenSV.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            //dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[4].Value);
            ID_lop = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID_Lop"].Value);

        }
    }
}
